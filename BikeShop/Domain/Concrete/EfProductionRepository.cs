using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EfProductionRepository : IProductionRepository
    {
        private EfDbContext context = new EfDbContext();

        #region Get

        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }

        
        public IQueryable<Address> Addresses
        {
            get { return context.Addresses; }
        }

        public IQueryable<Customer> Customers
        {
            get { return context.Customers; }
        }

        public IQueryable<CustomerAddress> CustomerAddresses
        {
            get { return context.CustomerAddresses; }
        }

        public IQueryable<ProductCategory> ProductCategories
        {
            get { return context.ProductCategories; }
        }

        public IQueryable<ProductDescription> ProductDescriptions
        {
            get { return context.ProductDescriptions; }
        }

        public IQueryable<ProductModel> ProductModels
        {
            get { return context.ProductModels; }
        }

        public IQueryable<ProductModelProductDescription> ProductModelProductDescriptions
        {
            get { return context.ProductModelProductDescriptions; }
        }

        public IQueryable<SalesOrderDetail> SalesOrderDetails
        {
            get { return context.SalesOrderDetails; }
        }

        public IQueryable<SalesOrderHeader> SalesOrderHeaders
        {
            get { return context.SalesOrderHeaders; }
        }

        public IQueryable<CartItem> CartItems
        {
            get { return context.CartItems; }
        }
    

    #endregion

        public void Save<T>(T value) where T : BikeShopEntity
        {
            var oldvalue = context.Set<T>().SingleOrDefault(x => x.rowguid == value.rowguid);
            value.ModifiedDate = DateTime.Now;
            if (oldvalue != null)
            {
                context.Entry(oldvalue).CurrentValues.SetValues(value);
            }
            else
            {
                value.rowguid = Guid.NewGuid();
                context.Entry(value).State = EntityState.Added ;
            }
            context.SaveChanges();
        }

        public void Delete<T>(T value) where T : BikeShopEntity
        {
            context.Entry(value).State = EntityState.Deleted;
            context.SaveChanges();
        }

    }
}
