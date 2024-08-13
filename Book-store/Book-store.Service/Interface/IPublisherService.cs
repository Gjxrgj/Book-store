using Book_store.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Service.Interface
{
    public interface IPublisherService
    {
        public List<Publisher> GetAll();
        public Publisher GetPublisher(Guid id);

        public void Update(Publisher publisher);

        public List<Book> GetBookForPublisher(Guid id);
        public void Add(Publisher publisher);
    }
}
