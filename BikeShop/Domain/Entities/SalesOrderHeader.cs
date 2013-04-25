using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Domain.Entities
{
    [Table("SalesOrderHeader", Schema = "SalesLT")]
    public partial class SalesOrderHeader :BikeShopEntity
    {
        [Key]
        [HiddenInput(DisplayValue = false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesOrderID { get; set; }
        public byte RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public byte Status { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public string SalesOrderNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string AccountNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
  //      [ForeignKey("Customer")]
        public int CustomerID { get; set; }

  //      [ForeignKey("Address")]
        [HiddenInput(DisplayValue = false)]
        public int? ShipToAddressID { get; set; }

    //    [ForeignKey("Address1")]
        [HiddenInput(DisplayValue = false)]
        public int? BillToAddressID { get; set; }

        public string ShipMethod { get; set; }
        public string CreditCardApprovalCode { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public string Comment { get; set; }
//        [InverseProperty("SalesOrderHeaders")]
        public virtual Address Address { get; set; }
//        [InverseProperty("SalesOrderHeaders1")]
        public virtual Address Address1 { get; set; }
 //       [InverseProperty("SalesOrderHeaders")]
        public virtual Customer Customer { get; set; }
 //       [InverseProperty("SalesOrderHeader")]
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
