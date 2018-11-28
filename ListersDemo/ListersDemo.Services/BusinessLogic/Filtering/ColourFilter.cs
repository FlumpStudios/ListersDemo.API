using ListersDemo.API.Common;
using ListersDemo.API.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListersDemo.Services.BusinessLogic.Filtering
{
    public class ColourFilter : IColourFilter
    {
        public IEnumerable<Vehicle> Filter(IEnumerable<Vehicle> vehicles, Colour colour)
        {
            var response = new List<Vehicle>();

            foreach (var property in colour.GetType().GetProperties())
            {
                if ((bool)property.GetValue(colour))
                {
                    response.AddRange(vehicles.Where(x => x.ExteriorColour == property.Name));
                }
            };
            return response;
        }
    }
}
