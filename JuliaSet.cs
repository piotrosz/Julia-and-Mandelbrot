using System.Numerics;

namespace JuliaAndMandelbrot
{
    public class JuliaSet : Fractal
    {
        public JuliaSet(int iterations, Area area, double level) 
            : base(iterations, area, level) {}
        
        protected override Complex CreateCore(Complex current, Complex parameter)
        {
            return this.Iterate(
                initial: current, 
                offset: parameter, 
                returnValue: current);
        }
    }
}
