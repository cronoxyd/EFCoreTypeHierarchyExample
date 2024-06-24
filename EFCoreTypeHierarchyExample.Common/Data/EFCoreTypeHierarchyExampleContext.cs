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
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFCoreTypeHierarchyExample;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Vehicle>()
                .Property(vehicle => vehicle.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<VehicleType>(v!)
                );

            modelBuilder
                .Entity<Vehicle>()
                .UseTphMappingStrategy()
                .HasDiscriminator(vehicle => vehicle.Type)
                .HasValue<Car>(VehicleType.Car)
                .HasValue<Truck>(VehicleType.Truck);

            modelBuilder.Entity<Car>().HasData(
                new Car { Id = Guid.NewGuid(), Name = "Golf 6", VehicleIdentificationNumber = "IUKDGHFKLSDFSD3123" },
                new Car { Id = Guid.NewGuid(), Name = "Chrysler Fifth Avenue", VehicleIdentificationNumber = "SDFKLDSHGSDFG241" }
            );

            modelBuilder.Entity<Truck>().HasData(
                new Truck { Id = Guid.NewGuid(), Name = "Mercedes Actros", VehicleIdentificationNumber = "DSKJFGHSDKGDFS231234"},
                new Truck { Id = Guid.NewGuid(), Name = "Iveco Stralis", VehicleIdentificationNumber = "HKLSDFBHDS389423"}
            );
        }
    }
}