using System.Numerics;

namespace JuliaAndMandelbrot
{
    public class JuliaSet : Fractal
    {
        protected override IterateSinglePointResult? CreateSinglePoint(
            Complex current,
            Complex parameter,
            int maxIterations,
            double maxMagnitude)
        {
            return this.IterateSinglePoint(
                initial: current,
                offset: parameter,
                returnValue: current,
                maxIterations: maxIterations,
                maxMagnitude: maxMagnitude);
        }
    }
}
