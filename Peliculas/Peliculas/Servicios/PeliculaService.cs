using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peliculas
{
    public class PeliculaService
    {
        private readonly PeliculaContext _context = new PeliculaContext();

        /// <summary>
        /// Crea una nueva película en la base de datos de forma asíncrona.
        /// </summary>
        /// <remarks>El identificador ImdbID debe estar establecido en la entidad proporcionada antes de
        /// llamar a este método. Si la operación se completa correctamente, la película se almacena de forma permanente
        /// en la base de datos.</remarks>
        /// <param name="pelicula">La entidad de película que se va a agregar. No puede ser null. Debe contener un identificador ImdbID válido.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El valor de la tarea contiene el identificador ImdbID de la
        /// película creada.</returns>
        public async Task<string> CrearPeliculaAsync(Pelicula pelicula)
        {
            try
            {
                _context.Peliculas.Add(pelicula);
                await _context.SaveChangesAsync();
                return pelicula.ImdbID;
            }
            catch (Exception excepcion)
            {
                Console.WriteLine($"Error al crear la película: {excepcion.Message}");
                return string.Empty;
            }
        }


        // Consultas sobre películas

        // Quiero devolver la mejor película por género, es decir, la película con el rating de IMDB más alto para un género específico.
        // El método debe ser asíncrono y devolver para cada género la película con el rating más alto.
        // El resultado debe ser un diccionario donde la clave es el género y el valor es la película correspondiente.
        public async Task<Dictionary<string, Pelicula>> ObtenerMejorPeliculaPorGeneroAsync()
        {
            try
            {
                var peliculas = await _context.Peliculas.ToListAsync();
                var resultado = peliculas
                    .GroupBy(p => p.Genre)
                    .ToDictionary(
                        g => g.Key,
                        g => g.OrderByDescending(p => p.ImdbRating).FirstOrDefault()
                    );
                return resultado!;
            }
            catch (Exception excepcion)
            {
                Console.WriteLine($"Error al obtener la mejor película por género: {excepcion.Message}");
                return new Dictionary<string, Pelicula>();
            }
        }


        // Quiero obtener el director con más películas en la base de datos.
        // El método debe ser asíncrono y devolver el nombre del director que tiene la mayor cantidad de películas registradas, junto con el número de películas que ha dirigido.
        public async Task<(string Director, int Cantidad)> ObtenerDirectorConMasPeliculasAsync()
        {
            try
            {
                var peliculas = await _context.Peliculas.ToListAsync();
                var directorConMasPeliculas = peliculas
                    .GroupBy(p => p.Director)
                    .OrderByDescending(g => g.Count())
                    .Select(g => (Director: g.Key, Cantidad: g.Count()))
                    .FirstOrDefault();
                return directorConMasPeliculas;
            }
            catch (Exception excepcion)
            {
                Console.WriteLine($"Error al obtener el director con más películas: {excepcion.Message}");
                return (string.Empty, 0);
            }
        }
    }
}