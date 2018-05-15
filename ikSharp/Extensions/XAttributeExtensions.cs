using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace ikSharp.Extensions
{ 
    public static class XAttributeExtensions
    {
        public static double[] ReadDoubleArray(this XAttribute attribute)
        {
            return Array.ConvertAll(
                ((string)attribute).Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray(),
                i => Convert.ToDouble(i, CultureInfo.InvariantCulture));
        }

        public static double? ReadOptionalDouble(this XAttribute attribute)
        {
            return (double?)attribute;
        }
    }
}
