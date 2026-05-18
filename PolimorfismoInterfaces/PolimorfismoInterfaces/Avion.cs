using System;
using System.Collections.Generic;
using System.Text;

namespace PolimorfismoInterfaces
{
    class Avion : IVolador  // Solo implementa IVolador (no hereda de Animal)
    {
        public double AlturaActual { get; private set; }

        public void Despegar()
        {
            AlturaActual = 10000;
            Console.WriteLine("El avión despega");
        }

        public void Aterrizar()
        {
            AlturaActual = 0;
            Console.WriteLine("El avión aterriza");
        }
    }
}
