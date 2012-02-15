using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace JuliaAndMandelbrot
{
    class Program
    {
        static void Main(string[] args)
        {
            // -- Julia set --
            var juliaSet = new JuliaSet();
            juliaSet.Create(
                c: new Complex(0.336, -0.39),
                delta: 0.003,
                iterations: 100,
                area: new Area(-1.0, 1.0, -1.0, 1.0),
                level: 20);
            SaveImage(juliaSet.Set, "JuliaSet.png", 300);

            // -- Mandelbrot set --
            //var mandelbrot = new MandelbrotSet();
            //mandelbrot.Create(
            //    z: new Complex(0.0001, 0.0001),
            //    delta: 0.001,
            //    iterations: 100,
            //    area: new Area(-1.8, 0.8, -1.2, 1.2),
            //    level: 10);
            //SaveImage(mandelbrot.Set, "MandelbrotSet.png", 300);
        }

        static void SaveImage(List<Complex> set, string fileName, float scale)
        {
            float minX = 0, maxX = 0, minY = 0, maxY = 0;
            foreach (Complex c in set)
            {
                minX = (float)Math.Min(minX, c.Re);
                maxX = (float)Math.Max(maxX, c.Re);
                minY = (float)Math.Min(minY, c.Im);
                maxY = (float)Math.Max(maxY, c.Im);
            }
            float width = scale * (maxX - minX);
            float height = scale * (maxY - minY);
            float xOffset = Math.Abs(minX * scale);
            float yOffset = Math.Abs(minY * scale);

            using (Bitmap bitmap = new Bitmap(Convert.ToInt32(width), Convert.ToInt32(height)))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.White);
                    Pen pen = new Pen(Color.Black, 1);
                    float x, y;

                    foreach (Complex c in set)
                    {
                        x = (float)((c.Re / (maxX - minX)) * width + xOffset);
                        y = (float)((c.Im / (maxY - minY)) * height + yOffset);
                        graphics.DrawLine(pen, x, y, x + 1, y);
                    }
                    bitmap.Save(fileName, ImageFormat.Png);
                }
            }
        }
    }
}
