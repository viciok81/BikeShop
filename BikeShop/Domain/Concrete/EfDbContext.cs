using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EfDbContext:DbContext
    {
        static EfDbContext()
        {
            Database.SetInitializer<EfDbContext>(null);
        }

        public DbSet<BuildVersion> BuildVersions { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductDescription> ProductDescriptions { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        //public DbSet<vGetAllCategory> vGetAllCategories { get; set; }
        public DbSet<VProductAndDescription> VProductAndDescriptions { get; set; }
        //public DbSet<vProductModelCatalogDescription> vProductModelCatalogDescriptions { get; set; }
    }
}
