using Microsoft.EntityFrameworkCore;
using SoilMatesDB.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SoilMatesDB
{
    public class SoilMatesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Manager> Managers { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!(optionsBuilder.IsConfigured))
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                var connectionString = configuration.GetConnectionString("SoilMatesDB");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>()
            .HasOne(e => e.Product)
            .WithMany(v => v.ProductLocations)
            .HasForeignKey(e => e.ProductForeingId);

            modelBuilder.Entity<Inventory>()
            .HasOne(e => e.Location)
            .WithMany(v => v.StoreProducts)
            .HasForeignKey(e => e.LocationForeignId);

            modelBuilder.Entity<OrderProduct>()
            .HasOne(e => e.Product)
            .WithMany(v => v.LineItem)
            .HasForeignKey(e => e.ProductForiegnId);

            modelBuilder.Entity<OrderProduct>()
            .HasOne(e => e.Order)
            .WithMany(v => v.LineItem)
            .HasForeignKey(e => e.OrderForiegnId);

        }
    }


}
