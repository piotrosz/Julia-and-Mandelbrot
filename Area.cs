using System;
using System.Data;

namespace JuliaAndMandelbrot
{
    public class Area
    {
        public Area()
        {
            this.MinX = this.MaxX = this.MinY = this.MaxY = 0;
        }
        public Area(double minX, double maxX, double minY, double maxY)
        {
            this.MinX = minX;
            this.MaxX = maxX;
            this.MinY = minY;
            this.MaxY = maxY;
        }

        public double MinX { get; set; }
        public double MaxX { get; set; }
        public double MinY { get; set; }
        public double MaxY { get; set; }
    }
}
