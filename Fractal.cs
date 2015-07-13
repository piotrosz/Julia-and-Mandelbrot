using System.Collections.Generic;
using System.Numerics;

namespace JuliaAndMandelbrot
{
    public abstract class Fractal
    {
        protected readonly int iterations;
        protected readonly Area area;
        protected readonly double level;

        protected Fractal(int iterations, Area area, double level)
        {
            this.iterations = iterations;
            this.area = area;
            this.level = level;
        }

        public IEnumerable<Complex> Create(Complex parameter, double delta)
        {
            for (double real = area.LowerLeft.Real;
                real < area.UpperRight.Real;
                real += delta)
            {
                for (double imaginary = area.LowerLeft.Imaginary;
                    imaginary < area.UpperRight.Imaginary;
                    imaginary += delta)
                {
                    var point = this.CreateCore(new Complex(real, imaginary), parameter);

                    if (point != null)
                    {
                        yield return point.Value;
                    }
                }
            }
        }

        protected abstract Complex? CreateCore(Complex current, Complex parameter);

        protected Complex? Iterate(Complex initial, Complex offset, Complex returnValue)
        {
            var z1 = initial;
            for (int i = 0; i < iterations; i++)
            {
                z1 = z1 * z1 + offset;
                if (z1.Magnitude > level)
                {
                    return returnValue;
                }
            }
            return null;
        }
    }
}