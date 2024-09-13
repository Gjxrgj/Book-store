using Book_store.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<BookStoreUser> GetAll();
        BookStoreUser Get(string id);
        void Insert(BookStoreUser entity);
        void Update(BookStoreUser entity);
        void Delete(BookStoreUser entity);
    }
}
