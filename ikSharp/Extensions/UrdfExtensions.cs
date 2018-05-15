using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ikSharp.Models;
using ikSharp.Models.Joint;
using ikSharp.Models.Link;

namespace ikSharp.Extensions
{
	public static class UrdfExtensions
	{
		public static List<Material> ReadMaterials(this XElement node)
		{
			var materials =
				from child in node.Elements("material")
				select new Material(child);
			return materials.ToList();
		}

		public static List<Link> ReadLinks(this XElement node)
		{
			var links =
				from child in node.Elements("link")
				select new Link(child);
			return links.ToList();
		}

		public static List<Joint> ReadJoints(this XElement node)
		{
			var joints =
				from child in node.Elements("joint")
				select new Joint(child);
			return joints.ToList();
		}

		public static List<Collision> ReadCollisions(this XElement node)
		{
			var collisions =
				from child in node.Elements("collision")
				select new Collision(child);
			return collisions.ToList();

		}
		public static List<Visual> ReadVisuals(this XElement node)
		{
			var visuals =
				from child in node.Elements("visual")
				select new Visual(child);
			return visuals.ToList();
		}
	}
}