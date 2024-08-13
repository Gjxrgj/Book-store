using Book_store.Domain.DTO;
using Book_store.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto getShoppingCartInfo(string userId);
        bool deleteProductFromShoppingCart(string userId, Guid productId);
        bool order(string userId);
        bool AddToShoppingConfirmed(BookInShoppingCart model, string userId);
    }
}
