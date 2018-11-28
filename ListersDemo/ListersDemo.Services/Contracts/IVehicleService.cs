using ListersDemo.API.Common;
using ListersDemo.API.DataContracts.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListersDemo.Services.Contracts
{
    public interface IVehicleService
    {
        IEnumerable<Vehicle> Get(VehicleRequest request);
        Task<bool> Create(Vehicle vehicle);

        Task<bool> UpdateAsync(Vehicle vehicle);

        Task<bool> DeleteAsync(string id);

        Task<Vehicle> GetAsync(string id);
    }
}
