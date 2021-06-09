using System.Numerics;

namespace RayTracing.Models
{
    public class Color
    {
        private const double BRIGHTNESS = 255.999;

        private readonly Vector3 _vector;

        public Color(Vector3 color)
        {
            _vector = color;
        }

        public Color(float x, float y, float z) : this(new Vector3(x, y, z))
        {

        }

        #region Utilities
        public static explicit operator Color(Vector3 vector)
        {
            return new Color(vector);
        }

        public static explicit operator Vector3(Color color)
        {
            return color._vector;
        }

        public static Color operator *(Color color, float value)
        {
            var vectorizedColor = (Vector3)color;

            vectorizedColor *= value;

            return (Color)vectorizedColor;
        }

        public static Color operator *(float value, Color color)
        {
            var vectorizedColor = (Vector3)color;

            vectorizedColor *= value;

            return (Color)vectorizedColor;
        }

        public static Color operator +(Color color1, Color color2)
        {
            var vectorizedColor1 = (Vector3)color1;
            var vectorizedColor2 = (Vector3)color2;

            return (Color)(vectorizedColor1 += vectorizedColor2);
        }

        public static Color operator -(Color color1, Color color2)
        {
            var vectorizedColor1 = (Vector3)color1;
            var vectorizedColor2 = (Vector3)color2;

            return (Color)(vectorizedColor1 += vectorizedColor2);
        }

        public override string ToString()
        {
            return $"{(int)(BRIGHTNESS * _vector.X)} {(int)(BRIGHTNESS * _vector.Y)} {(int)(BRIGHTNESS * _vector.Z)}";
        }
        #endregion
    }
}
