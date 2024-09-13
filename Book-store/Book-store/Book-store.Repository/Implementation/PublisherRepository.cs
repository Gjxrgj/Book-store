using Book_store.Domain.Models;
using Book_store.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Book_store.Repository.Implementation
{
    public class PublisherRepository : IPublisherRepository
    {
        private DbSet<Publisher> publishers;
        private readonly BookStoreContext context;
        
        public PublisherRepository(BookStoreContext context) 
        {
            this.context = context;
            publishers = context.Set<Publisher>();
        }

        public void Add(Publisher publisher)
        {
            if (publisher == null)
            {
                throw new ArgumentNullException("entity");
            }
            publishers.Add(publisher);
            context.SaveChanges();
        }

        public void Update(Publisher publisher)
        {
            if (publisher == null)
            {
                throw new ArgumentNullException("publisher");
            }
            publishers.Update(publisher);
            context.SaveChanges();
        }
        public Publisher Get(Guid id)
        {
            return this.publishers
                .Include(z => z.Books)
                .SingleOrDefaultAsync(z => z.Id == id)
                .Result;
        }

        public List<Publisher> GetAll()
        {
            return this.publishers.ToList();
        }

        public List<Book> GetBooksForPublisher(Guid id)
        {
            List<Book> books = Get(id).Books.ToList();
            if (books != null)
            {
                return books;
            }
            return new List<Book>();
        }
    }
}
