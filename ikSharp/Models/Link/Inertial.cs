using System;
using System.Linq;
using System.Xml.Linq;

namespace ikSharp.Models.Link
{
	public class Inertial
	{
		public Inertia Inertia { get; set; }
	public double Mass { get; set; }
		public Origin Origin { get; set; }

		public Inertial(XElement node)
		{
			Origin = node.Element("origin") != null ? new Origin(node.Element("origin")) : null; // optional  
			Mass = (double) node.Element("mass").Attribute("value"); // required
			Inertia = new Inertia(node.Element("inertia")); // required
		}
	}
}