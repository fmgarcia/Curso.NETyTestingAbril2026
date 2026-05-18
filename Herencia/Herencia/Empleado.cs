using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    class Empleado
    {
        public string Nombre { get; set; } = "";
        public double SalarioBase { get; set; }

        // virtual: las clases hijas PUEDEN sobrescribir este método
        public virtual double CalcularSalario()
        {
            return SalarioBase;
        }

        public override string ToString()
        {
            return $"{Nombre}: {CalcularSalario():C2}";
        }
    }
}
