using System.Numerics;

namespace JuliaAndMandelbrot
{
    public class Area
    {
        public Complex UpperRight { get; }
        public Complex LowerLeft { get; }

        public Area(Complex upperRight, Complex lowerLeft)
        {
            this.UpperRight = upperRight;
            this.LowerLeft = lowerLeft;
        }
    }
}
