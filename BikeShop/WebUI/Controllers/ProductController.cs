using System.Linq;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductionRepository repository;
        private int PageSize = 5;

        public ProductController (IProductionRepository _repository)
        {
            repository = _repository;
        }

        public ActionResult List(string category, int page = 1)
        {
            var products = repository.VProductAndDescriptions;
            if (category != null)
            {
                products = products.Join(repository.Products.Where(x=>x.ProductCategory.Name == category), x=>x.ProductID,y=>y.ProductID, (x,y)=>x).AsQueryable();
            }
            var t = products.Count();
        ProductListViewModel result = new ProductListViewModel
                                              {
                                                  CurrentCategory = category,
                                                  Products = products.
                                                        OrderBy(x => x.Name).Skip((page - 1) * PageSize).Take(PageSize),
                                                  PagingInfo = new PagingInfo
                                                  {
                                                      CurrentPage = page,
                                                      ItemsPerPage = PageSize,
                                                      TotalItems = products.Count()
                                                  }
                                              };
            return View(result);
        }
        public FileContentResult GetImage(int productId)
        {
            Product product = repository.Products.SingleOrDefault(x => x.ProductID == productId);
            if (product != null)
            {
                return File(product.ThumbNailPhoto, product.ThumbnailPhotoFileName);
            }
            return null;
        }
    }
}
