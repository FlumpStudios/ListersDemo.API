using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListersDemo.API.Tests.TestHelpers
{
    public static class Helpers
    {
        public static bool CompareObject(object x, object y)
        {
            var xString = JsonConvert.SerializeObject(x);
            var yString = JsonConvert.SerializeObject(y);

            return string.Equals(xString, yString);
        }

        public static bool CompareCollection<T>(IEnumerable<T> x, IEnumerable<T> y)
        {
            var xString = JsonConvert.SerializeObject(x);
            var yString = JsonConvert.SerializeObject(y);

            return string.Equals(xString, yString);
        }
    }
}
