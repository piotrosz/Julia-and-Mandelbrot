using System.Numerics;

namespace JuliaAndMandelbrot
{
    public static class Parameters
    {
        public static readonly FractalParameters JuliaParameters = new FractalParameters
        {
            Scale = 300,
            ImageName = "Julia.png",
            Area = new Rectangle(upperRight: new Complex(1, 1.5), lowerLeft: new Complex(-1, -1.5)),
            MaxIterations = 200,
            MaxMagnitude = 200,
            Parameter = new Complex(0.336, -0.39),
            Delta = 0.003
        };

        public static readonly FractalParameters MandelbrotParameters = new FractalParameters
        {
            Scale = 400,
            ImageName = "Mandelbrot.png",
            Area = new Rectangle(upperRight: new Complex(0.8, 1.2), lowerLeft: new Complex(-1.8, -1.2)),
            MaxIterations = 200,
            MaxMagnitude = 2,
            Parameter = new Complex(0.0001, 0.0001),
            Delta = 0.001

        };
    }
}