using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace ikSharp
{
    public class Robot
    {
	    public Joint[] Joints { get; set; }

	    public Vector3 ForwardKinematics(float[] angles)
	    {
		    Vector3 prevPoint = Joints[0].Position;
		    Quaternion rotation = Quaternion.Identity;
		    for (int i = 1; i < Joints.Length; i++)
		    {
			    // Rotates around a new axis
			    rotation *= new Quaternion(Joints[i - 1].Axis, angles[i - 1]);
			    Vector3 nextPoint = prevPoint + Vector3.Transform(  Joints[i].StartOffset, rotation);

			    prevPoint = nextPoint;
		    }
		    return prevPoint;
	    }

	    public float DistanceFromTarget(Vector3 target, float[] angles)
	    {
		    Vector3 point = ForwardKinematics(angles);
		    return Vector3.Distance(point, target);
	    }

	    public float PartialGradient(Vector3 target, float[] angles, int i)
	    {
		    // Saves the angle,
		    // it will be restored later
		    float angle = angles[i];

		    // Gradient : [F(x+SamplingDistance) - F(x)] / h
		    float f_x = DistanceFromTarget(target, angles);

		    angles[i] += SamplingDistance;
		    float f_x_plus_d = DistanceFromTarget(target, angles);

		    float gradient = (f_x_plus_d - f_x) / SamplingDistance;

		    // Restores
		    angles[i] = angle;

		    return gradient;
	    }

	    public void InverseKinematics(Vector3 target, float[] angles)
	    {
		    if (DistanceFromTarget(target, angles) < DistanceThreshold)
			    return;

		    for (int i = Joints.Length - 1; i >= 0; i--)
		    {
			    // Gradient descent
			    // Update : Solution -= LearningRate * Gradient
			    float gradient = PartialGradient(target, angles, i);
			    angles[i] -= LearningRate * gradient;

			    // Clamp
			    //angles[i] = Math.Clamp(angles[i], Joints[i].MinAngle, Joints[i].MaxAngle);

			    // Early termination
			    if (DistanceFromTarget(target, angles) < DistanceThreshold)
				    return;
		    }
	    }

	    public float LearningRate { get; set; }

	    public double DistanceThreshold { get; set; }


	    public float SamplingDistance { get; set; }
    }

	public class Joint
	{
		public Vector3 Axis { get; set; }
		public Vector3 Position { get; set; }
		public Vector3 StartOffset { get; set; }
	}
}
