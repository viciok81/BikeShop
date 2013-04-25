using System.Web.Mvc;
using Domain.Abstract;
using Ninject;
using WebUI.Infrastructure.Concrete;

namespace WebUI.Binders
{
    //session
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey ="Cart" ;
       
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            
            Cart cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            //if (cart == null)
            //{
            //    cart=new Cart(controllerContext.HttpContext.User.Identity.Name);
            //    controllerContext.HttpContext.Session[sessionKey] = cart;
            //}
            return cart;
        }
    }

   
}