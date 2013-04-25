using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Maping
{
    public class CartItemMap : EntityTypeConfiguration<CartItem>
    {
        public CartItemMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CartItemId});

            // Properties
            this.Property(t => t.CustomerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Quantity)
                .IsRequired();
            // Table & Column Mappings
            this.ToTable("CartItem", "SalesLT");
            this.Property(t => t.CartItemId).HasColumnName("CartItemId");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            this.HasRequired(t => t.Product)
                .WithMany(t => t.CartItems)
                .HasForeignKey(d => d.ProductId);
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.CartItems)
                .HasForeignKey(d => d.CustomerId);

        }
    }
}
