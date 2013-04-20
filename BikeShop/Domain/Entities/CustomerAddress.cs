using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public partial class CustomerAddress
    {
        [Key]
        public int CustomerID { get; set; }
        
        public int AddressID { get; set; }
        public string AddressType { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
