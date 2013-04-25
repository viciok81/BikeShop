using System.Collections.Generic;
using Domain.Entities;
using WebUI.Infrastructure.Concrete;

namespace WebUI.Models
{
    public class CartViewModel
    {
        //public Cart Cart { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
        //public SalesOrderHeader SalesOrderHeader { get; set; }
        public string ReturnUrl { get; set; }
    }
}