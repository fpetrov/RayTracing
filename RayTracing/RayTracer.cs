using RayTracing.Extensions;
using RayTracing.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace RayTracing
{
    public class RayTracer
    {
        public RayTracerOptions Options { get; private set; }

        public RayTracer()
        {
            Options = new RayTracerOptions();
        }

        public RayTracer(RayTracerOptions options)
        {
            Options = options;
        }

        public RayTracer Configure(RayTracerOptions options)
        {
            Options = options;

            return this;
        }

        public RayTracer Configure(Action<RayTracerOptions> options)
        {
            options.Invoke(Options);

            return this;
        }

        public void Render(string filePath = null)
        {
            var imagePath = filePath == null ? "image.ppm" : filePath;

            var origin = new Vector3(0, 0, 0);
            var horizontal = new Vector3(Options.ViewportWidth, 0, 0);
            var vertical = new Vector3(0, Options.ViewportHeight, 0);
            var lowerLeftCorner = origin - horizontal / 2 - vertical / 2 - new Vector3(0, 0, Options.FocalLength);

            using var textWriter = new StreamWriter(imagePath);

            textWriter.Write($"P3\n{Options.ImageWidth} {Options.ImageHeight} \n255\n");

            for (int i = Options.ImageHeight - 1; i >= 0; --i)
            {
                Console.WriteLine($"Rendering progress: {i} / {Options.ImageHeight - 1}");

                for (int j = 0; j < Options.ImageWidth; ++j)
                {
                    var u = (float)j / (Options.ImageWidth - 1);
                    var v = (float)i / (Options.ImageHeight - 1);

                    var ray = new Ray()
                    {
                        Origin = origin,
                        Direction = lowerLeftCorner + u * horizontal + v * vertical - origin
                    };

                    var color = (Color)ray;

                    textWriter.WriteLine(color.ToString());
                }
            }

            Console.WriteLine("Finished rendering!");
        }
    }
}
