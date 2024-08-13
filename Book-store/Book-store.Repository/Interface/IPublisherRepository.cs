using Book_store.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Repository.Interface
{
    public interface IPublisherRepository
    {
        public List<Publisher> GetAll();
        public Publisher Get(Guid id);

        public void Update(Publisher publisher);
        public List<Book> GetBooksForPublisher(Guid id);
        public void Add(Publisher publisher);
    }
}
