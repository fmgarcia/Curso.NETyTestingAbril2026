using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    internal class Gato : Animal
    {
        public bool EsDeInterior { get; set; }

        public void Maullar()
        {
            Console.WriteLine($"{Nombre} dice: ¡Miau!");
        }
    }
}
