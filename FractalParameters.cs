using System.Numerics;

namespace JuliaAndMandelbrot
{
    public struct FractalParameters
    {
        public Rectangle Area { get; set; }

        public int MaxIterations { get; set; }

        public int MaxMagnitude { get; set; }

        public double Delta { get; set; }

        public Complex Parameter { get; set; }

        public double Scale { get; set; }

        public string ImageName { get; set; }
    }
}
