using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    class Directivo : Empleado
    {
        public double BonoAnual { get; set; }

        public override double CalcularSalario()
        {
            return SalarioBase + (BonoAnual / 12);  // Bono prorrateado mensual
        }
    }
}
