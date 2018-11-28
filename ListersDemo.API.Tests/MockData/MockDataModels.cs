using ListersDemo.API.Common;
using ListersDemo.API.Common.Model;
using ListersDemo.API.DataContracts.Requests;
using System.Collections.Generic;

namespace ListersDemo.API.Tests.MockData
{
    public static class MockDataModels
    {
        public static Vehicle MockVehicleData()
        {
            return new Vehicle
            {
                Id = "0",
                CurrentMileage = 10000,
                ExteriorColour = "Red",
                DerivativeOrVariant = "Petrol Hatchback",
                Manufacturer = "Ford",
                Model = "Fiesta",
                Registration = "DF11 SMR",
                RetailPrice = 34000
            };
        }

        public static VehicleRequest MockVehicleRequest()
        {
            return new VehicleRequest()
            {
                ReverseResults = false,
                SearchValue = null,
                SortBy = null
            };
        }
        

        public static IEnumerable<Vehicle> MockVehicleDataList()
        {
            return new List<Vehicle>()
            {
                new Vehicle {
                    Id = "0",
                    CurrentMileage = 10000,
                    ExteriorColour = "Red",
                    DerivativeOrVariant = "Petrol Hatchback",
                    Manufacturer = "Ford",
                    Model = "Fiesta",
                    Registration = "DF11 SMR",
                    RetailPrice = 34000
                },
                new Vehicle {
                    Id = "2",
                    CurrentMileage = 1042000,
                    ExteriorColour = "Silver",
                    DerivativeOrVariant = "Petrol 5 door",
                    Manufacturer = "Porche",
                    Model = "911",
                    Registration = "DW51 CSR",
                    RetailPrice = 210000
                },
                new Vehicle {
                    Id = "3",
                    CurrentMileage = 560000,
                    ExteriorColour = "White",
                    DerivativeOrVariant = "Petrol 2 door",
                    Manufacturer = "Ferrari",
                    Model = "F40",
                    Registration = "HA61 WDG",
                    RetailPrice = 30000
                },
                new Vehicle {
                    Id = "4",
                    CurrentMileage = 410000,
                    ExteriorColour = "Red",
                    DerivativeOrVariant = "Petrol 5 door",
                    Manufacturer = "Fiat",
                    Model = "Uno",
                    Registration = "EZ71 HGD",
                    RetailPrice = 122400
                },
                new Vehicle {
                    Id = "5",
                    CurrentMileage = 310000,
                    ExteriorColour = "Yellow",
                    DerivativeOrVariant = "Petrol 5 door",
                    Manufacturer = "Fiat",
                    Model = "500",
                    Registration = "QF56 WER",
                    RetailPrice = 403000
                }

            };
        }

        public static Colour MockColourModel()
        {
            return new Colour()
            {
                Red = true,
                Blue = true,
                Black = true,
                Orange = false,
                Silver = false,
                White = false,
                Yellow = false
            };
        }

        public static Manufacturer MockManufacturerModel()
        {
            return new Manufacturer()
            {
                Ferrari=true,
                Fiat=false,
                Ford=true,
                Kia=true,
                Nissan=false,
                Porche=false,
                Vauxhall=false
            };
        }
    }
}