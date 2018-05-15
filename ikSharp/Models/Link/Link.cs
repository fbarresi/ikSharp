using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ikSharp.Extensions;

namespace ikSharp.Models.Link
{
    public class Link
    {
        public string Name { get; set; }
		public Inertial Inertial { get; set; }
		public List<Visual> Visuals { get; set; }
		public List<Collision> Collisions { get; set; }
		public List<Joint.Joint> Joints { get; set; }

		public Link(XElement node)
        {
            Name = (string)node.Attribute("name");  // required
	        Inertial = (node.Element("inertial") != null) ? new Inertial(node.Element("inertial")) : null;  // optional     
            Visuals = node.ReadVisuals(); // multiple
            Collisions = node.ReadCollisions(); // optional   
        }
    }    
}
