using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext() { }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; } = null!;
        public DbSet<Libro> Libros { get; set; } = null!;

        // Configuración de la conexión a la base de datos. En este caso, se utiliza SQLLite LocalDB.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuración de la cadena de conexión a la base de datos.
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\Fran\Documents\EOI2026\04_NetTestingAbril\Proyectos\Biblioteca\Biblioteca\biblioteca.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // 1. Insertar Autores (Clave: Usar IDs fijos)
            modelBuilder.Entity<Autor>().HasData(
                new Autor { Id = 1, Nombre = "J.R.R. Tolkien", Pais = "Reino Unido" },
                new Autor { Id = 2, Nombre = "Brandon Sanderson", Pais = "Estados Unidos" },
                new Autor { Id = 3, Nombre = "Neil Gaiman", Pais = "Reino Unido" },
                new Autor { Id = 4, Nombre = "Terry Pratchett", Pais = "Reino Unido" }
            );

            // 2. Insertar Libros (Clave: Usar IDs fijos)
            modelBuilder.Entity<Libro>().HasData(
                new Libro { Id = 1, Titulo = "El Señor de los Anillos", ISBN = "978-0261103252", Anio = 1954 },
                new Libro { Id = 2, Titulo = "El Imperio Final", ISBN = "978-8466656948", Anio = 2006 },
                new Libro { Id = 3, Titulo = "Buenos Presagios", ISBN = "978-8445077926", Anio = 1990 },
                new Libro { Id = 4, Titulo = "El Hobbit", ISBN = "978-0261102217", Anio = 1937 }
            );

            // Configuración explícita de la relación N:M entre Autor y Libro utilizando Fluent API
            modelBuilder.Entity<Libro>()
                .HasMany(l => l.Autores)
                .WithMany(a => a.Libros)
                .UsingEntity(j =>
                {
                    j.ToTable("LibrosAutores"); // Nombre de la tabla intermedia
                    // Insertamos los datos de unión  usando IDs fijos para garantizar la consistencia. Son tipos anónimos porque no tenemos una clase explícita para la tabla intermedia.
                    j.HasData(
                        new { LibrosId = 1, AutoresId = 1 }, // El Señor de los Anillos - J.R.R. Tolkien
                        new { LibrosId = 2, AutoresId = 2 }, // El Imperio Final - Brandon Sanderson
                        new { LibrosId = 3, AutoresId = 3 }, // Buenos Presagios - Neil Gaiman
                        new { LibrosId = 3, AutoresId = 4 }, // Buenos Presagios - Terry Pratchett
                        new { LibrosId = 4, AutoresId = 1 }  // El Hobbit - J.R.R. Tolkien
                    );

                });


        }

    }
}
