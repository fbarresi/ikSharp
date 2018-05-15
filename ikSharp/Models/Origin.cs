using System;
using System.Linq;
using System.Xml.Linq;
using ikSharp.Extensions;

namespace ikSharp.Models
{
    public class Origin
    {
        public double[] Xyz { get; set; }
        public double[] Rpy { get; set; }

        public Origin(XElement node)
        {
            Xyz = node.Attribute("xyz") != null ? node.Attribute("xyz").ReadDoubleArray() : null;
            Rpy = node.Attribute("rpy") != null ? node.Attribute("rpy").ReadDoubleArray() : null;
        }

    }
}
