using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    class EmpleadoConComision : Empleado
    {
        public double Ventas { get; set; }
        public double PorcentajeComision { get; set; }

        // override: sobrescribe el método del padre
        public override double CalcularSalario()
        {
            return SalarioBase + (Ventas * PorcentajeComision / 100);
        }
    }

}
