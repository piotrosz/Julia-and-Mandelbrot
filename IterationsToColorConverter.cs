using System.Drawing;

namespace JuliaAndMandelbrot
{
    internal static class IterationsToColorConverter
    {
        public static Color Convert(int iterations)
        {
            return Color.FromArgb((iterations * 7) % 256, (iterations * 7) % 256, iterations % 256);
        }
    }
}
