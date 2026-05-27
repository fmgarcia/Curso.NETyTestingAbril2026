using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    internal class Libro
    {

        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int Anio { get; set; }

        // Relación N:M Un libro puede tener varios autores
        public ICollection<Autor> Autores { get; set; } = new List<Autor>();

    }
}
