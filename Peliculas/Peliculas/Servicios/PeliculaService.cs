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
            _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();
            return pelicula.ImdbID;
        }


    }
}
