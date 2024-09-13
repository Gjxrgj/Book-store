using Book_store.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Repository.Interface
{
    public interface IAuthorRepository
    {
        List<Author> GetAll();
        Author GetAuthor(Guid id);
        public void Add(Author author);
        public void Update(Author author);
        public void Delete(Guid id);
    }
}
