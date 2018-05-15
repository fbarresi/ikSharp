using System;
using ikSharp.Extensions;
using System.Linq;
using System.Xml.Linq;

namespace ikSharp.Models.Link
{
	public class Mesh
	{
		public string Filename { get; set; }
		public double[] Scale { get; set; }

		public Mesh(XElement node)
		{
			Filename = (string) node.Attribute("filename");
			Scale = node.Attribute("scale") != null ? node.Attribute("scale").ReadDoubleArray() : null;
		}
	}
}