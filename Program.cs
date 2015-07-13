using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;

namespace JuliaAndMandelbrot
{
    class Program
    {
        static void Main()
        {
            //CreateJulia();
            CreateMandelbrot();
        }

        private static void CreateJulia()
        {
            var area = new Area(
                upperRight: new Complex(1, 2),
                lowerLeft: new Complex(-1, -1));
            var juliaSet = new JuliaSet(iterations: 100,
                area: area,
                level: 20);
            var set = juliaSet.Create(
                c: new Complex(0.336, -0.39),
                delta: 0.003);
                
            SaveImage(area, set, "JuliaSet.png", 300);
        }

        private static void CreateMandelbrot()
        {
            var area = new Area(
                upperRight: new Complex(0.8, 1.2),
                lowerLeft: new Complex(-1.8, -1.2));
            var mandelbrot = new MandelbrotSet(
                iterations: 150,
                area: area,
                level: 100);
            var set = mandelbrot.Create(
                zStart: new Complex(0.0001, 0.0001),
                delta: 0.0005);
            SaveImage(area, set, "MandelbrotSet.png", 400);
        }

        static void SaveImage(Area area, IEnumerable<Complex> set, string fileName, float scale)
        {
            var minX = area.LowerLeft.Real;
            var maxX = area.UpperRight.Real;
            var minY = area.LowerLeft.Imaginary;
            var maxY = area.UpperRight.Imaginary;
            
            var width = scale * (maxX - minX);
            var height = scale * (maxY - minY);
            var xOffset = Math.Abs(minX * scale);
            var yOffset = Math.Abs(minY * scale);

            using (var bitmap = new Bitmap(Convert.ToInt32(width), Convert.ToInt32(height)))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.White);
                    var pen = new Pen(Color.Black, 1);

                    foreach (Complex c in set)
                    {
                        var x = ((c.Real / (maxX - minX)) * width + xOffset);
                        var y = ((c.Imaginary / (maxY - minY)) * height + yOffset);
                        graphics.DrawLine(pen, (float)x, (float)y, (float)(x + 1d), (float)y);
                    }
                    bitmap.Save(fileName, ImageFormat.Png);
                }
            }
        }
    }
}
