using FarmManagement.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Persistence.Configurations
{
    public class MaterialMasterConfiguration : IEntityTypeConfiguration<MaterialMaster>
    {
        public void Configure(EntityTypeBuilder<MaterialMaster> builder)
        {
            // Column Attributes
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.SiteId).IsRequired();
            builder.Property(p => p.ItemId).IsRequired();

            // Specific Data Type and Precision
            builder.Property(p => p.Quantity).HasPrecision(12, 4);
            builder.Property(p => p.Reference).HasColumnType("nvarchar(20)");
            builder.Property(p => p.Notes).HasColumnType("nvarchar(200)");
            builder.Property(p => p.PurchasedQuantity).HasPrecision(12, 4);
            builder.Property(p => p.PurchasedPrice).HasPrecision(9, 2);
            builder.Property(p => p.Status).HasColumnType("nvarchar(10)");

            // Default Value
            builder.Property(p => p.Id).HasDefaultValueSql("newid()");
            builder.Property(p => p.DateCreated).HasDefaultValueSql("getdate()");
            builder.Property(p => p.DateModified).HasDefaultValueSql("getdate()");

            builder.HasOne(x => x.SiteMaster)
                .WithMany(x => x.MaterialMasters)
                .HasForeignKey(x => x.SiteId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ItemMaster)
                .WithMany(x => x.MaterialMasters)
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
