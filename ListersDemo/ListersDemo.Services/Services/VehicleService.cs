using AutoMapper;
using ListersDemo.API.Common.Settings;
using ListersDemo.Services.Contracts;
using ListersDemo.API.Common;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using ListersDemo.DataAccess;
using System.Collections.Generic;
using ListersDemo.API.DataContracts.Requests;
using Newtonsoft.Json;
using ListersDemo.API.Common.Model;
using ListersDemo.Services.BusinessLogic.Filtering;
using ListersDemo.API.Common.Extensions;

namespace ListersDemo.Services
{
    public class VehicleService : IVehicleService
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        private readonly IManufacturerFilter _manufacturerFilter;
        private readonly IColourFilter _colourFilter;

        public VehicleService(IOptions<AppSettings> settings, 
            IMapper mapper, 
            IVehicleRepository vehicleRepository,
            IManufacturerFilter manufacturerFilter,
            IColourFilter colourFilter
            )
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
            _manufacturerFilter = manufacturerFilter;
            _colourFilter = colourFilter;
        }

        public Task<bool> Create(Vehicle vehicle)
        {
            try
            {
                _vehicleRepository.AddVechicle(vehicle);
                _vehicleRepository.SaveAsync();
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error adding record");
            }
            return Task.FromResult(true);
        }

        public IEnumerable<Vehicle> Get(VehicleRequest request)
        {
            Filters filters = null;
            try
            {
                 filters = JsonConvert.DeserializeObject<Filters>(request.FiltersJson);
            }
            catch(Exception e)
            {
                _logger.Error(e, "Error deserialising filters");
            }

            var Result = _vehicleRepository.GetSearchedResults(request);

            if (filters != null)
            { 
                Result = _manufacturerFilter.Filter(Result, filters.Manufacturer);
                Result = _colourFilter.Filter(Result, filters.Colour);
            }
         
            return Result.Sort(request.SortBy, request.ReverseResults);
        }

        public Task<bool> UpdateAsync(Vehicle vehicle)
        {
            try
            {
                _vehicleRepository.UpdateVechicle(vehicle);
                _vehicleRepository.SaveAsync();
            }
            catch(Exception e)
            {
                _logger.Error(e, "Error updating record");
                return Task.FromResult(false);
            }

            return Task.FromResult(true);

        }

        public Task<bool> DeleteAsync(string id)
        {
            if (!_vehicleRepository.VehicleExists(id)) return Task.FromResult(false);

            try
            {
                _vehicleRepository.DeleteVehicle(id);
                _vehicleRepository.SaveAsync();
            }
            catch(Exception e)
            {
                _logger.Error(e, "Error deleting record");
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<Vehicle> GetAsync(string id)
        {
            return _vehicleRepository.GetVehicleById(id);
        }
    }
}
