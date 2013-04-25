using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Domain.Entities
{
    [Table("SalesOrderDetail", Schema = "SalesLT")]
    public partial class SalesOrderDetail : BikeShopEntity
    {
       // [ForeignKey("SalesOrderHeader")]
        [HiddenInput(DisplayValue = false)]
        public int SalesOrderID { get; set; }
        [Key]
        [HiddenInput(DisplayValue = false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesOrderDetailID { get; set; }
        public short OrderQty { get; set; }
        [HiddenInput(DisplayValue = false)]
   //     [ForeignKey("Product")]
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
  //      [InverseProperty("SalesOrderDetails")]
        public virtual Product Product { get; set; }
   //     [InverseProperty("SalesOrderDetails")]
        public virtual SalesOrderHeader SalesOrderHeader { get; set; }
    }
}
