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
            //var products = repository.VProductAndDescriptions.Distinct();
            var products = repository.Products;
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(x => x.ProductCategory.Name == category);
                //products = products.Join(repository.Products.Where(x=>x.ProductCategory.Name == category), x=>x.ProductID,y=>y.ProductID, (x,y)=>x).AsQueryable();
            }
            //var t = products.Count();
            var viewProducts = products.Select(x => new VProductAndDescription
                                                        {
                                                            ProductID = x.ProductID,
                                                            Name = x.Name,
                                                            Description = x.Name,
                                                            ProductModel = x.ProductModel.Name,
                                                            Culture = x.Name
                                                        });
        ProductListViewModel result = new ProductListViewModel
                                              {
                                                  CurrentCategory = category,
                                                  Products = viewProducts.
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
