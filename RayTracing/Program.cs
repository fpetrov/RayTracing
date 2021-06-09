using System;
using System.IO;

namespace RayTracing
{
    class Program
    {
        // TODO: Add support for another file formats, except .ppm.

        static void Main(string[] args)
        {
            var rayTracer = new RayTracer();

            // Setting up the ray tracer.
            rayTracer
                .Configure(options => {
                    options.AspectRatio = 16f / 9f;
                    options.ImageWidth = 1920;
                    options.ViewportHeight = 2f;
                    options.FocalLength = 1f;
                })
                .Render();
        }
    }
}
