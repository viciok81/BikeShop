using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;

namespace WebUI.Models
{
    public class AddressViewModel
    {
        public Address Address { get; set; }
        
        [Required]
        [StringLength(50)]
        public string AddressType { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Guid rowguid { get; set; }
    }
}