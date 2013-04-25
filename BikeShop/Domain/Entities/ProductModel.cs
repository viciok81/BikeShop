using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public partial class ProductModel : BikeShopEntity
    {
        //public ProductModel()
        //{
        //    this.Products = new List<Product>();
        //    this.ProductModelProductDescriptions = new List<ProductModelProductDescription>();
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductModelID { get; set; }
        public string Name { get; set; }
        public string CatalogDescription { get; set; }
        //public System.Guid rowguid { get; set; }
        //public System.DateTime ModifiedDate { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }
    }
}
