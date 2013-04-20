using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        private IProductionRepository repository;
        private int PageSize = 5;

        public ProductController (IProductionRepository _repository)
        {
            repository = _repository;
        }

        public ActionResult List(string category, int page = 1)
        {
            var products = repository.Products;
            if (category != null)
            {
                products = products.Where(x => x.ProductCategory.Name == category);
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

    }
}
