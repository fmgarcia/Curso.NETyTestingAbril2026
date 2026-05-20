using System;
using System.Collections.Generic;
using System.Text;

namespace EjerciciosPOOListas2005.Ejercicio3POO
{
    internal class Biblioteca
    {
        public string Nombre { get; set; } = string.Empty;
        public List<Libro> libros { get; set; } = new List<Libro>();

        public Biblioteca() { }

        public Biblioteca(string nombre)
        {
            Nombre = nombre;
            libros = new List<Libro>();
        }
        public Biblioteca(string nombre, List<Libro> libros)
        {
            Nombre = nombre;
            this.libros = libros;
        }

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        public Libro BuscarPorTitulo(string titulo)
        {
            return libros.Find(libro => libro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))!;
        }

        public Libro BuscarPorAutor(string autor)
        {
            return libros.Find(libro => libro.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase))!;
        }

        public void PrestarLibro(string titulo)
        {
            Libro libro = BuscarPorTitulo(titulo);
            libro.Disponible = false;
        }

        public void DevolverLibro(string titulo)
        {
            Libro libro = BuscarPorTitulo(titulo);
            libro.Disponible = true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Biblioteca: {Nombre}");
            sb.AppendLine("Libros:");
            foreach (var libro in libros)
            {
                sb.AppendLine($"{libro}");
            }
            return sb.ToString();
        }

    }
}
