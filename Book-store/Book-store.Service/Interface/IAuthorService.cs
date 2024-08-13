using Book_store.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Service.Interface
{
    public interface IAuthorService
    {
        List<Author> GetAll(Guid[] id);
        List<Author> GetAll();
        Author GetById(Guid id);
        void DeleteById(Guid id);
        void UpdateById(Author author);
        void Add(Author author);
    }
}
