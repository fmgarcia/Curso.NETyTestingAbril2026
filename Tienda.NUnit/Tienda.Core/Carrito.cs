using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Core
{
    public class Carrito
    {
        private readonly List<Producto> _productos = [];

        public int TotalItems => _productos.Count;
        public bool EstaVacio => _productos.Count == 0;
        public IReadOnlyCollection<Producto> Productos => _productos.AsReadOnly();

        public void Agregar(Producto producto)
        {
            ArgumentNullException.ThrowIfNull(producto);
            _productos.Add(producto);
        }

        public void Limpiar()
        {
            _productos.Clear();
        }
    }
}
