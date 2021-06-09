using System;

namespace RayTracing.Models
{
    public class RayTracerOptions
    {
        public float AspectRatio { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeight 
        {
            get
            {
                return Convert.ToInt32(ImageWidth / AspectRatio);
            }
        }

        public float ViewportHeight { get; set; }
        public float ViewportWidth
        {
            get
            {
                return AspectRatio * ViewportHeight;
            }
        }
        public float FocalLength { get; set; }
    }
}
