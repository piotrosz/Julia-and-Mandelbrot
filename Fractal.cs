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

        public abstract IEnumerable<Complex> Create(Complex c, double delta);
    }
}
