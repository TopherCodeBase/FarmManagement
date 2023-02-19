using FarmManagement.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FarmManagement.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<SiteMaster> SiteMasters { get; set; }
        public DbSet<ItemMaster> ItemMasters { get; set; }
        public DbSet<MaterialMaster> MaterialMasters { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<UOM> UOMs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
