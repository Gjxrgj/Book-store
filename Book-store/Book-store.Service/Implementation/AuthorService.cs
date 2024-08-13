using Book_store.Domain.Models;
using Book_store.Repository.Implementation;
using Book_store.Repository.Interface;
using Book_store.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Service.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;
        public AuthorService(IAuthorRepository _authorRepository) 
        {
            authorRepository = _authorRepository;
        }

        public void Add(Author author)
        {
            this.authorRepository.Add(author);
        }

        public void DeleteById(Guid id)
        {
            this.authorRepository.Delete(id);

        }

        public List<Author> GetAll(Guid[] ids)
        {
            return authorRepository.GetAll().Where(author => ids.Contains(author.Id)).ToList();
        }

        public List<Author> GetAll()
        {
            return authorRepository.GetAll();
        }

        public Author GetById(Guid id)
        {
            return authorRepository.GetAuthor(id);
        }

        public void UpdateById(Author author)
        {
            this.authorRepository.Update(author);
        }
    }
}
