using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
     [Table("ProductCategory", Schema = "SalesLT")]
    public partial class ProductCategory
    {
        //public ProductCategory()
        //{
        //    this.Products = new List<Product>();
        //    this.ProductCategory1 = new List<ProductCategory>();
        //}

        [Key]
        public int ProductCategoryID { get; set; }

        [ForeignKey("ProductCategory2")]
        public int? ParentProductCategoryID { get; set; }
        public string Name { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("ProductCategory")]
        public virtual ICollection<Product> Products { get; set; }
        
        [InverseProperty("ProductCategory2")]
        public virtual ICollection<ProductCategory> ProductCategory1 { get; set; }
        [InverseProperty("ProductCategory1")]
        public virtual ProductCategory ProductCategory2 { get; set; }
    }
}
