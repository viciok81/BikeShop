using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Entities.Maping
{
    public class CustomerAddressMap : EntityTypeConfiguration<CustomerAddress>
    {
        public CustomerAddressMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CustomerID, t.AddressID });

            // Properties
            this.Property(t => t.CustomerID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AddressID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AddressType)
                .IsRequired()
                .HasMaxLength(50);
            // Table & Column Mappings
            this.ToTable("CustomerAddress", "SalesLT");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.AddressID).HasColumnName("AddressID");
            this.Property(t => t.AddressType).HasColumnName("AddressType");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Address)
                .WithMany(t => t.CustomerAddresses)
                .HasForeignKey(d => d.AddressID);
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.CustomerAddresses)
                .HasForeignKey(d => d.CustomerID);

        }
    }
}
