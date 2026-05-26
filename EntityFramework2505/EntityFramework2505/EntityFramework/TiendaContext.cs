using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework2505
{
    class TiendaContext : DbContext
    {

        // DbSet para cada entidad. Cada entidad se representa como una tabla en la base de datos.
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Producto> Productos { get; set; } = null!;

        // Configuración de la conexión a la base de datos. En este caso, se utiliza SQLLite LocalDB.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuración de la cadena de conexión a la base de datos.
            optionsBuilder.UseSqlite(@"Data Source=..\..\..\tienda.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Datos iniciales para la tabla Categorias. Esto se hace utilizando el método HasData, que permite insertar datos de ejemplo en la base de datos cuando se crea o se actualiza el esquema.
            // se conoce como semilla (seed) de datos, y es útil para tener datos de prueba o para poblar la base de datos con información inicial.
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Electrónica", Descripcion = "Dispositivos electrónicos y gadgets." },
                new Categoria { Id = 2, Nombre = "Ropa", Descripcion = "Prendas de vestir para todas las edades." },
                new Categoria { Id = 3, Nombre = "Hogar", Descripcion = "Artículos para el hogar y decoración." }
            );
            modelBuilder.Entity<Producto>().HasData(
                new Producto { Id = 1, Nombre = "Smartphone", Descripcion = "Teléfono inteligente de última generación.", Precio = 699.99m, Stock = 50, FechaCreacion = new DateTime(2026, 5, 26), CategoriaId = 1 },
                new Producto { Id = 2, Nombre = "Laptop", Descripcion = "Portátil potente para trabajo y entretenimiento.", Precio = 1299.99m, Stock = 30, FechaCreacion = new DateTime(2026, 5, 26), CategoriaId = 1 },
                new Producto { Id = 3, Nombre = "Camiseta", Descripcion = "Camiseta de algodón para uso diario.", Precio = 19.99m, Stock = 100, FechaCreacion = new DateTime(2026, 5, 26), CategoriaId = 2 },
                new Producto { Id = 4, Nombre = "Sofá", Descripcion = "Sofá cómodo para sala de estar.", Precio = 499.99m, Stock = 20, FechaCreacion = new DateTime(2026, 5, 26), CategoriaId = 3 },
                new Producto { Id = 5, Nombre = "Lámpara de mesa", Descripcion = "Lámpara de mesa moderna para iluminación ambiental.", Precio = 89.99m, Stock = 40, FechaCreacion = new DateTime(2026, 5, 26), CategoriaId = 3 },
                new Producto { Id = 6, Nombre = "Auriculares", Descripcion = "Auriculares inalámbricos con cancelación de ruido.", Precio = 199.99m, Stock = 25, FechaCreacion = new DateTime(2026, 5, 26), CategoriaId = 1 }
            );
        }
    }
}
