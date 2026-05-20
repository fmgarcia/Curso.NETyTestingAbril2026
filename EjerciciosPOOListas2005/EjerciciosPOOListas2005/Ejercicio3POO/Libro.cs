using System;
using System.Collections.Generic;
using System.Text;

namespace EjerciciosPOOListas2005.Ejercicio3POO
{
    internal class Libro
    {
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;

        public bool Disponible { get; set; } = true;

        public Libro() { }

        public Libro(string titulo, string autor)
        {
            Titulo = titulo;
            Autor = autor;
            Disponible = true;
        }

        public override string ToString()
        {
            return $"Título: {Titulo}, Autor: {Autor}, - {(Disponible ? "Disponible" : "No disponible")}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Libro libro &&
                   Titulo == libro.Titulo &&
                   Autor == libro.Autor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Titulo, Autor);
        }
    }
}
