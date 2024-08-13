using Book_store.Domain.Models;
using Book_store.Repository;
using Book_store.Repository.Interface;
using Book_store.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Service.Implementation
{
    public class BookService : IBookService
    {
        IBookRepository repository;
        public BookService(IBookRepository _repository)
        {
            repository = _repository;
        }

        public void CreateBook(Book book)
        {
            repository.Create(book);
        }

        public void Delete(Guid id)
        {
            repository.Delete(id);
        }

        public List<Book> GetAllBooks()
        {
            return repository.GetAll();
        }

        public Book GetBookById(Guid id)
        {
            return repository.Get(id);
        }
        public List<Book> GetBooksByIds(Guid[] ids)
        {
            if (ids == null || !ids.Any())
            {
                return new List<Book>();
            }

            return this.repository.GetAll().Where(b => ids.Contains(b.Id)).ToList();
        }

        public void Update(Book book)
        {
            repository.Update(book);
        }


    }
}
