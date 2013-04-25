using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var customerAddresses = repository.CustomerAddresses.Where(x=>x.Customer.EmailAddress == this.HttpContext.User.Identity.Name)//x => x.CustomerID == 29559)
                            .Select(x=> new AddressesListModel()
                                {
                                    Address = x.Address,
                                    Customer = x.Customer,
                                    AddressType = x.AddressType,
                                    rowguid = x.rowguid
                                }
            );
                //EmailAddress == this.HttpContext.User.Identity.Name
            return View(customerAddresses);
        }

        public ActionResult EditAddress(Guid rowguid)
        {
            var address = new AddressViewModel();
            var customeraddress = repository.CustomerAddresses.SingleOrDefault(x => x.rowguid == rowguid);
            if (customeraddress == null) return RedirectToAction("Addresses");
            address.AddressType = customeraddress.AddressType;
            address.Address = customeraddress.Address;
            address.rowguid = rowguid;
            return View(address);
        }
        [HttpPost]
        public ActionResult EditAddress(AddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                var address = repository.Addresses.SingleOrDefault(x => x.AddressID == model.Address.AddressID) ?? model.Address;
                if (address.CustomerAddresses == null)
                {
                    var customer = repository.Customers.SingleOrDefault(x => x.EmailAddress == this.HttpContext.User.Identity.Name);//x.CustomerID == 29559);  //EmailAddress == this.HttpContext.User.Identity.Name
                    if (customer == null) return RedirectToAction("LogOn", "Account");
                    model.Address.CustomerAddresses = new Collection<CustomerAddress>();
                    model.Address.CustomerAddresses.Add(new CustomerAddress()
                                                            {
                                                                AddressID = model.Address.AddressID,
                                                                CustomerID = customer.CustomerID,
                                                                AddressType = model.AddressType
                                                            });
                }
                else
                {
                    var customeraddress = address.CustomerAddresses.SingleOrDefault(x => x.rowguid == model.rowguid);
                    if (customeraddress !=null) customeraddress.AddressType = model.AddressType;
                    repository.Save(customeraddress);
                }
                repository.Save(model.Address);
                return RedirectToAction("Addresses");
            }
            return View(model);
        }
        public ActionResult CreateAddress()
        {
            return View("EditAddress", new AddressViewModel());
        }

        [HttpPost]
        public ActionResult DeleteAddress(Guid rowguid)
        {
            var address = repository.Addresses.SingleOrDefault(x=>x.rowguid == rowguid);
                if (address != null)
                    if (address.CustomerAddresses != null) address.CustomerAddresses.Clear();
                try
                {
                    repository.Delete(address);
                    TempData["customer_message"] = "Address has been deleted.";
                }
                catch (Exception ex)
                {
                    TempData["customer_message"] = "Error ocured deleting address.";
                    return View("EditAddress", address);
                }
            return RedirectToAction("Addresses");
        }
    }
}
