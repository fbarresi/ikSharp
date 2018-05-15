using System;
using ikSharp.Extensions;
using System.Linq;
using System.Xml.Linq;

namespace ikSharp.Models.Joint
{
	public class Axis
	{
		public Axis(XElement node)
		{
			Xyz = node.Attribute("xyz") != null ? node.Attribute("xyz").ReadDoubleArray() : null;
		}

		public double[] Xyz { get; set; }
	}
}