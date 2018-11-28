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
        public IEnumerable<Vehicle> Filter(IEnumerable<Vehicle> vehicles, Manufacturer manufacturer)
        {
            var response = new List<Vehicle>();           

            foreach (var property in manufacturer.GetType().GetProperties())
            {
                if ((bool)property.GetValue(manufacturer))
                {
                    response.AddRange(vehicles.Where(x => x.Manufacturer == property.Name));
                }
            };
            return response;            
        }

    }
}
