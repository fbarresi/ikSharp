using System;
using System.Linq;
using System.Xml.Linq;

namespace ikSharp.Models.Link
{
	public class Texture
	{
		public string Filename { get; set; }

		public Texture(XElement node)
		{
			Filename = (string) node.Attribute("filename"); // required
		}
	}
}