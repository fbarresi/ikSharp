using System;
using System.Linq;
using System.Xml.Linq;

namespace ikSharp.Models.Joint
{
    public class Joint
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Origin Origin { get; set; }
		public string Parent { get; set; }
	    public string Child { get; set; }
	    public Axis Axis { get; set; }
		public Calibration Calibration { get; set; }
		public Dynamics Dynamics { get; set; }
		public Limit Limit { get; set; }
		public Mimic Mimic { get; set; }
		public SafetyController SafetyController { get; set; }

		public Link.Link ChildLink;

        public Joint(XElement node)
        {
            Name = (string)node.Attribute("name"); // required
            Type = (string)node.Attribute("type"); // required
            Origin = (node.Element("origin") != null) ? new Origin(node.Element("origin")) : null; // optional  
            Parent = (string)node.Element("parent").Attribute("link"); // required
            Child = (string)node.Element("child").Attribute("link"); // required
            Axis = (node.Element("axis") != null) ? new Axis(node.Element("axis")) : null;  // optional 
            Calibration = (node.Element("calibration") != null) ? new Calibration(node.Element("calibration")) : null;  // optional 
            Dynamics = (node.Element("dynamics") != null) ? new Dynamics(node.Element("dynamics")) : null;  // optional 
            Limit = (node.Element("limit") != null) ? new Limit(node.Element("limit")) : null;  // required only for revolute and prismatic joints
            Mimic = (node.Element("mimic") != null) ? new Mimic(node.Element("mimic")) : null;  // optional
            SafetyController = (node.Element("safety_controller") != null) ? new SafetyController(node.Element("safety_controller")) : null;  // optional
        }
    }
    
}
