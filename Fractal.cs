using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace JuliaAndMandelbrot
{
    public abstract class Fractal
    {
        public IEnumerable<IterateSinglePointResult> Create(FractalParameters parameters)
        {
            for (double real = parameters.Area.MinX; real < parameters.Area.MaxX; real += parameters.Delta)
            {
                for (double imaginary = parameters.Area.MinY; imaginary < parameters.Area.MaxY; imaginary += parameters.Delta)
                {
                    var result = this.CreateSinglePoint(
                        new Complex(real, imaginary),
                        parameters.Parameter,
                        parameters.MaxIterations,
                        parameters.MaxMagnitude);

                    if (result.HasValue)
                    {
                        yield return result.Value;
                    }
                }
            }
        }

        public IEnumerable<IterateSinglePointResult> CreateInParallel(FractalParameters parameters)
        {
            var bag = new ConcurrentBag<IterateSinglePointResult>();

            Parallel.ForEach(Range(parameters.Area.MinX, parameters.Area.MaxX, parameters.Delta), real =>
            {
                for (double imaginary = parameters.Area.MinY; imaginary < parameters.Area.MaxY; imaginary += parameters.Delta)
                {
                    var point = this.CreateSinglePoint(
                                           new Complex(real, imaginary),
                                           parameters.Parameter,
                                           parameters.MaxIterations,
                                           parameters.MaxMagnitude);

                    if (point.HasValue)
                    {
                        bag.Add(point.Value);
                    }
                }
            });

            return bag;
        }

        private static IEnumerable<double> Range(double min, double max, double step)
        {
            for (double i = min; i <= max; i += step)
            {
                yield return i;
            }
        }

        protected abstract IterateSinglePointResult? CreateSinglePoint(
            Complex current,
            Complex parameter,
            int maxIterations,
            double maxMagnitude);

        protected IterateSinglePointResult? IterateSinglePoint(
            Complex initial,
            Complex offset,
            Complex returnValue,
            int maxIterations,
            double maxMagnitude)
        {
            var z1 = initial;
            for (int i = 0; i < maxIterations; i++)
            {
                z1 = z1 * z1 + offset;
                if (z1.Magnitude > maxMagnitude)
                {
                    return new IterateSinglePointResult { C = returnValue, Iterations = i };
                }
            }
            return null;
        }
    }
}