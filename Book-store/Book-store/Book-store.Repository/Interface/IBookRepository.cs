using Book_store.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Repository.Interface
{
    public interface IBookRepository
    {
        public List<Book> GetAll();
        public Book Get(Guid id);

        public void Update(Book book);
        public void Create(Book book);
        void Delete(Guid id);
    }
}
