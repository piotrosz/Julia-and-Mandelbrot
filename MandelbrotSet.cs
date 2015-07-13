using System.Numerics;

namespace JuliaAndMandelbrot
{
    public class MandelbrotSet : Fractal
    {
        public MandelbrotSet(int iterations, Area area, double level)
            : base(iterations, area, level) {}

        protected override Complex? CreateCore(Complex current, Complex parameter)
        {
            return this.Iterate(
                initial: parameter, 
                offset: current, 
                returnValue: current);
        }
    }
}