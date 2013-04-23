using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Domain.Entities
{
    [Table("Address", Schema = "SalesLT")]
    public partial class Address
    {
        //public Address()
        //{
        //    this.CustomerAddresses = new List<CustomerAddress>();
        ////    this.SalesOrderHeaders = new List<SalesOrderHeader>();
        ////    this.SalesOrderHeaders1 = new List<SalesOrderHeader>();
        //}

        [Key]
        [HiddenInput(DisplayValue = false)]
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
        [HiddenInput(DisplayValue = false)]
        public Guid rowguid { get; set; }
        [HiddenInput(DisplayValue = false)]
        public DateTime ModifiedDate { get; set; }
        [InverseProperty("Address")]
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        //public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
        //public virtual ICollection<SalesOrderHeader> SalesOrderHeaders1 { get; set; }
    }
}
