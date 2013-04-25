using System;
using Domain.Entities;

namespace WebUI.Models
{
    public class AddressesListModel
    {
        public string AddressType { get; set; }
        public Address Address { get; set; }
        public Customer Customer { get; set; }
        public Guid rowguid { get; set; }
    }
}