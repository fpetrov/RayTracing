using System.Numerics;

namespace RayTracing.Extensions
{
    public static class Vector3Extensions
    {
        public static float GetValue(this Vector3 vector, int index) =>
            index switch
            {
                0 => vector.X,
                1 => vector.Y,
                2 => vector.Z,
                _ => 0
            };

        public static Vector3 Unit(this Vector3 vector) => vector / vector.Length();
    }
}
