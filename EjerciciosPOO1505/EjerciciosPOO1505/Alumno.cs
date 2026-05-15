using System;
using System.Collections.Generic;
using System.Text;

namespace EjerciciosPOO1505
{
    internal class Alumno
    {

        public string Nombre { get; set; } = string.Empty;
        public double[] Notas { get; set; } = new double[0];

        public Alumno() { }

        public Alumno(string nombre, double[] notas)
        {
            Nombre = nombre;
            Notas = notas;
        }

        // Médodos

        // Método para calcular la media de las notas
        public double Media()
        {
            return Notas.Average();
        }

        public double NotaMaxima()
        {
            return Notas.Max();
        }

        public bool Aprobado()
        {
            return Media() >= 5;
        }

        public override string ToString()
        {
            return $"Alumno: {Nombre}, Notas: {string.Join(", ", Notas)}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Alumno alumno &&
                   Nombre == alumno.Nombre;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nombre);
        }
    }
}
