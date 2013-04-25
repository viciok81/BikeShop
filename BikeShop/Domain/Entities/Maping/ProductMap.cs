using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Entities.Maping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ProductNumber)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.Color)
                .HasMaxLength(15);

            this.Property(t => t.Size)
                .HasMaxLength(5);

            this.Property(t => t.ThumbnailPhotoFileName)
                .HasMaxLength(50);


            // Table & Column Mappings
            this.ToTable("Product", "SalesLT");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ProductNumber).HasColumnName("ProductNumber");
            this.Property(t => t.Color).HasColumnName("Color");
            this.Property(t => t.StandardCost).HasColumnName("StandardCost");
            this.Property(t => t.ListPrice).HasColumnName("ListPrice");
            this.Property(t => t.Size).HasColumnName("Size");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.ProductCategoryID).HasColumnName("ProductCategoryID");
            this.Property(t => t.ProductModelID).HasColumnName("ProductModelID");
            this.Property(t => t.SellStartDate).HasColumnName("SellStartDate");
            this.Property(t => t.SellEndDate).HasColumnName("SellEndDate");
            this.Property(t => t.DiscontinuedDate).HasColumnName("DiscontinuedDate");
            this.Property(t => t.ThumbNailPhoto).HasColumnName("ThumbNailPhoto");
            this.Property(t => t.ThumbnailPhotoFileName).HasColumnName("ThumbnailPhotoFileName");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasOptional(t => t.ProductCategory)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.ProductCategoryID);
            this.HasOptional(t => t.ProductModel)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.ProductModelID);

        }
    }
}
