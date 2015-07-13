using System.Collections.Generic;
using System.Numerics;

namespace JuliaAndMandelbrot
{
    public class MandelbrotSet : Fractal
    {
        private Complex c;
        private Complex z;

        public MandelbrotSet(int iterations, Area area, double level)
            : base(iterations, area, level)
        {
            this.c = new Complex();
            this.z = new Complex();
        }

        public override IEnumerable<Complex> Create(Complex zStart, double delta)
        {
            for (double real = area.LowerLeft.Real; real < area.UpperRight.Real; real += delta)
            {
                for (double imaginary = area.LowerLeft.Imaginary; imaginary < area.UpperRight.Imaginary; imaginary += delta)
                {
                    this.c = new Complex(real, imaginary);
                    this.z = zStart;
                    for (int i = 0; i < iterations; i++)
                    {
                        this.z = this.z * this.z + this.c;
                        if (this.z.Magnitude > level)
                        {
                            yield return new Complex(real, imaginary);
                        }
                    }
                }
            }
        }
    }
}