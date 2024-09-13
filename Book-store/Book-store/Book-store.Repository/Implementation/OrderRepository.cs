using Book_store.Domain.Models;
using Book_store.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookStoreContext context;
        private DbSet<Order> entities;

        public OrderRepository(BookStoreContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> GetAllOrders()
        {
            return entities
                .Include(z => z.BooksInOrder)
                .Include(z => z.Owner)
                .Include("BooksInOrder.Book")
                .ToList();
        }
        public void Insert(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Order");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public Order GetDetailsForOrder(Guid id)
        {
            return entities
                .Include(z => z.BooksInOrder)
                .Include(z => z.Owner)
                .Include("BooksInOrder.Book")
                .SingleOrDefaultAsync(z => z.Id == id).Result;
        }
    }
}
