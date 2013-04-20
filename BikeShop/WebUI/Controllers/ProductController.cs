using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
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
        public FileContentResult GetImage(int productId)
        {
            Product product = repository.Products.SingleOrDefault(x => x.ProductID == productId);
            if (product != null)
            {
                //Bitmap img;// = new Bitmap();
                //using (Stream sr = new MemoryStream(product.ThumbNailPhoto))
                //{
                //    img = new Bitmap(sr);
                //    return File(, product.ThumbnailPhotoFileName);
                //}
                //using (System.Drawing.Image photoImg =  System.Drawing.Image.FromStream(product.ThumbNailPhoto))
                //{
                    
                //}
                ////var img = Bitmap.FromStream(); product.ThumbNailPhoto;
                return File(product.ThumbNailPhoto, product.ThumbnailPhotoFileName);
            }
            return null;
        }

        
    }
}
