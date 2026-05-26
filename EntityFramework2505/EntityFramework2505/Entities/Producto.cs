using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework2505
{
    public class Producto
    {
        public int Id { get; set; }  // Clave primaria. Por convención ("Id"), EF Core lo reconoce automáticamente.
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Relación con Categoria (muchos a uno). Un producto pertenece a una categoría.
        public int CategoriaId { get; set; }  // Clave foránea. Por convención ("CategoriaId"), EF Core lo reconoce automáticamente.
        public Categoria Categoria { get; set; } = null!;  // Propiedad de navegación para la relación con Categoria.

    }
}
