using System;

namespace ListersDemo.API.DataContracts.Requests
{
    public class VehicleRequest
    {
        public string SortBy { get; set; }

        public bool ReverseResults { get; set; }

        public string SearchValue { get; set; }
  
        public string FiltersJson { get; set; }
    }
}
