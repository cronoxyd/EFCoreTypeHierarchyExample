using EFCoreTypeHierarchyExample.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTypeHierarchyExample.Common.Data
{
    public class EFCoreTypeHierarchyExampleContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Truck> Trucks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("EFCoreTypeHierarchyExample");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Vehicle>()
                .Property(vehicle => vehicle.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<VehicleType>(v)
                );

            modelBuilder
                .Entity<Vehicle>()
                .UseTphMappingStrategy()
                .HasDiscriminator(vehicle => vehicle.Type)
                .HasValue<Car>(VehicleType.Car)
                .HasValue<Car>(VehicleType.Truck);

            modelBuilder.Entity<Car>().HasData(
                new Car { Name = "Golf 6", VehicleIdentificationNumber = "IUKDGHFKLSDFSD3123" },
                new Car { Name = "Chrysler Fifth Avenue", VehicleIdentificationNumber = "SDFKLDSHGSDFG241" }
            );

            modelBuilder.Entity<Truck>().HasData(
                new Truck { Name = "Mercedes Actros", VehicleIdentificationNumber = "DSKJFGHSDKGDFS231234"},
                new Truck { Name = "Iveco Stralis", VehicleIdentificationNumber = "HKLSDFBHDS389423"}
            );
        }
    }
}