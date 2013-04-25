using System.Collections.Generic;
using System.Linq;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;


namespace WebUI.Infrastructure.Concrete
{
    public class Cart
    {
        //private IQueryable<CartItem> _cart;// = new List<CartItem>();
        private int customerId;

        private IProductionRepository repository;// = new EfProductionRepository();

        public Cart(string email, IProductionRepository _repository)
        {
            repository = _repository;
            var temp = repository.Customers.SingleOrDefault(x => x.EmailAddress == email);
            customerId = temp == null ? 0 : temp.CustomerID;
        }
        public IEnumerable<CartItem> Items
        {
            get
            {
                return repository.CartItems.Where(x => x.CustomerId == customerId).ToList();
            }
        }

        public void AddProduct(Product product, int quantity)
        {

            CartItem cartItem = repository.CartItems.FirstOrDefault(x => x.CustomerId == customerId && x.ProductId == product.ProductID);// cartItem = _cart.FirstOrDefault(x => x.Product.ProductID == product.ProductID);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cartItem = new CartItem { Quantity = quantity, CustomerId = customerId , ProductId = product.ProductID};
            }
            repository.Save(cartItem);
        }

        public void RemoveProduct(int cartItemID)
        {
            repository.Delete(repository.CartItems.SingleOrDefault(x => x.CartItemId == cartItemID));
        }
        public decimal ComputeTotalValue()
        {
            return this.Items.Sum(e => e.Product.StandardCost * e.Quantity);
        }

    }
}