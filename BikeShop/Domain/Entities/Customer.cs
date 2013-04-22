using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Domain.Entities
{
    [Table("Customer", Schema = "SalesLT")]
    public partial class Customer
    {
        
        //public Customer()
        //{
        //    this.CustomerAddresses = new List<CustomerAddress>();
        ////    this.SalesOrderHeaders = new List<SalesOrderHeader>();
        //}
        [Key]
        [HiddenInput(DisplayValue = false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        [Required]
        public bool NameStyle { get; set; }
        [StringLength(8)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(10)]
        public string Suffix { get; set; }
        [StringLength(128)]
        public string CompanyName { get; set; }
        [StringLength(256)]
        public string SalesPerson { get; set; }
        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [StringLength(25)]
        public string Phone { get; set; }
        [Required]
        [StringLength(128)]
        [HiddenInput(DisplayValue = false)]
        public string PasswordHash { get; set; }
        [Required]
        [StringLength(10)]
        [HiddenInput(DisplayValue = false)]
        public string PasswordSalt { get; set; }
        [Required]
        [HiddenInput(DisplayValue = false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid rowguid { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        //public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}
