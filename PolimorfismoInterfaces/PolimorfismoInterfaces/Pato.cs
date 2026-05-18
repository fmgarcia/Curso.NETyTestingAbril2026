using System;
using System.Collections.Generic;
using System.Text;

namespace PolimorfismoInterfaces
{
    class Pato : Animal, IVolador, INadador
    {
        public double AlturaActual { get; private set; }

        public override string HacerSonido() => "¡Cuac!";

        // Implementación de INadador
        public void Sumergirse() => Console.WriteLine($"{Nombre} se sumerge");
        public void Salir() => Console.WriteLine($"{Nombre} sale del agua");

        // Implementación de IVolador
        public void Aterrizar()
        {
            AlturaActual = 0;
            Console.WriteLine($"{Nombre} aterriza");
        }

        public void Despegar()
        {
            AlturaActual = 10;
            Console.WriteLine($"{Nombre} despega");
        }
    }
}
