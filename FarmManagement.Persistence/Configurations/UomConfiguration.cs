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
    public class UomConfiguration : IEntityTypeConfiguration<UOM>
    {
        public void Configure(EntityTypeBuilder<UOM> builder)
        {
            // Column Attributes
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.UnitOfMeasure).IsRequired();
            builder.Property(p => p.SiteId).IsRequired();

            // Concrete Relationships
            builder.HasOne(x => x.SiteMaster)
                .WithMany(x => x.UOMs)
                .HasForeignKey(x => x.SiteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
