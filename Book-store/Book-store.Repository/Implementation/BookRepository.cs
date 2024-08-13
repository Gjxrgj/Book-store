using Book_store.Domain.Models;
using Book_store.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext context;
       private DbSet<Book> books;
        public BookRepository(BookStoreContext _context) {
            books = _context.Set<Book>();
            this.context = _context;
        }

        public void Create(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("entity");
            }
            books.Add(book);
            context.SaveChanges();
        }

        public Book Get(Guid Id)
        {
            return books
                .Include(z => z.Authors)
                .SingleOrDefaultAsync(z => z.Id == Id).Result;
        }
        public void Update(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("book");
            }
            books.Update(book);
            context.SaveChanges();
        }
        public List<Book> GetAll()
        {
            return books
                .Include(b => b.Authors)
                .ToList();
        }

        public void Delete(Guid id)
        {
            books.Remove(this.Get(id));
            context.SaveChanges();
        }

    }
}
