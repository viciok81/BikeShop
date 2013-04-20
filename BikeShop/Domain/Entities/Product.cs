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

        private int? _productCategoryId;
        [HiddenInput(DisplayValue = false)]
        public int? ProductCategoryID
        {
            get { return this._productCategoryId; }
            set { 
                this._productCategoryId = value; 
                if(value.HasValue)
                {
                    using (var db =new EfDbContext())
                    {
                        this.ProductCategory = db.ProductCategories.SingleOrDefault(x => x.ProductCategoryID == value.Value);
                    }
                }
            }
        }
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
        public virtual ProductCategory ProductCategory { get; set; }
       // public virtual ProductModel ProductModel { get; set; }
       // public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
