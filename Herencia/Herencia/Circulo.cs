using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    class Circulo : Figura
    {
        public double Radio { get; set; }

        public Circulo(double radio) { Radio = radio; }

        // OBLIGATORIO: implementar los métodos abstractos
        public override double CalcularArea() => Math.PI * Radio * Radio;
        public override double CalcularPerimetro() => 2 * Math.PI * Radio;

    }
}
