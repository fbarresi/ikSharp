using System;
using System.Linq;
using System.Xml.Linq;

namespace ikSharp.Models.Link
{
	public class Inertia
	{
		public double Ixx { get; set; }
		public double Ixy { get; set; }
		public double Ixz { get; set; }
		public double Iyy { get; set; }
		public double Iyz { get; set; }
		public double Izz { get; set; }

		public Inertia(XElement node)
		{
			Ixx = (double) node.Attribute("ixx");
			Ixy = (double) node.Attribute("ixy");
			Ixz = (double) node.Attribute("ixz");
			Iyy = (double) node.Attribute("iyy");
			Iyz = (double) node.Attribute("iyz");
			Izz = (double) node.Attribute("izz");
		}
	}
}