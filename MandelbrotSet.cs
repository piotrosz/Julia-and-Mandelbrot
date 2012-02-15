using System;
using System.Data;

namespace JuliaAndMandelbrot
{
    public class MandelbrotSet : Fractal
    {
        private Complex c;
        private Complex z;

        public MandelbrotSet()
            : base()
        {
            this.c = new Complex();
            this.z = new Complex();
        }

        public override void Create(Complex z, double delta, int iterations, Area area, double level)
        {
            for (double real = area.MinX; real < area.MaxX; real += delta)
            {
                for (double imag = area.MinY; imag < area.MaxY; imag += delta)
                {
                    this.c.Re = real;
                    this.c.Im = imag;
                    this.z.Re = z.Re;
                    this.z.Im = z.Im;
                    for (i = 0; i < iterations; i++)
                    {
                        this.z = this.z * this.z + this.c;
                        if (this.z.GetModulus() > level)
                        {
                            this.set.Add(new Complex(real, imag));
                            break;
                        }
                    }
                }
            }
        }
    }
}