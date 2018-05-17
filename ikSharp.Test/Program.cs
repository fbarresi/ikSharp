using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ikSharp.Models;

namespace ikSharp.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			var robot = new Robot("UR5.urdf");

			var zero = robot.ForwardKinematics(new double[] {0, 0, 0, 0, 0, 0});
			Console.WriteLine(zero);

			Console.ReadLine();
		}
	}
}
