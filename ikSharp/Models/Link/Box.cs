using System;
using ikSharp.Extensions;
using System.Linq;
using System.Xml.Linq;

namespace ikSharp.Models.Link
{
	public class Box
	{
		public double[] Size { get; set; }

		public Box(XElement node)
		{
			Size = node.Attribute("size") != null ? node.Attribute("size").ReadDoubleArray() : null;
		}
	}
}