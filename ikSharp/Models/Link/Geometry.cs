using System;
using System.Linq;
using System.Xml.Linq;

namespace ikSharp.Models.Link
{
	public class Geometry
	{
		public Box Box { get; set; }
		public Cylinder Cylinder { get; set; }
		public Mesh Mesh { get; set; }
		public Sphere Sphere { get; set; }

		public Geometry(XElement node)
		{
			Box = node.Element("box") != null ? new Box(node.Element("box")) : null; // optional  
			Cylinder = node.Element("cylinder") != null ? new Cylinder(node.Element("cylinder")) : null; // optional  
			Sphere = node.Element("sphere") != null ? new Sphere(node.Element("sphere")) : null; // optional  
			Mesh = node.Element("mesh") != null ? new Mesh(node.Element("mesh")) : null; // optional           
		}
	}
}