using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUI.Models
{
    public class ProductCategoryViewModel
    {
        public IEnumerable<CategoryWithParent> Categories { get; set; }
        public string CurrentCategory { get; set; }
    }
}