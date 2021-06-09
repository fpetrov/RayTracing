using RayTracing.Extensions;
using System;
using System.Numerics;

namespace RayTracing.Models
{
    public class Ray
    {
        public Vector3 Origin { get; set; }
        public Vector3 Direction { get; set; }

        public Ray()
        {

        }

        public Ray(Vector3 origin, Vector3 direction)
        {
            Origin = origin;
            Direction = direction;
        }

        public static explicit operator Color(Ray ray)
        {
            var t = HitSphere(new Vector3(0, 0, -1), 0.5f, ray);

            if (t > 0.0)
            {
                var n = (ray.Cast(t) - new Vector3(0, 0, -1))
                    .Unit();

                return 0.5f * new Color(n.X + 1, n.Y + 1, n.Z + 1);
            }

            var unitDirection = ray.Direction.Unit();

            t = (float)(0.5 * unitDirection.Y + 1.0);

            return (1.0f - t) * new Color(1.0f, 1.0f, 1.0f) + t * new Color(0.5f, 0.7f, 1f);
        }

        public static float HitSphere(Vector3 center, float radius, Ray ray)
        {
            var difference = ray.Origin - center;
            var a = Vector3.Dot(ray.Direction, ray.Direction);
            var b = 2f * Vector3.Dot(difference, ray.Direction);
            var c = Vector3.Dot(difference, difference) - radius * radius;
            var discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
                return -1f;

                return (-b - MathF.Sqrt(discriminant)) / (2f * a);
        }

        public Vector3 Cast(float t) => Origin + t * Direction;
    }
}
