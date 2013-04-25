using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private int PageSize = 10;

        private IProductionRepository repository;
        
        public AdminController(IProductionRepository _repository)
        {
            repository = _repository;
        }
        #region products
        public ActionResult Product()
        {
            return View(repository.Products.ToList());
        }
       
        public ActionResult CreateProduct()
        {
            return View("EditProduct", new Product());
        }

        public ActionResult EditProduct(Guid rowguid)
        {
            return View(repository.Products.FirstOrDefault(x => x.rowguid == rowguid));
        }

        [HttpPost]
        public ActionResult EditProduct(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ThumbnailPhotoFileName = image.FileName;
                    product.ThumbNailPhoto = new byte[image.ContentLength];
                    image.InputStream.Read(product.ThumbNailPhoto, 0, image.ContentLength);
                }
                repository.Save(product);
                TempData["admin_message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(Guid rowguid)
        {
            Product item = repository.Products.SingleOrDefault(x => x.rowguid == rowguid);
            if (item != null)
            {
                repository.Delete(item);
                TempData["admin_message"] = string.Format("{0} was deleted", item.Name);
            }
            return RedirectToAction("Index");
        }
    #endregion

        #region category
        public ActionResult Category()
        {
            return View(repository.ProductCategories.OrderBy(x => x.ProductCategory2.Name).ThenBy(x => x.Name).ToList());
        }

        public ActionResult CreateCategory()
        {
            return View("EditCategory", new Product());
        }

        public ActionResult EditCategory(Guid rowguid)
        {
            return View(repository.Products.FirstOrDefault(x => x.rowguid == rowguid));
        }

        [HttpPost]
        public ActionResult EditCategory(Product product)
        {
            if (ModelState.IsValid)
            {
                
                repository.Save(product);
                TempData["admin_message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult DeleteCategory(Guid rowguid)
        {
            Product item = repository.Products.SingleOrDefault(x => x.rowguid == rowguid);
            if (item != null)
            {
                repository.Delete(item);
                TempData["admin_message"] = string.Format("{0} was deleted", item.Name);
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
