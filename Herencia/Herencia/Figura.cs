using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    abstract class Figura
    {
        public string Color { get; set; } = "Negro";

        // Método abstracto: NO tiene cuerpo, las hijas DEBEN implementarlo
        public abstract double CalcularArea();
        public abstract double CalcularPerimetro();

        // Método normal: las hijas lo heredan tal cual
        public void MostrarInfo()
        {
            Console.WriteLine($"Figura: {GetType().Name}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Área: {CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
        }
    }
}
