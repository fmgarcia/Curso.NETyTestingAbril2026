using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework2505
{
    public class Categoria
    {

        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        // Relación con Producto (uno a muchos). Una categoría puede tener muchos productos. Relación inversa a la propiedad de navegación "Categoria" en Producto.
        public List<Producto> Productos { get; set; } = new List<Producto>();

    }
}
