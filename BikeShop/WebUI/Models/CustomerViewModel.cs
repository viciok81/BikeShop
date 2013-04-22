using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUI.Models
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        [Required(ErrorMessage = "Enter Old Password to confirm changes")]
        [DataType(DataType.Password)]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Enter New Password")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword")]
        public string RetypeNewPassword { get; set; }
    }
}