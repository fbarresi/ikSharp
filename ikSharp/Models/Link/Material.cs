using System;
using System.Linq;
using System.Xml.Linq;

namespace ikSharp.Models.Link
{
	public class Material
	{
		public Material(XElement node)
		{
			Name = (string) node.Attribute("name"); // required
			Color = node.Element("color") != null ? new Color(node.Element("color")) : null; // optional  
			Texture = node.Element("texture") != null ? new Texture(node.Element("texture")) : null;
		}

		public Color Color { get; set; }
		public string Name { get; set; }
		public Texture Texture { get; set; }
	}
}