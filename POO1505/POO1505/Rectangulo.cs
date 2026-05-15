using System;
using System.Collections.Generic;
using System.Text;

namespace POO1505
{
    internal class Rectangulo(double ancho, double alto)
    {
        public double Ancho { get; set; } = ancho;
        public double Alto { get; set; } = alto;

        // Propiedad calculada: no almacena valor, lo calcula cada vez
        public double Area => Ancho * Alto;
        public double Perimetro => 2 * (Ancho + Alto);
        public bool EsCuadrado => Ancho == Alto;

        public double CalcularArea()
        {
            return Ancho * Alto;
        }

        public double CalcularPerimetro() => 2 * (Ancho + Alto);  // Método tradicional para calcular el perímetro

        public override bool Equals(object? obj)
        {
            return obj is Rectangulo rectangulo &&
                   Area == rectangulo.Area;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Area);
        }
    }
}
