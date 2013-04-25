using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public partial class ProductModelProductDescription : BikeShopEntity
    {
        [Key, Column(Order = 0)]
        public int ProductModelID { get; set; }
       [Key, Column(Order = 1)] 
        public int ProductDescriptionID { get; set; }
        public string Culture { get; set; }
        //public System.Guid rowguid { get; set; }
        //public System.DateTime ModifiedDate { get; set; }
        public virtual ProductDescription ProductDescription { get; set; }
        public virtual ProductModel ProductModel { get; set; }
    }
}
