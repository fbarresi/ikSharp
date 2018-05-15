using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ikSharp.Extensions;
using ikSharp.Models.Link;

namespace ikSharp.Models
{
    public class Robot
    {
	    public string Name { get; set; }
        public Link.Link Root { get; set; }
        public List<Material> Materials { get; set; }

	    public Robot()
	    {
		    
	    }
        public Robot(string filename)
		{
			LoadFile(filename);
		}

		private void LoadFile(string filename)
		{
			XDocument xdoc = XDocument.Load(filename);
			XElement node = xdoc.Element("robot");
			Name = node.Attribute("name").Value;

			Materials = node.ReadMaterials(); // multiple
			Links = node.ReadLinks(); // multiple
			Joints = node.ReadJoints(); // multiple

			// build tree structure from link and joint lists:
			foreach (Link.Link link in Links)
				link.Joints = Joints.FindAll(v => v.Parent == link.Name);
			foreach (Joint.Joint joint in Joints)
				joint.ChildLink = Links.Find(v => v.Name == joint.Child);

			// save root node only:
			Root = FindRootLink(Links, Joints);
		}

		public List<Joint.Joint> Joints { get; set; }

	    public List<Link.Link> Links { get; set; }

        private Link.Link FindRootLink(List<Link.Link> links, List<Joint.Joint> joints, int startIdx = 0)
        {
            Joint.Joint joint = joints[0];
            string parent;
            do
            {
                parent = joint.Parent;
                joint = joints.Find(v => v.Child == parent);
            }
            while (joint != null);
            return links.Find(v => v.Name == parent);
        }
    }
}
