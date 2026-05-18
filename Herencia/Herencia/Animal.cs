using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    internal class Animal
    {
        public string Nombre { get; set; } = "";
        public int Edad { get; set; }

        public void Comer()
        {
            Console.WriteLine($"{Nombre} está comiendo.");
        }

        public void Dormir()
        {
            Console.WriteLine($"{Nombre} está durmiendo durante 8 horas.");
        }

        public virtual void HacerSonido()
        {
            Console.WriteLine("(sonido genérico)");
        }

        public override string ToString() => $"{GetType().Name}: {Nombre}";


    }
}
