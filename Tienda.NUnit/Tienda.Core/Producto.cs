using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Core
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
