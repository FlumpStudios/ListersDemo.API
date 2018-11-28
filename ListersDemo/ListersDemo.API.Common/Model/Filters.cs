using System;
using System.Collections.Generic;
using System.Text;

namespace ListersDemo.API.Common.Model
{
    public class Filters
    {
        public Manufacturer Manufacturer { get; set; }

        public Colour Colour { get; set; }
    }

    public class Manufacturer
    {
        public bool Ford { get; set; }
        public bool Kia { get; set; }
        public bool Porche { get; set; }
        public bool Ferrari { get; set; }
        public bool Fiat { get; set; }
        public bool Nissan { get; set; }
        public bool Vauxhall { get; set; }
    }

    public class Colour
    {
        public bool Red { get; set; }
        public bool Blue { get; set; }
        public bool Silver { get; set; }
        public bool White { get; set; }
        public bool Yellow { get; set; }
        public bool Black { get; set; }
        public bool Orange { get; set; }
    }
}
