using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Infrastructure.Abstarct;
using WebUI.Models;
using WebUI.Infrastructure;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthProvider authProvider;
        private IProductionRepository repository;

        public  AccountController(IAuthProvider _authProvider, IProductionRepository _repository)
        {
            authProvider = _authProvider;
            repository = _repository;
        }
        public ViewResult LogOn()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect(Url.Action("List", "Product"));
        }
        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    if (System.Web.HttpContext.Current.User.IsInRole("admin"))
                    {
                        return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                    }
                    return Redirect(returnUrl ?? Url.Action("List", "Product"));
                }
                ModelState.AddModelError("","User name or Password where incorrect.");
            }
            return View();
        }


        public ViewResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel user)
        {
            //if (user.ConfirmPassword != user.Password)
            //    ModelState.AddModelError("", "Passwords are not equal.");
            if (repository.Customers.Any(x=>x.EmailAddress == user.UserName))
                ModelState.AddModelError("UserName", "User with such e-mail already exist.");
            if (ModelState.IsValid)
            {
                if (AddUser(user))
                {
                    return RedirectToAction("LogOn");
                }
                ModelState.AddModelError("", "Error saving new user.");
            }
            return View(user);
        }

        private bool AddUser(RegisterViewModel user)
        {
            Customer newuser = new Customer();
            newuser.FirstName = user.FirstName;
            newuser.LastName = user.LastName;
            newuser.EmailAddress = user.UserName;
            var pass = StringUtils.getSaltHash(user.Password);
            newuser.PasswordHash = pass.SingleOrDefault(x => x.Key == "hash").Value;
            newuser.PasswordSalt = pass.SingleOrDefault(x => x.Key == "salt").Value;
            try
            {
                repository.Save(newuser);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        
    }
}
