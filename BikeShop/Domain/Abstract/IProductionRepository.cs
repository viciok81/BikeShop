using System.Linq;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IProductionRepository
    {
       
        IQueryable<Address> Addresses { get; }
        IQueryable<Customer> Customers { get; }
        IQueryable<CustomerAddress> CustomerAddresses { get; }
        IQueryable<Product> Products { get; }
        IQueryable<ProductCategory> ProductCategories { get; }
        IQueryable<ProductDescription> ProductDescriptions { get; }
        IQueryable<ProductModel> ProductModels { get;}
        IQueryable<ProductModelProductDescription> ProductModelProductDescriptions { get; }
        IQueryable<SalesOrderDetail> SalesOrderDetails { get; }
        IQueryable<SalesOrderHeader> SalesOrderHeaders { get; }

        //void Save(Customer value);
        //void Save(Product value);
        //void Save(Address value);
        void Save<T>(T value) where T : BikeShopEntity;

        void Delete<T>(T value) where T : BikeShopEntity;
        //void Delete(Product value);
        //void Delete(Address value);

        IQueryable<CartItem> CartItems { get; }
    }
}
