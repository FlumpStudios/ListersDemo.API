using ListersDemo.API.Common;
using Microsoft.EntityFrameworkCore;

namespace ListersDemo.API.EfContext


{
    public class ListersDemoAPIContext : DbContext
    {
        public ListersDemoAPIContext (DbContextOptions<ListersDemoAPIContext> options)
            : base(options)
        {
        }     

        public DbSet<Vehicle> VehicleDbSet { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle {Id="0", CurrentMileage = 10000, ExteriorColour = "Red", DerivativeOrVariant = "Petrol Hatchback", Manufacturer = "Ford", Model = "Fiesta", Registration = "DF11 SMR", RetailPrice = 34000 });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle { Id = "1", CurrentMileage = 146000, ExteriorColour = "Blue", DerivativeOrVariant = "Diesel 5 door", Manufacturer = "Kia", Model = "Sportage", Registration = "GG31 DAG", RetailPrice = 120500 });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle { Id = "2" , CurrentMileage = 1042000, ExteriorColour = "Silver", DerivativeOrVariant = "Petrol 5 door", Manufacturer = "Porche", Model = "911", Registration = "DW51 CSR", RetailPrice = 210000 });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle { Id = "3", CurrentMileage = 560000, ExteriorColour = "White", DerivativeOrVariant = "Petrol 2 door", Manufacturer = "Ferrari", Model = "F40", Registration = "HA61 WDG", RetailPrice = 30000 });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle { Id = "4",CurrentMileage = 410000, ExteriorColour = "Red", DerivativeOrVariant = "Petrol 5 door", Manufacturer = "Fiat", Model = "Uno", Registration = "EZ71 HGD", RetailPrice = 122400 });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle { Id = "5", CurrentMileage = 310000, ExteriorColour = "Yellow", DerivativeOrVariant = "Petrol 5 door", Manufacturer = "Fiat", Model = "500", Registration = "QF56 WER", RetailPrice = 403000 });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle { Id = "6", CurrentMileage = 150000, ExteriorColour = "Black", DerivativeOrVariant = "Petrol 5 door", Manufacturer = "Nissan", Model = "Micra", Registration = "HG54 FS", RetailPrice = 600000 });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle { Id = "7", CurrentMileage = 120000, ExteriorColour = "Blue", DerivativeOrVariant = "Diesel Saloon", Manufacturer = "Vauxhall", Model = "Astra", Registration = "VY53 DSG", RetailPrice = 900000 });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle { Id = "8", CurrentMileage = 10000, ExteriorColour = "Orange", DerivativeOrVariant = "Petrol 2 door", Manufacturer = "Ford", Model = "Fiesta", Registration = "SQ51 HFS", RetailPrice = 120000 });
        }
    }
}
