using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public partial class ProductDescription : BikeShopEntity
    {
        public ProductDescription()
        {
            this.ProductModelProductDescriptions = new List<ProductModelProductDescription>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductDescriptionID { get; set; }
        public string Description { get; set; }
        //public System.Guid rowguid { get; set; }
        //public System.DateTime ModifiedDate { get; set; }
        public virtual ICollection<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }
    }
}
