using System.Collections.Generic;
using ListersDemo.API.Common;
using ListersDemo.API.Common.Model;

namespace ListersDemo.Services.BusinessLogic.Filtering
{
    public interface IColourFilter
    {
        IEnumerable<Vehicle> Filter(IEnumerable<Vehicle> vehicles, Colour colour);
    }
}