using System.Linq;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
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

        public ViewResult Index (Cart cart, string returnUrl)
        {
            return View(new CartViewModel {Cart = cart, ReturnUrl = returnUrl});
        }
        public RedirectToRouteResult Add(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.SingleOrDefault(x => x.ProductID == productId);
            if (product != null) cart.AddProduct(product, 1);
            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult Remove(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.SingleOrDefault(x => x.ProductID == productId);
            if (product != null) cart.RemoveProduct(product);
            return RedirectToAction("Index", new { returnUrl });
        }
        
        public ViewResult Summary(Cart cart)
        {
            return View(cart);
        }
        public ViewResult Checkout()
        {
            return View();
        }
    }
}
