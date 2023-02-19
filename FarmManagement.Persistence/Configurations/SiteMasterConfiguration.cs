

using FarmManagement.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmManagement.Persistence.Configurations
{
    public class SiteMasterConfiguration : IEntityTypeConfiguration<SiteMaster>
    {
        public void Configure(EntityTypeBuilder<SiteMaster> builder)
        {
            // Column Attributes
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.SiteCode).IsRequired();
            builder.Property(p => p.SiteName).IsRequired();

            // Specific Data Type and Precision
            builder.Property(p => p.SiteCode).HasColumnType("nvarchar(20)");
            builder.Property(p => p.SiteName).HasColumnType("nvarchar(50)");
            builder.Property(p => p.Street).HasColumnType("nvarchar(50)");
            builder.Property(p => p.Zip).HasColumnType("nvarchar(20)");            
            builder.Property(p => p.Status).HasColumnType("nvarchar(20)");

            // Default Value
            builder.Property(p => p.Id).HasDefaultValueSql("newid()");
            builder.Property(p => p.DateCreated).HasDefaultValueSql("getdate()");
            builder.Property(p => p.DateModified).HasDefaultValueSql("getdate()");

            // Unique Constraint
            builder.HasIndex(p => p.SiteCode).IsUnique();
        }
    }
}
