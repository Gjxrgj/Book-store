using Book_store.Domain.Models;
using Book_store.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Repository.Implementation
{
    public class BookInOrderRepository : IBookInOrderRepository
    {
        private readonly BookStoreContext context;
        private DbSet<BookInOrder> entities;
        public BookInOrderRepository(BookStoreContext bookstorecontext) 
        {
            context = bookstorecontext;
            entities = bookstorecontext.Set<BookInOrder>();
        }
        public void Insert(BookInOrder bookInShoppingCart)
        {
            if (bookInShoppingCart == null)
            {
                throw new ArgumentNullException("Order");
            }
            entities.Add(bookInShoppingCart);
            context.SaveChanges();
        }

    }
}
