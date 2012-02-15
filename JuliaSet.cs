#region Using
using System;
using System.Data;
#endregion

namespace JuliaAndMandelbrot
{
    public class JuliaSet : Fractal
    {
        private Complex z;

        public JuliaSet()
            : base()
        {
            this.z = new Complex();
        }

        public override void Create(Complex c, double delta, int iterations, Area area, double level)
        {
            double real, imag;
            for (real = area.MinX; real < area.MaxX; real += delta)
            {
                for (imag = area.MinY; imag < area.MaxY; imag += delta)
                {
                    this.z.Re = real;
                    this.z.Im = imag;
                    for (i = 0; i < iterations; i++)
                    {
                        this.z = this.z * this.z + c;
                        if (z.GetModulus() > level)
                        {
                            set.Add(new Complex(real, imag));
                            break;
                        }
                    }
                }
            }
        }
    }
}
