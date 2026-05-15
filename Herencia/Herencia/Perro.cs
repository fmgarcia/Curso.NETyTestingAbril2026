using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    internal class Perro : Animal
    {

        public string Raza { get; set; } = "";

        public void Ladrar()
        {
            Console.WriteLine($"{Nombre} dice: ¡Guau!");
        }
    }

}
