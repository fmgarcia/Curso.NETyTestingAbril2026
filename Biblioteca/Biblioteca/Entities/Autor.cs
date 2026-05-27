using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    internal class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;

        // Relación N:M Un autor puede escribir varios libros
        public ICollection<Libro> Libros { get; set; } = new List<Libro>();

    }
}
