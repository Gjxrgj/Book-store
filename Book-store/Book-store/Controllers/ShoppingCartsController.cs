using Book_store.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Security.Claims;

namespace Book_store.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartsController(IShoppingCartService _shoppingCartService)
        {
            this._shoppingCartService = _shoppingCartService;
        }

        // GET: ShoppingCarts
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dto = _shoppingCartService.getShoppingCartInfo(userId);
            return View(dto);
            //return (IActionResult)dto;
        }


        public IActionResult DeleteFromShoppingCart(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _shoppingCartService.deleteProductFromShoppingCart(userId, id);

            return RedirectToAction("Index");

        }

        public IActionResult SuccessPayment()
        {
            return View();
        }

        public IActionResult Order()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var res = _shoppingCartService.order(userId);
            return RedirectToAction("Index", "ShoppingCarts");
        }


        public IActionResult PayOrder(string stripeEmail, string stripeToken)
        {
            StripeConfiguration.ApiKey = "sk_test_51PlHjsP8t3sfphX83iZZxV6EabhhebfMHC2CVE8NKxFd7t7iUtV1ZWS5PwGvhaZdAkRDE8SYE84H6LnQOyjPhx6a00cvWL90NC";
            var customerService = new CustomerService();
            var chargeService = new ChargeService();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var order = this._shoppingCartService.getShoppingCartInfo(userId);

            var customer = customerService.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = chargeService.Create(new ChargeCreateOptions
            {
                Amount = (Convert.ToInt32(order.TotalPrice) * 100),
                Description = "Bookstore Payment",
                Currency = "usd",
                Customer = customer.Id
            });

            if (charge.Status == "succeeded")
            {
                this.Order();
                return RedirectToAction("SuccessPayment");

            }
            else
            {
                return RedirectToAction("NotSuccessPayment");
            }
        }

    }
}
