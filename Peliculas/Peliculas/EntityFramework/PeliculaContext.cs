using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peliculas
{
    public class PeliculaContext : DbContext
    {
        public DbSet<Pelicula> Peliculas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\Fran\Documents\EOI2026\04_NetTestingAbril\Proyectos\Peliculas\Peliculas\peliculas.db");
        }
    }
}
