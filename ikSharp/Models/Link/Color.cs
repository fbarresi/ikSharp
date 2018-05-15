using System;
using ikSharp.Extensions;
using System.Linq;
using System.Xml.Linq;

namespace ikSharp.Models.Link
{
	public class Color
	{
		public double[] Rgba { get; set; }

		public Color(XElement node)
		{
			Rgba = node.Attribute("rgba").ReadDoubleArray(); // required
		}
	}
}