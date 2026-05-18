using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    class Coche : Vehiculo
    {
        public int Puertas { get; set; }

        // Llamamos al constructor del padre con : base(...)
        public Coche(string marca, string modelo, int año, int puertas) : base(marca, modelo, año)   // ← Pasar datos al constructor de Vehiculo
        {
            Puertas = puertas;
        }
    }
}
