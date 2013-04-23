using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Infrastructure;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        private IProductionRepository repository;
        public CustomerController(IProductionRepository _repository)
        {
            repository = _repository;
        }
        public ViewResult EditCustomer()
        {

            var user = repository.Customers.FirstOrDefault(x => x.EmailAddress == this.HttpContext.User.Identity.Name);
            var result = new CustomerViewModel { Customer = user };
            return View(result);
        }

       
        [HttpPost]
        public ActionResult EditCustomer(CustomerViewModel model)
        {
            var user = repository.Customers.SingleOrDefault(x => x.CustomerID == model.Customer.CustomerID
                                                                && x.rowguid == model.Customer.rowguid);
            if (user == null)
            {
                // TODO
                // log(User doesn't exist, Existing user try to get access to other accounts) 

                FormsAuthentication.SignOut();
                return Redirect(Url.Action("List", "Product"));
            }
            if (!StringUtils.IsValidPassword(model.OldPassword, user.PasswordSalt, user.PasswordHash))
            {
                ModelState.AddModelError("OldPassword", "Not valid.");
                model.Customer.EmailAddress = user.EmailAddress;
                model.NewPassword = null;
                model.OldPassword = null;
                model.RetypeNewPassword = null;
                return View(model);
            }
            model.Customer.EmailAddress = user.EmailAddress;
            model.Customer.PasswordHash = user.PasswordHash;
            model.Customer.PasswordSalt = user.PasswordSalt;
            if (model.NewPassword != null)
            {
                if (model.NewPassword.Length > 0)
                {
                    var newpass = StringUtils.getSaltHash(model.NewPassword);
                    model.Customer.PasswordHash = newpass.SingleOrDefault(x => x.Key == "hash").Value;
                    model.Customer.PasswordSalt = newpass.SingleOrDefault(x => x.Key == "salt").Value;
                }
            }
            ModelState.Remove("Customer.EmailAddress");
            ModelState.Remove("Customer.PasswordHash");
            ModelState.Remove("Customer.PasswordSalt");
            model.Customer.NameStyle = user.NameStyle;
            model.Customer.ModifiedDate = user.ModifiedDate;
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Save(model.Customer);
                    TempData["customer_message"] = "Customer information has been saved";
                    return RedirectToAction("EditCustomer");
                }
                catch(Exception ex)
                {
                    TempData["customer_message"] = "Error updating customer information";
                }
            }
            model.NewPassword = null;
            model.OldPassword = null;
            model.RetypeNewPassword = null;
            return View(model);
        }
    
        public ViewResult Addresses()
        {
            var customerAddresses = repository.CustomerAddresses.Where(x => x.CustomerID == 29559)
                            .Select(x=> new AddressesListModel()
                                {
                                    Address = x.Address,
                                    Customer = x.Customer,
                                    AddressType = x.AddressType
                                }
            );
                //EmailAddress == this.HttpContext.User.Identity.Name
            return View(customerAddresses);
        }

        public ActionResult EditAddress(int addressid)
        {
            return View(repository.Addresses.FirstOrDefault(x=>x.AddressID == addressid));
        }
        [HttpPost]
        public ActionResult EditAddress(Address model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Addresses");
            }
            return View(model);
        }
        public ActionResult CreateAddress()
        {
            return View("EditAddress",new Address());
        }

        [HttpPost]
        public ActionResult DeleteAddress(int addressid)
        {
            var custumeraddress = repository.CustomerAddresses
                .SingleOrDefault(x => x.AddressID == addressid && x.CustomerID == 29559);  //EmailAddress == this.HttpContext.User.Identity.Name
            if (custumeraddress != null)
            {
                try
                {
                    repository.Delete(custumeraddress.Address);
                    TempData["customer_message"] = "Address has been deleted.";
                    
                }
                catch (Exception ex)
                {
                    TempData["customer_message"] = "Error ocured deleting address.";
                    return View("EditAddress", custumeraddress.Address);
                }
            }
            return RedirectToAction("Addresses");
        }
    }
}
