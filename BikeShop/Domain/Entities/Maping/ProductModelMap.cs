using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Entities.Maping
{
    public class ProductModelMap : EntityTypeConfiguration<ProductModel>
    {
        public ProductModelMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductModelID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
            // Table & Column Mappings
            this.ToTable("ProductModel", "SalesLT");
            this.Property(t => t.ProductModelID).HasColumnName("ProductModelID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CatalogDescription).HasColumnName("CatalogDescription");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
