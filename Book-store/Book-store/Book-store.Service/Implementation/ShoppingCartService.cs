using Book_store.Domain;
using Book_store.Domain.DTO;
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
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IBookInOrderRepository _bookInOrderRepository;
        private readonly IEmailService _emailService;


        public ShoppingCartService(IBookInOrderRepository bookInOrderRepository,
            IOrderRepository _orderRepository, 
            IUserRepository userRepository,
            IEmailService emailService,
            IShoppingCartRepository shoppingCartRepository)
        {
            this._bookInOrderRepository = bookInOrderRepository;
            this._orderRepository = _orderRepository;
            this._emailService = emailService;
 
            this._userRepository = userRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }
        public bool AddToShoppingConfirmed(BookInShoppingCart model, string userId)
        {

            var loggedInUser = _userRepository.Get(userId);

            var userShoppingCart = loggedInUser.ShoppingCart;

            if (userShoppingCart.BookInShoppingCart == null)
                userShoppingCart.BookInShoppingCart = new List<BookInShoppingCart>(); ;

            userShoppingCart.BookInShoppingCart.Add(model);
            _shoppingCartRepository.Update(userShoppingCart);
            return true;
        }

        public bool deleteProductFromShoppingCart(string userId, Guid productId)
        {
            if (productId != null)
            {
                var loggedInUser = _userRepository.Get(userId);

                var userShoppingCart = loggedInUser.ShoppingCart;
                var product = userShoppingCart.BookInShoppingCart.Where(x => x.BookId == productId).FirstOrDefault();

                userShoppingCart.BookInShoppingCart.Remove(product);

                _shoppingCartRepository.Update(userShoppingCart);
                return true;
            }
            return false;

        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            var loggedInUser = _userRepository.Get(userId);

            var userShoppingCart = loggedInUser?.ShoppingCart;
            var allProduct = userShoppingCart?.BookInShoppingCart?.ToList();

            var totalPrice = allProduct.Select(x => (x.Book.Price * x.Quantity)).Sum();

            ShoppingCartDto dto = new ShoppingCartDto
            {
                Books = allProduct,
                TotalPrice = totalPrice
            };
            return dto;
        }

        public bool order(string userId)
        {
            if (userId == null)
                return false;

            var loggedInUser = _userRepository.Get(userId);

            var userShoppingCart = loggedInUser?.ShoppingCart;
            EmailMessage message = new EmailMessage();
            message.Subject = "Successfull order";
            message.MailTo = loggedInUser.Email;
            Order order = new Order
            {
                Id = Guid.NewGuid(),
                userId = userId,
                Owner = loggedInUser
            };

            List<BookInOrder> productsInOrder = new List<BookInOrder>();

            var rez = userShoppingCart.BookInShoppingCart.Select(
                z => new BookInOrder
                {
                    Id = Guid.NewGuid(),
                    BookId = z.Book.Id,
                    Book = z.Book,
                    OrderId = order.Id,
                    Order = order,
                    Quantity = z.Quantity
                }).ToList();


            StringBuilder sb = new StringBuilder();

            var totalPrice = 0.0;

            sb.AppendLine("Your order is completed. The order conatins: ");

            for (int i = 1; i <= rez.Count(); i++)
            {
                var currentItem = rez[i - 1];
                totalPrice += (Double) currentItem.Quantity * currentItem.Book.Price;
                sb.AppendLine(i.ToString() + ". " + currentItem.Book.Title + " with quantity of: " + currentItem.Quantity + " and price of: $" + currentItem.Book.Price);
            }

            sb.AppendLine("Total price for your order: " + totalPrice.ToString());
            message.Content = sb.ToString();

            productsInOrder.AddRange(rez);

            foreach (var product in productsInOrder)
            {
                _bookInOrderRepository.Insert(product);
            }

            loggedInUser.ShoppingCart.BookInShoppingCart.Clear();
            _userRepository.Update(loggedInUser);
            this._emailService.SendEmailAsync(message);

            return true;
        }

    }

}