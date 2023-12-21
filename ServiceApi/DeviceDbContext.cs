using ManagementCentral.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace DeviceApi
{
    public class DeviceDbContext : DbContext
    {
        public DeviceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Device>? Device { get; set; } = null!;
        public DbSet<City>? Location { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed countries
            modelBuilder.Entity<City>().HasData(new City { CityId = 1, Name = "Suzhou" });
            modelBuilder.Entity<City>().HasData(new City { CityId = 2, Name = "Hangzhou" });
            modelBuilder.Entity<City>().HasData(new City { CityId = 3, Name = "Nanjing" });
            modelBuilder.Entity<City>().HasData(new City { CityId = 4, Name = "Seoul" });
            modelBuilder.Entity<City>().HasData(new City { CityId = 5, Name = "Busan" });
            modelBuilder.Entity<City>().HasData(new City { CityId = 6, Name = "Harbin" });
            modelBuilder.Entity<City>().HasData(new City { CityId = 7, Name = "Changsha" });
            modelBuilder.Entity<City>().HasData(new City { CityId = 8, Name = "Jeju" });
            modelBuilder.Entity<City>().HasData(new City { CityId = 9, Name = "Incheon" });

            modelBuilder.Entity<Device>().HasData(new Device
            {
                DeviceId = 1,
                CityId = 1,
                Date = new DateTime(2015, 3, 1), 
                Type = "Weather Sensor",
                Status = Status.Online
            });

            modelBuilder.Entity<Device>().HasData(new Device
            {
                DeviceId = 2,
                CityId = 2,
                Date = new DateTime(2023, 4, 5),
                Type = "Weather Sensor",
                Status = Status.Offline
            });

            modelBuilder.Entity<Device>().HasData(new Device
            {
                DeviceId = 3,
                CityId = 3,
                Date = new DateTime(2021, 9, 1),
                Type = "Weather Sensor",
                Status = Status.Online
            });

            modelBuilder.Entity<Device>().HasData(new Device
            {
                DeviceId = 4,
                CityId = 4,
                Date = new DateTime(2022, 11, 14),
                Type = "Weather Sensor",
                Status = Status.Offline
            });
        }
    }
}
