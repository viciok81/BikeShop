using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Maping;

namespace Domain.Concrete
{
    public class EfDbContext:DbContext
    {
        static EfDbContext()
        {
            //Database.Initialize(true);
            //Database.SetInitializer<EfDbContext>(null);
            //Database.SetInitializer<EfDbContext>(true);
            Database.SetInitializer<EfDbContext>(new CreateDatabaseIfNotExists<EfDbContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfDbContext>());
        }
        //public EfDbContext() :base ()
        //{
           
        //}

        
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
        public DbSet<CartItem> CartItems { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new CustomerAddressMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductCategoryMap());
            modelBuilder.Configurations.Add(new ProductDescriptionMap());
            modelBuilder.Configurations.Add(new ProductModelMap());
            modelBuilder.Configurations.Add(new ProductModelProductDescriptionMap());
            modelBuilder.Configurations.Add(new SalesOrderDetailMap());
            modelBuilder.Configurations.Add(new SalesOrderHeaderMap());
            modelBuilder.Configurations.Add(new CartItemMap());
            
        }
       
    }
}
