using System;
using System.Linq;
using System.Xml.Linq;

namespace ikSharp.Models.Link
{
	public class Sphere
	{
		public double Radius { get; set; }

		public Sphere(XElement node)
		{
			Radius = (double) node.Attribute("radius");
		}
	}
}