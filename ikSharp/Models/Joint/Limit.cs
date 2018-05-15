using System;
using System.Linq;
using System.Xml.Linq;
using ikSharp.Extensions;

namespace ikSharp.Models.Joint
{
	public class Limit
	{
		public double? Lower { get; set; }
		public double? Upper { get; set; }
		public double Effort { get; set; }
		public double Velocity { get; set; }

		public Limit(XElement node)
		{
			Lower = node.Attribute("lower").ReadOptionalDouble(); // optional
			Upper = node.Attribute("upper").ReadOptionalDouble(); // optional
			Effort = (double) node.Attribute("effort"); // required
			Velocity = (double) node.Attribute("velocity"); // required
		}
	}

}