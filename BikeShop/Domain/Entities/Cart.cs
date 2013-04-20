using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        private List<CartItem> _cart = new List<CartItem>();

        public void AddProduct(Product product, int quantity)
        {
            CartItem cartItem = _cart.FirstOrDefault(x => x.Product.ProductID == product.ProductID);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }else
            {
             _cart.Add(new CartItem{Product = product,Quantity = quantity});   
            }
        }
        public void RemoveProduct(Product product)
        {
            _cart.RemoveAll(x => x.Product.ProductID == product.ProductID);
        }
        public void Clear(){ _cart.Clear();}
        public IEnumerable<CartItem> Items
        {
            get { return _cart; }
        }
    }
}
