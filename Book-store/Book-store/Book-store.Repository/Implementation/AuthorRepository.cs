using Book_store.Domain.Models;
using Book_store.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Book_store.Repository.Implementation
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreContext context;
        private DbSet<Author> authors;
        public AuthorRepository(BookStoreContext _context) 
        {
            context = _context;
            authors = _context.Set<Author>();
        }
        public List<Author> GetAll()
        {
            return authors.ToList();
        }

        public Author GetAuthor(Guid id)
        {
            return authors.SingleOrDefaultAsync(a => a.Id == id).Result;
        }

        public void Add(Author author) 
        {
            if (author == null)
            {
                throw new ArgumentNullException("entity");
            }
            authors.Add(author);
            context.SaveChanges();
        }
        public void Update(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException("author");
            }
            authors.Update(author);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            authors.Remove(this.GetAuthor(id));
            context.SaveChanges();
        }
    }
}
