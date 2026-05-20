using System;
using System.Collections.Generic;
using System.Text;

namespace Colecciones
{
    internal class Juguete : IComparable<Juguete>
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public decimal Precio { get; set; } = 0;

        public Juguete()
        {
        }

        public Juguete(int id, string nombre, string descripcion, decimal precio)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
        }

        public string BaratoCaro()
        {
            if (Precio < 20)
                return "Barato";
            else if (Precio >= 20 && Precio < 50)
                return "Moderado";
            else
                return "Caro";
        }

        public override string ToString()
        {
            return $"Juguete: {Nombre}, Descripción: {Descripcion}, Precio: {Precio:C}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Juguete juguete &&
                   Id == juguete.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        // Comparación por defecto basada en el Id del juguete
        public int CompareTo(Juguete? other)
        {
            return Id.CompareTo(other?.Id);
        }
    }
}
