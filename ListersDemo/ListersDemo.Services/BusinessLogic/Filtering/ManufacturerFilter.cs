using ListersDemo.API.Common;
using ListersDemo.API.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic;
using System.Linq;
using System.Text;

namespace ListersDemo.Services.BusinessLogic.Filtering
{
    public class ManufacturerFilter : IManufacturerFilter
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public IEnumerable<Vehicle> Filter(IEnumerable<Vehicle> vehicles, Manufacturer manufacturer)
        {
            var response = new List<Vehicle>();           

            foreach (var property in manufacturer.GetType().GetProperties())
            {
                if ((bool)property.GetValue(manufacturer))
                {
                    try
                    {
                        response.AddRange(vehicles.Where(x => x.Manufacturer.ToUpper() != null &&
                        x.Manufacturer.ToUpper() == property.Name.ToUpper()));
                    }
                    catch (Exception e)
                    {
                        _logger.Error(e, "Error filtering manufacturer");
                    }
                }
            };
            return response;            
        }

    }
}
