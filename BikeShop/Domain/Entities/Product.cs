using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Domain.Concrete;
using System.Linq;

namespace Domain.Entities
{
    [Table("Product", Schema = "SalesLT")]
    public partial class Product
    {
        //public Product()
        //{
        //    //this.SalesOrderDetails = new List<SalesOrderDetail>();
        //    var t = 1;
        //}
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public decimal? Weight { get; set; }
        [HiddenInput(DisplayValue = false)]

        [ForeignKey("ProductCategory")]
        public int? ProductCategoryID { get; set; }
        
        [HiddenInput(DisplayValue = false)]
        public int? ProductModelID { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        [HiddenInput(DisplayValue = false)]
        public byte[] ThumbNailPhoto { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ThumbnailPhotoFileName { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
         [InverseProperty("Products")]
        public virtual ProductCategory ProductCategory { get; set; }
       // public virtual ProductModel ProductModel { get; set; }
       // public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }

    }
}
