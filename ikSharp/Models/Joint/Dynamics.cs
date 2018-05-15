using System;
using ikSharp.Extensions;
using System.Linq;
using System.Xml.Linq;

namespace ikSharp.Models.Joint
{
	public class Dynamics
	{
		public double? Damping { get; set; }
		public double? Friction { get; set; }

		public Dynamics(XElement node)
		{
			Damping = node.Attribute("damping").ReadOptionalDouble(); // optional
			Friction = node.Attribute("friction").ReadOptionalDouble(); // optional
		}
	}
}