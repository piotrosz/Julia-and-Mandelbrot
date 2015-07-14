using System.Numerics;

namespace JuliaAndMandelbrot
{
    public class MandelbrotSet : Fractal
    {
        protected override IterateSinglePointResult? CreateSinglePoint(
            Complex current,
            Complex parameter,
            int maxIterations,
            double maxMagnitude)
        {
            return this.IterateSinglePoint(
                initial: parameter,
                offset: current,
                returnValue: current,
                maxIterations: maxIterations,
                maxMagnitude: maxMagnitude);
        }
    }
}