using FarmManagement.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmManagement.Persistence.Configurations
{
    public class ItemMasterConfiguration : IEntityTypeConfiguration<ItemMaster>
    {
        public void Configure(EntityTypeBuilder<ItemMaster> builder)
        {
            // Column Attributes
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.SiteId).IsRequired();
            builder.Property(p => p.ItemNo).IsRequired();
            builder.Property(p => p.ItemType).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.UnitOfMeasure).IsRequired();

            // Specific Data Type and Precision
            builder.Property(p => p.ItemNo).HasColumnType("nvarchar(20)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(50)");
            builder.Property(p => p.ItemType).HasColumnType("nvarchar(20)");
            builder.Property(p => p.UnitOfMeasure).HasColumnType("nvarchar(10)");
            builder.Property(p => p.UnitPrice).HasPrecision(9, 2);
            builder.Property(p => p.LastPurchasedPrice).HasPrecision(9, 2);

            // Default Value
            builder.Property(p => p.DateCreated).HasDefaultValueSql("getdate()");
            builder.Property(p => p.DateModified).HasDefaultValueSql("getdate()");
        }
    }
}
