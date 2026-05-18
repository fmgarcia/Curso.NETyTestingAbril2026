using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    class Triangulo : Figura
    {
        public double Base { get; set; }
        public double Altura { get; set; }
        public double Lado1 { get; set; }
        public double Lado2 { get; set; }
        public double Lado3 { get; set; }

        public override double CalcularArea() => Base * Altura / 2;
        public override double CalcularPerimetro() => Lado1 + Lado2 + Lado3;
    }
}
