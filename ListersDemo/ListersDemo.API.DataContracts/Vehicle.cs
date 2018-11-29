using System.ComponentModel.DataAnnotations;

namespace ListersDemo.API.DataContracts
{
    public class Vehicle
    {  
        public string Id { get; set; }

        [MaxLength(10)]
        public string Registration { get; set; }

        [Required]
        [MaxLength(30)]
        public string Manufacturer { get; set; }

        [MaxLength(30)]
        public string Model { get; set; }

        [MaxLength(30)]
        public string DerivativeOrVariant { get; set; }

        [MaxLength(30)]
        [Required]
        public string ExteriorColour { get; set; }

        public decimal CurrentMileage { get; set; }

        public decimal RetailPrice { get; set; }
    }
}
