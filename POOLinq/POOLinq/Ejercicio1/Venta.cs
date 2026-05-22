using System;
using System.Collections.Generic;
using System.Text;

namespace POOLinq
{
    public class Venta : IComparable<Venta>
    {
        public string Producto { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        // Constructores
        public Venta() { }

        public Venta(string producto, string categoria, double precio, int cantidad, DateTime fecha = default)
        {
            Producto = producto;
            Categoria = categoria;
            Precio = precio;
            Cantidad = cantidad;
            Fecha = fecha == default ? DateTime.Now : fecha;
        }

        public override string ToString()
        {
            return $"Producto: {Producto}, Categoria: {Categoria}, Precio: {Precio:C}, Cantidad: {Cantidad}, Fecha: {Fecha:d}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Venta venta &&
                   Producto == venta.Producto &&
                   Categoria == venta.Categoria;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Producto, Categoria);
        }

        public int CompareTo(Venta? other)
        {
            return other == null ? 1 : (Precio * Cantidad).CompareTo(other.Precio * other.Cantidad);
        }
    }
}
