using Book_store.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Service.Interface
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
        public Book GetBookById(Guid id);

        public void Update(Book book);
        public void CreateBook(Book book);
        public List<Book> GetBooksByIds(Guid[] ids);
        void Delete(Guid id);
    }
}
