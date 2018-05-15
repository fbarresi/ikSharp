using System.Numerics;

namespace ikSharp.Extensions
{
	public static class VectorExtensions
	{
		public static Vector3 ToVector3(double[] position)
		{
			if(position != null && position.Length == 3) return new Vector3((float)position[0], (float)position[1], (float)position[2]);
			return new Vector3();
		}
	}
}