using System.Collections.Generic;
using System.Threading.Tasks;
using ListersDemo.API.Common;
using ListersDemo.API.DataContracts.Requests;

namespace ListersDemo.DataAccess
{
    public interface IVehicleRepository
    {
        void AddVechicle(Vehicle vehicle);
        Task<Vehicle> GetVehicleById(string id);
        IEnumerable<Vehicle> GetAllVehicles();
        void Save();
        void SaveAsync();
        void UpdateVechicle(Vehicle vehicle);
        bool VehicleExists(string id);
        void DeleteVehicle(string id);
        IEnumerable<Vehicle> GetSearchedResults(VehicleRequest request);
    }
}