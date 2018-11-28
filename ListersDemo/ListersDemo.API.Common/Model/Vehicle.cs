using System;
using System.Collections.Generic;
using System.Text;

namespace ListersDemo.API.Common

{
    public class Vehicle
    {
        public string Id { get; set; }
        public string Registration { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string DerivativeOrVariant { get; set; }
        public string ExteriorColour { get; set; }
        public decimal CurrentMileage { get; set; }
        public decimal RetailPrice { get; set; }
    }
}
