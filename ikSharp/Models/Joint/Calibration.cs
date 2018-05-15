using System;
using ikSharp.Extensions;
using System.Linq;
using System.Xml.Linq;

namespace ikSharp.Models.Joint
{
	public class Calibration
	{
		public double? Falling { get; set; }
		public double? Rising { get; set; }

		public Calibration(XElement node)
		{
			Rising = node.Attribute("rising").ReadOptionalDouble(); // optional
			Falling = node.Attribute("falling").ReadOptionalDouble(); // optional
		}
	}
}