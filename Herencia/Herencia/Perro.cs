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

        public override void HacerSonido()
        {
            base.HacerSonido();  // Ejecuta el método del padre primero
            Console.WriteLine("¡Guau guau!");
        }

        public override string ToString() => $"{base.ToString()}, Raza: {Raza}";

    }

}
