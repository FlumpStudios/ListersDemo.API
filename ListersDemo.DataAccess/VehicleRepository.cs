using ListersDemo.API.EfContext;
using ListersDemo.API.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

using System.Threading.Tasks;
using ListersDemo.API.DataContracts.Requests;

namespace ListersDemo.DataAccess
{
    public class VehicleRepository : IVehicleRepository, IDisposable
    {
        private readonly ListersDemoAPIContext _context;

        public VehicleRepository(ListersDemoAPIContext context)
        {
            _context = context;
        }

        public IEnumerable<Vehicle> GetAllVehicles() => _context.VehicleDbSet;

        public Task<Vehicle> GetVehicleById(string id) => _context.VehicleDbSet.FindAsync(id);

        public void AddVechicle(Vehicle vehicle) => _context.VehicleDbSet.Add(vehicle);

        public void UpdateVechicle(Vehicle vehicle) => _context.Entry(vehicle).State = EntityState.Modified;

        public void DeleteVehicle(string id) => _context.VehicleDbSet.Remove(_context.VehicleDbSet.Find(id));

        public bool VehicleExists(string id) => _context.VehicleDbSet.ToList().Any(e => e.Id == id);

        public void Save() => _context.SaveChanges();

        public void SaveAsync() => _context.SaveChangesAsync();

        public IEnumerable<Vehicle> GetSearchedResults(VehicleRequest request)
        {
            if (request.SearchValue == null) request.SearchValue = "";

            IQueryable<Vehicle> result = _context.VehicleDbSet.
                  Where(x => x.Manufacturer.ToUpper().Contains(request.SearchValue.ToUpper()) ||
                        x.Model.ToUpper().ToUpper().Contains(request.SearchValue.ToUpper()) ||
                        x.Registration.ToUpper().Contains(request.SearchValue.ToUpper()) ||
                        x.ExteriorColour.ToUpper().Contains(request.SearchValue.ToUpper()) ||
                        x.DerivativeOrVariant.ToUpper().Contains(request.SearchValue.ToUpper()));
            return result;
        }

        #region Desturctor       
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }


}
