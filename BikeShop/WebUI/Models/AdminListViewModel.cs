using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUI.Models
{
    public class AdminListViewModel
    {
        public IEnumerable<ProductCategory> ProductCategorys { get; set; } 
        public PagingInfo PagingInfo { get; set; }
    }
}