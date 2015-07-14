using System;
using System.Numerics;

namespace JuliaAndMandelbrot
{
    public struct Rectangle
    {
        public Complex UpperRight { get; }
        public Complex LowerLeft { get; }

        public Rectangle(Complex upperRight, Complex lowerLeft) : this()
        {
            this.UpperRight = upperRight;
            this.LowerLeft = lowerLeft;
        }

        public double MaxX => UpperRight.Real;
        public double MinX => LowerLeft.Real;
        public double MaxY => UpperRight.Imaginary;
        public double MinY => LowerLeft.Imaginary;
        public double Width => Math.Abs(LowerLeft.Real - UpperRight.Real);
        public double Height => Math.Abs(LowerLeft.Imaginary - UpperRight.Imaginary);
    }
}