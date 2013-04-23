using System.Linq;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IProductionRepository
    {
        IQueryable<BuildVersion> BuildVersions { get; }
        IQueryable<ErrorLog> ErrorLogs { get; }
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
        IQueryable<VProductAndDescription> VProductAndDescriptions { get; }

        void Save(Customer value);
        void Save(Product value);
        void Save(Address value);

        void Delete(Product value);
        void Delete(Address value);

    }
}
