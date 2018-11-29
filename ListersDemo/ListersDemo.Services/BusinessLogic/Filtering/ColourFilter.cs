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
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public IEnumerable<Vehicle> Filter(IEnumerable<Vehicle> vehicles, Colour colour)
        {
            var response = new List<Vehicle>();

            foreach (var property in colour.GetType().GetProperties())
            {
                if ((bool)property.GetValue(colour))
                {
                    try
                    {
                        response.AddRange(vehicles.Where(x => x.ExteriorColour.ToUpper() == property.Name.ToUpper()));
                    }
                    catch (Exception e)
                    {
                        _logger.Error(e, "Error filtering colour");
                    }
                }
            };
            return response;
        }
    }
}
