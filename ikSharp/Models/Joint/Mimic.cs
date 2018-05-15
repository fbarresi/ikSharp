using System;
using System.Linq;
using System.Xml.Linq;
using ikSharp.Extensions;

namespace ikSharp.Models.Joint
{
	public class Mimic
	{
		public string Joint { get; set; }
		public double? Multiplier { get; set; }
		public double? Offset { get; set; }

		public Mimic(XElement node)
		{
			Joint = (string) node.Attribute("joint"); // required
			Multiplier = node.Attribute("multiplier").ReadOptionalDouble(); // optional
			Offset = node.Attribute("offset").ReadOptionalDouble(); // optional   
		}
	}

}