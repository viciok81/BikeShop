﻿using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EfProductionRepository :IProductionRepository
    {
        private  EfDbContext context = new EfDbContext();
        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }

        public IQueryable<BuildVersion> BuildVersions
        {
            get { return context.BuildVersions; }
        }

        public IQueryable<ErrorLog> ErrorLogs
        {
            get { return context.ErrorLogs; }
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
            get{ return context.ProductModels;}
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

        public IQueryable<VProductAndDescription> VProductAndDescriptions
        {
            get { return context.VProductAndDescriptions; }
        }

        public void Save(Product value)
        {
            context.Entry(value).State = value.ProductID == 0 ? EntityState.Added : EntityState.Modified;
            if (context.Entry(value).State == EntityState.Modified)
            {
                value.ModifiedDate = DateTime.Now;
            }
            context.SaveChanges();
        }

        public void Save(Customer value)
        {
            
            value.ModifiedDate = DateTime.Now;
            if (value.CustomerID == 0)
            {
                context.Entry(value).State = EntityState.Added;//value.CustomerID == 0 ? EntityState.Added : EntityState.Modified;
                value.NameStyle = false;
                value.rowguid = Guid.NewGuid();
            }
            else
            {
                var oldvalue = context.Customers.SingleOrDefault(x => x.CustomerID == value.CustomerID);
                context.Entry(oldvalue).CurrentValues.SetValues(value);
            }
            context.SaveChanges();
        }
        public void Delete(Product value)
        {
            context.Products.Remove(value);
            context.SaveChanges();
        }


    }
}
