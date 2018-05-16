using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ikSharp.Extensions;
using ikSharp.Models;
using ikSharp.Models.Joint;


namespace ikSharp
{
    public static class KinematicsExtensions
    {

	    public static Vector3 ForwardKinematics(this Robot robot, double[] angles)
	    {
		    var prevPoint = robot.Joints[0].Origin.Xyz.ToVector3();
			var rotation = Quaternion.Identity;
			for (int i = 1; i < robot.Joints.Count; i++)
			{
				// Rotates around a new axis
				rotation *= new Quaternion(robot.Joints[i - 1].Axis.Xyz.ToVector3(), (float)angles[i - 1]);
				Vector3 nextPoint = prevPoint + Vector3.Transform(robot.Joints[i].Origin.Xyz.ToVector3(), rotation);

				prevPoint = nextPoint;
			}
			return prevPoint;
	    }

	    public static double DistanceFromTarget(this Robot robot, Vector3 target, double[] angles)
	    {
		    var point = robot.ForwardKinematics(angles);
		    return Vector3.Distance(point, target);
	    }

	    public static double PartialGradient(this Robot robot, Vector3 target, double[] angles, int i, double samplingDistance = 0.1)
	    {
		    // Saves the angle,
		    // it will be restored later
		    var angle = angles[i];

		    // Gradient : [F(x+SamplingDistance) - F(x)] / h
		    var f_x = robot.DistanceFromTarget(target, angles);

		    angles[i] += samplingDistance;
		    var f_x_plus_d = robot.DistanceFromTarget(target, angles);

		    var gradient = (f_x_plus_d - f_x) / samplingDistance;

		    // Restores
		    angles[i] = angle;

		    return gradient;
	    }

	    public static double[] InverseKinematics(this Robot robot, Vector3 target, double[] angles, double distanceThreshold = 0.01, double learningRate = 0.001, int iteration = 0, int maxIteration = 100000)
	    {
		    if (robot.DistanceFromTarget(target, angles) < distanceThreshold || iteration > maxIteration)
			    return angles;

		    for (int i = robot.Joints.Count - 1; i >= 0; i--)
		    {
			    // Gradient descent
			    // Update : Solution -= LearningRate * Gradient
			    var gradient = robot.PartialGradient(target, angles, i);
			    angles[i] -= learningRate * gradient;

			    // Clamp
			    angles[i].Clamp(robot.Joints[i].Limit.Lower ?? double.MinValue, robot.Joints[i].Limit.Upper ?? double.MaxValue);

			    // Early termination
			    if (robot.DistanceFromTarget(target, angles) < distanceThreshold)
				    return angles;
		    }
		    iteration++;
		    return robot.InverseKinematics(target, angles, distanceThreshold, learningRate, iteration, maxIteration);
	    }

    }

}
