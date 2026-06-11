using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;

        // Relación N:M Un autor puede escribir varios libros
        public ICollection<Libro> Libros { get; set; } = new List<Libro>();


        public Autor()
        {
        }

        public Autor(int id, string nombre, string pais, ICollection<Libro> libros)
        {
            Id = id;
            Nombre = nombre;
            Pais = pais;
            Libros = libros;
        }

        public Autor(int id, string nombre, string pais)
        {
            Id = id;
            Nombre = nombre;
            Pais = pais;
            Libros = new List<Libro>();
        }

        public Autor(string nombre, string pais, ICollection<Libro> libros)
        {
            Nombre = nombre;
            Pais = pais;
            Libros = libros;
        }

        public Autor(string nombre, string pais)
        {
            Nombre = nombre;
            Pais = pais;
            Libros = new List<Libro>();
        }


    }
}
