using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Domain.Entities
{
    [Table("CartItem", Schema = "SalesLT")]
    public class CartItem : BikeShopEntity
    {
        [Key]
        [HiddenInput(DisplayValue = false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartItemId { get; set; }

  //      [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
  //      [ForeignKey("Customer")]
        public int CustomerId { get; set; }

  //      [InverseProperty("CartItems")]
        public virtual Product Product { get; set; }
        
  //      [InverseProperty("CartItems")]
        public virtual Customer Customer { get; set; }
    }
}
