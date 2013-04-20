using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            this.Products = new List<Product>();
            this.ProductCategory1 = new List<ProductCategory>();
        }

        [Key]
        public int ProductCategoryID { get; set; }
        public int? ParentProductCategoryID { get; set; }
        public string Name { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductCategory> ProductCategory1 { get; set; }
        public virtual ProductCategory ProductCategory2 { get; set; }
    }
}
