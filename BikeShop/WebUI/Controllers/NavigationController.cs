using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;

namespace WebUI.Controllers
{
    public class NavigationController : Controller
    {

        private IProductionRepository repository;

        public NavigationController(IProductionRepository _repository)
        {
            repository = _repository;
        }
        
        public PartialViewResult Menu()
        {
            return PartialView(repository.ProductCategories.Where(x=>x.ParentProductCategoryID != null).OrderBy(x=>x.ParentProductCategoryID).OrderBy(x=>x.Name));
        }

    }
}
