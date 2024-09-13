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
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly BookStoreContext bookStoreContext;
        private DbSet<ShoppingCart> _shoppingCarts;
        public ShoppingCartRepository(BookStoreContext _bookStoreContext) 
        {
            this.bookStoreContext = _bookStoreContext;
            this._shoppingCarts = _bookStoreContext.Set<ShoppingCart>();
        }
        public void Update(ShoppingCart shoppingCart)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentNullException("shoppingCart");
            }
            _shoppingCarts.Update(shoppingCart);
            bookStoreContext.SaveChanges();
        }
    }
}
