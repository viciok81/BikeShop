using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class CategoryWithParent
    {
        public int ProductCategoryID { get; set; }
        public string ParentProductCategoryName { get; set; }
        public string ProductCategoryName { get; set; }
        
    }
}