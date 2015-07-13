using System.Collections.Generic;
using System.Numerics;

namespace JuliaAndMandelbrot
{
    public class MandelbrotSet : Fractal
    {
        public MandelbrotSet(int iterations, Area area, double level)
            : base(iterations, area, level) {}

        public override IEnumerable<Complex> Create(Complex zStart, double delta)
        {
            for (double real = area.LowerLeft.Real; real < area.UpperRight.Real; real += delta)
            {
                for (double imaginary = area.LowerLeft.Imaginary; imaginary < area.UpperRight.Imaginary; imaginary += delta)
                {
                    var c = new Complex(real, imaginary);
                    var z = zStart;
                    for (int i = 0; i < iterations; i++)
                    {
                        z = z * z + c;
                        if (z.Magnitude > level)
                        {
                            yield return new Complex(real, imaginary);
                        }
                    }
                }
            }
        }
    }
}