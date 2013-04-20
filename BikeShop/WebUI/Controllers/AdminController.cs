using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductionRepository repository;
        
        public AdminController(IProductionRepository _repository)
        {
            repository = _repository;
        }
        public ActionResult Index()
        {
            return View(repository.Products);
        }


        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int productId)
        {
            return View(repository.Products.FirstOrDefault(x=>x.ProductID == productId));
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image)
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

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product item = repository.Products.SingleOrDefault(x => x.ProductID == productId);
            if (item != null)
            {
                repository.Delete(item);
                TempData["admin_message"] = string.Format("{0} was deleted", item.Name);
            }
            return RedirectToAction("Index");
        }

        
    }
}
