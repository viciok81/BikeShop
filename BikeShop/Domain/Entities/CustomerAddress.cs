using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("CustomerAddress", Schema = "SalesLT")]
    public partial class CustomerAddress : BikeShopEntity
    {
        [Key, Column(Order = 0)]
 //       [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        [Key, Column(Order = 1)]
 //       [ForeignKey("Address")]
        public int AddressID { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressType { get; set; }
          
 //       [InverseProperty("CustomerAddresses")]
        public virtual Address Address { get; set; }
        
 //       [InverseProperty("CustomerAddresses")]
        public virtual Customer Customer { get; set; }
    }
}
