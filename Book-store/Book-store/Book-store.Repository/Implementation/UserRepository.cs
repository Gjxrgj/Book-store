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
    public class UserRepository : IUserRepository
    {
        private readonly BookStoreContext context;
        private DbSet<BookStoreUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(BookStoreContext context)
        {
            this.context = context;
            entities = context.Set<BookStoreUser>();
        }
        public IEnumerable<BookStoreUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public BookStoreUser Get(string id)
        {
            var user =  entities
               .Include(z => z.ShoppingCart)
               .Include("ShoppingCart.BookInShoppingCart")
               .Include("ShoppingCart.BookInShoppingCart.Book")
               .SingleOrDefault(s => s.Id == id);

            return user;
        }
        public void Insert(BookStoreUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(BookStoreUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(BookStoreUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

    }
}
