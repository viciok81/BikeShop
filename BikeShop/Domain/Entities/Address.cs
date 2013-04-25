using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Domain.Entities
{
    [Table("Address", Schema = "SalesLT")]
    public partial class Address : BikeShopEntity
    {
       
        [Key]
        [HiddenInput(DisplayValue = false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressID { get; set; }
        [Required]
        [StringLength(60)]
        public string AddressLine1 { get; set; }
        [StringLength(60)]
        public string AddressLine2 { get; set; }
        [Required]
        [StringLength(30)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string StateProvince { get; set; }
        [Required]
        [StringLength(50)]
        public string CountryRegion { get; set; }
        [Required]
        [StringLength(15)]
        public string PostalCode { get; set; }
        [InverseProperty("Address")]
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        [InverseProperty("Address")]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
        [InverseProperty("Address1")]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders1 { get; set; }
    }
}
