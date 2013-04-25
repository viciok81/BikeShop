using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Entities.Maping
{
    public class SalesOrderHeaderMap : EntityTypeConfiguration<SalesOrderHeader>
    {
        public SalesOrderHeaderMap()
        {
            this.HasKey(t => t.SalesOrderID);

            // Properties
            this.Property(t => t.SalesOrderNumber)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.PurchaseOrderNumber)
                .HasMaxLength(25);

            this.Property(t => t.AccountNumber)
                .HasMaxLength(15);

            this.Property(t => t.ShipMethod)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CreditCardApprovalCode)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("SalesOrderHeader", "SalesLT");
            this.Property(t => t.SalesOrderID).HasColumnName("SalesOrderID");
            this.Property(t => t.RevisionNumber).HasColumnName("RevisionNumber");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            this.Property(t => t.DueDate).HasColumnName("DueDate");
            this.Property(t => t.ShipDate).HasColumnName("ShipDate");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.OnlineOrderFlag).HasColumnName("OnlineOrderFlag");
            this.Property(t => t.SalesOrderNumber).HasColumnName("SalesOrderNumber");
            this.Property(t => t.PurchaseOrderNumber).HasColumnName("PurchaseOrderNumber");
            this.Property(t => t.AccountNumber).HasColumnName("AccountNumber");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.ShipToAddressID).HasColumnName("ShipToAddressID");
            this.Property(t => t.BillToAddressID).HasColumnName("BillToAddressID");
            this.Property(t => t.ShipMethod).HasColumnName("ShipMethod");
            this.Property(t => t.CreditCardApprovalCode).HasColumnName("CreditCardApprovalCode");
            this.Property(t => t.SubTotal).HasColumnName("SubTotal");
            this.Property(t => t.TaxAmt).HasColumnName("TaxAmt");
            this.Property(t => t.Freight).HasColumnName("Freight");
            this.Property(t => t.TotalDue).HasColumnName("TotalDue");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasOptional(t => t.Address)
                .WithMany(t => t.SalesOrderHeaders)
                .HasForeignKey(d => d.BillToAddressID);
            this.HasOptional(t => t.Address1)
                .WithMany(t => t.SalesOrderHeaders1)
                .HasForeignKey(d => d.ShipToAddressID);
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.SalesOrderHeaders)
                .HasForeignKey(d => d.CustomerID);

        }
    }
}
