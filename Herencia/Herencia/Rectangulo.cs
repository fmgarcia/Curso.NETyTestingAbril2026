using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    class Rectangulo : Figura
    {
        public double Ancho { get; set; }
        public double Alto { get; set; }

        public Rectangulo(double ancho, double alto) { Ancho = ancho; Alto = alto; }

        public override double CalcularArea() => Ancho * Alto;
        public override double CalcularPerimetro() => 2 * (Ancho + Alto);
    }
}
