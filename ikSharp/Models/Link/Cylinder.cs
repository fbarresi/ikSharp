using System.Xml.Linq;

namespace ikSharp.Models.Link
{
	public class Cylinder
	{
		public double Radius { get; set; }
		public double Length { get; set; }

		public Cylinder(XElement node)
		{
			Radius = (double)node.Attribute("radius");
			Length = (double)node.Attribute("length");
		}
	}
}