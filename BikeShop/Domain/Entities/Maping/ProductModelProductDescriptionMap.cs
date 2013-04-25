using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Entities.Maping
{
    public class ProductModelProductDescriptionMap : EntityTypeConfiguration<ProductModelProductDescription>
    {
        public ProductModelProductDescriptionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ProductModelID, t.ProductDescriptionID, t.Culture });

            // Properties
            this.Property(t => t.ProductModelID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ProductDescriptionID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Culture)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(6);

            // Table & Column Mappings
            this.ToTable("ProductModelProductDescription", "SalesLT");
            this.Property(t => t.ProductModelID).HasColumnName("ProductModelID");
            this.Property(t => t.ProductDescriptionID).HasColumnName("ProductDescriptionID");
            this.Property(t => t.Culture).HasColumnName("Culture");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.ProductDescription)
                .WithMany(t => t.ProductModelProductDescriptions)
                .HasForeignKey(d => d.ProductDescriptionID);
            this.HasRequired(t => t.ProductModel)
                .WithMany(t => t.ProductModelProductDescriptions)
                .HasForeignKey(d => d.ProductModelID);

        }
    }
}
