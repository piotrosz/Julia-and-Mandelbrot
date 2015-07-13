using System.Collections.Generic;
using System.Numerics;

namespace JuliaAndMandelbrot
{
    public class JuliaSet : Fractal
    {
        public JuliaSet(int iterations, Area area, double level) 
            : base(iterations, area, level) {}

        public override IEnumerable<Complex> Create(Complex c, double delta)
        {
            for (double real = area.LowerLeft.Real; real < area.UpperRight.Real; real += delta)
            {
                for (double imaginary = area.LowerLeft.Imaginary; imaginary < area.UpperRight.Imaginary; imaginary += delta)
                {
                    var z = new Complex(real, imaginary);

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
