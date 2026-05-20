using System;
using System.Collections.Generic;
using System.Text;

namespace PolimorfismoInterfaces
{
    abstract class Forma
    {
        public double CalcularArea() => this switch  // Disponible a partir de C# 8.0
        {
            Circulo c => Math.PI * c.Radio * c.Radio,
            Rectangulo r when r.Ancho == r.Alto => r.Ancho * r.Alto,  // Cuadrado
            Rectangulo r => r.Ancho * r.Alto,
            Triangulo t => t.Base * t.Altura / 2,
            _ => throw new ArgumentException("Forma desconocida")
        };
    }
    class Circulo : Forma
    {
        public double Radio { get; init; }
    }
    class Rectangulo : Forma
    {
        public double Ancho { get; init; }
        public double Alto { get; init; }
    }
    class Triangulo : Forma
    {
        public double Base { get; init; }
        public double Altura { get; init; }
    }
}
