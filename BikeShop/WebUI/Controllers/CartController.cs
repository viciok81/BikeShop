using System.Linq;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Infrastructure.Concrete;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles = "user")]
    public class CartController : Controller
    {
        private IProductionRepository repository;

        public CartController(IProductionRepository _repository)
        {
            repository = _repository;
        }

        public ViewResult Index (string returnUrl)
        {
            //var cart = new Cart(this.ControllerContext.HttpContext.User.Identity.Name, repository);
            //return View(new CartViewModel {Cart = cart, ReturnUrl = returnUrl});
            var carts = repository.CartItems.Where(x => x.Customer.EmailAddress == this.ControllerContext.HttpContext.User.Identity.Name).ToList();
            return View(new CartViewModel { CartItems = carts, ReturnUrl = returnUrl });
        }
        public RedirectToRouteResult Add(int productId, string returnUrl, int quantity=1)
        {
            //var cart = new Cart(this.ControllerContext.HttpContext.User.Identity.Name, repository);
            //Product product = repository.Products.SingleOrDefault(x => x.ProductID == productId);
            //if (product != null) cart.AddProduct(product, 1);
            //return RedirectToAction("Index", new {returnUrl});
            CartItem cart =
                repository.CartItems.SingleOrDefault(
                    x => x.Customer.EmailAddress == this.ControllerContext.HttpContext.User.Identity.Name && 
                    x.ProductId == productId);
            if (cart !=null)
            {
                cart.Quantity += quantity;
                repository.Save(cart);
            }
            else
            {
                var customer =repository.Customers.SingleOrDefault(
                        x => x.EmailAddress == this.ControllerContext.HttpContext.User.Identity.Name);
                if (customer != null)
                {
                    cart = new CartItem
                               {
                                   ProductId = productId,
                                   CustomerId = customer.CustomerID,
                                   Quantity = quantity
                               };
                    repository.Save(cart);
                }
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult Remove(int productId, string returnUrl)
        {
            var cart =
                repository.CartItems.SingleOrDefault(
                    x => x.Customer.EmailAddress == this.ControllerContext.HttpContext.User.Identity.Name &&
                         x.ProductId == productId);
            if (cart != null) repository.Delete(cart);
            return RedirectToAction("Index", new { returnUrl });
        }
        
        public ViewResult Summary()
        {
            //var cart = new Cart(this.ControllerContext.HttpContext.User.Identity.Name, repository);
            var carts = repository.CartItems.Where(x => x.Customer.EmailAddress == this.ControllerContext.HttpContext.User.Identity.Name).ToList();
            return View(carts);
        }
        public ViewResult Checkout()
        {
            return View();
        }
    }
}
