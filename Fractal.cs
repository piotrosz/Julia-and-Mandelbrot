using System;
using System.Data;
using System.Collections.Generic;
using System.IO;

namespace JuliaAndMandelbrot
{
    public class Fractal
    {
        protected int i;

        protected List<Complex> set;
        public List<Complex> Set
        {
            get { return this.set; }
        }

        protected Fractal()
        {
            this.set = new List<Complex>();
        }

        public virtual void Create(Complex c, double delta, int iterations, Area area, double level)
        { }

        public void ToFile(string Path)
        {
            using (StreamWriter streamWriter = File.CreateText(Path))
            {
                foreach (Complex c in set)
                    streamWriter.WriteLine("{0};{1};", c.Re, c.Im);
                streamWriter.Close();
            }
        }
    }
}
