﻿using System;
using System.Linq;
using System.Xml.Linq;

namespace ikSharp.Models.Link
{
	public class Visual
	{
		public Geometry Geometry { get; set; }
		public Material Material { get; set; }
		public string Name { get; set; }
		public Origin Origin { get; set; }

		public Visual(XElement node)
		{
			Name = (string) node.Attribute("name"); // optional
			Origin = node.Element("origin") != null ? new Origin(node.Element("origin")) : null; // optional
			Geometry = new Geometry(node.Element("geometry")); // required
			Material = node.Element("material") != null ? new Material(node.Element("material")) : null; // optional
		}
	}
}