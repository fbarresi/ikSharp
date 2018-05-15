using System;
using System.Linq;
using System.Xml.Linq;
using ikSharp.Extensions;

namespace ikSharp.Models.Joint
{
	public class SafetyController
	{
		public double? SoftLowerLimit { get; set; }
		public double? SoftUpperLimit { get; set; }
		public double? KPosition { get; set; }
		public double? KVelocity { get; set; }
		public SafetyController(XElement node)
		{
			SoftLowerLimit = node.Attribute("soft_lower_limit").ReadOptionalDouble(); // optional
			SoftUpperLimit = node.Attribute("soft_upper_limit").ReadOptionalDouble(); // optional
			KPosition = node.Attribute("k_position").ReadOptionalDouble(); // optional
			KVelocity = node.Attribute("k_velocity").ReadOptionalDouble(); // required   
		}
	}
}