using System.Linq;
using System.Web.Mvc;
using Domain.Abstract;
using WebUI.Models;

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
            var res = repository.ProductCategories.Where(x => x.ParentProductCategoryID != null)
                .OrderBy(x => x.ProductCategory2.Name).ThenBy(x => x.Name)
                .Select(x => new CategoryWithParent
                                 {
                                     ProductCategoryID = x.ProductCategoryID,
                                     ProductCategoryName = x.Name,
                                     ParentProductCategoryName = x.ProductCategory2.Name
                                 });
            return PartialView(res);//repository.ProductCategories.Where(x=>x.ParentProductCategoryID != null).OrderBy(x=>x.ParentProductCategoryID).OrderBy(x=>x.Name));
        }

    }
}
