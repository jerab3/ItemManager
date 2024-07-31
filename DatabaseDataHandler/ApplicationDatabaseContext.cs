using Domains.AbstractDomains;
using Domains.Accessories;
using Domains.Locations;
using Domains.Vendors;
using Interfaces.DomainProperties;
using Interfaces.Vendor;
using Microsoft.EntityFrameworkCore;
using Objects.Items;
using System.Diagnostics.CodeAnalysis;

namespace DatabaseDataHanding
{
    internal class ApplicationDatabaseContext : DbContext
    {
        public DbSet<StorageLocation> StorageLocations { get; set; }
        public DbSet<StorableAccessory> StorableAccessories { get; set; }
        public DbSet<UsableStoreableAccessory> UsableStoreableAccessories { get; set; }
        public DbSet<Eshop> Eshops { get; set; }
        public DbSet<PhysicalStore> PhysicalStores { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<WarrantyItem> WarrantyItems {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-7N9JRDL\\MSSQLSERVER01;Database=ItemManager;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region StorageLocation
            modelBuilder.Entity<StorageLocation>()
                .HasKey(sl => sl.Id);

            modelBuilder.Entity<StorageLocation>()
                .Property(sl => sl.Name)
                .IsRequired();
            #endregion

        }
    }
}
