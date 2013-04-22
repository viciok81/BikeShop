using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("CustomerAddress", Schema = "SalesLT")]
    public partial class CustomerAddress
    {
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        
        public int AddressID { get; set; }
        public string AddressType { get; set; }
        [Key]
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual Address Address { get; set; }
        
        [InverseProperty("CustomerAddresses")]
        public virtual Customer Customer { get; set; }
    }
}
