using Book_store.Domain.Models;
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
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository publisherRepository;

        public PublisherService(IPublisherRepository _publisherRepository)
        {
            this.publisherRepository = _publisherRepository;
        }

        public void Add(Publisher publisher)
        {
            this.publisherRepository.Add(publisher);
        }

        public List<Publisher> GetAll()
        {
            return this.publisherRepository.GetAll();
        }

        public List<Book> GetBookForPublisher(Guid id)
        {
            return this.publisherRepository.GetBooksForPublisher(id);
        }

        public Publisher GetPublisher(Guid id)
        {
            return this.publisherRepository.Get(id);
        }

        public void Update(Publisher publisher)
        {
            this.publisherRepository.Update(publisher);
        }
    }
}
