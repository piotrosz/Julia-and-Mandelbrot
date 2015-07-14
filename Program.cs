using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace JuliaAndMandelbrot
{
    class Program
    {
        static void Main()
        {
            CreateJulia();
            //CreateMandelbrot();
        }

        private static void CreateJulia()
        {
            var parameters = Parameters.JuliaParameters;
            var set = new JuliaSet().CreateInParallel(parameters);
            SaveImage(parameters.Area, set, parameters.ImageName, parameters.Scale);
        }

        private static void CreateMandelbrot()
        {
            var parameters = Parameters.MandelbrotParameters;
            var set = new MandelbrotSet().CreateInParallel(parameters);
            SaveImage(parameters.Area, set, parameters.ImageName, parameters.Scale);
        }

        static void SaveImage(Rectangle area, IEnumerable<IterateSinglePointResult> set, string fileName, double scale)
        {
            var width = scale * (area.MaxX - area.MinX);
            var height = scale * (area.MaxY - area.MinY);
            var xOffset = Math.Abs(area.MinX * scale);
            var yOffset = Math.Abs(area.MinY * scale);

            using (var bitmap = new Bitmap(Convert.ToInt32(width) + 1, Convert.ToInt32(height) + 1))
            {
                foreach (var r in set)
                {
                    var x = (r.C.Real / (area.MaxX - area.MinX)) * width + xOffset;
                    var y = (r.C.Imaginary / (area.MaxY - area.MinY)) * height + yOffset;

                    bitmap.SetPixel(
                        Convert.ToInt32(x),
                        Convert.ToInt32(y),
                        IterationsToColorConverter.Convert(r.Iterations));
                }
                bitmap.Save(fileName, ImageFormat.Png);
            }
        }
    }
}
