using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Peliculas
{
    public class PeliculaService
    {
        private readonly PeliculaContext _context = new PeliculaContext();

        /// <summary>
        /// Crea una nueva película en la base de datos de forma asíncrona.
        /// </summary>
        /// <remarks>El identificador ImdbID debe estar establecido en la entidad proporcionada antes de llamar a este método. Si la operación se completa correctamente, la película se almacena de forma permanente
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

        /// <summary>
        /// Obtiene una película de forma asíncrona mediante su ImdbID.
        /// </summary>
        /// <remarks>Realiza una búsqueda en la base de datos por la clave primaria. Retorna null si no se encuentra ninguna coincidencia.</remarks>
        /// <param name="imdbID">El identificador único de IMDB de la película a buscar.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El valor contiene la película solicitada o null en caso de no existir.</returns>
        public async Task<Pelicula?> ObtenerPeliculaPorIdAsync(string imdbID)
        {
            return await _context.Peliculas.FindAsync(imdbID);
        }

        /// <summary>
        /// Obtiene asíncronamente el listado completo de películas en la base de datos.
        /// </summary>
        /// <remarks>Precaución: El uso de este método puede causar problemas de rendimiento o consumo excesivo de memoria en bases de datos muy grandes.</remarks>
        /// <returns>Una tarea que representa la operación asíncrona. Retorna una lista <see cref="List{Pelicula}"/> con todos los registros.</returns>
        public async Task<List<Pelicula>> ObtenerTodasLasPeliculasAsync()
        {
            return await _context.Peliculas.ToListAsync();
        }

        /// <summary>
        /// Actualiza la información de una película existente en la base de datos de forma asíncrona.
        /// </summary>
        /// <remarks>Localiza la película mediante su ImdbID. Si no existe, la operación concluye retornando false. En caso contrario, sobrescribe los valores existentes.</remarks>
        /// <param name="pelicula">La entidad de película que contiene los valores actualizados. Su propiedad ImdbID debe coincidir con un registro existente.</param>
        /// <returns>Una tarea asíncrona que contiene un valor booleano. Verdadero (true) indicando que la actualización fue exitosa, o Falso (false) si ocurrió un error o la película no existía.</returns>
        public async Task<bool> ActualizarPeliculaAsync(Pelicula pelicula)
        {
            try
            {
                var peliculaExistente = await _context.Peliculas.FindAsync(pelicula.ImdbID);
                if (peliculaExistente == null) 
                    return false;

                _context.Entry(peliculaExistente).CurrentValues.SetValues(pelicula);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception excepcion)
            {
                Console.WriteLine($"Error al actualizar la película: {excepcion.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina una película específica de forma asíncrona de la base de datos.
        /// </summary>
        /// <remarks>Busca la entidad por su identificador único (ImdbID) y si la encuentra, la remueve de la colección antes de guardar cambios.</remarks>
        /// <param name="imdbID">El identificador único de la película que se desea borrar.</param>
        /// <returns>Una tarea asíncrona con valor booleano, devolviendo true en caso de eliminación exitosa y false si no se encontró o se produjo un error.</returns>
        public async Task<bool> EliminarPeliculaAsync(string imdbID)
        {
            try
            {
                var peliculaExistente = await _context.Peliculas.FindAsync(imdbID);
                if (peliculaExistente == null) 
                    return false;

                _context.Peliculas.Remove(peliculaExistente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception excepcion)
            {
                Console.WriteLine($"Error al eliminar la película: {excepcion.Message}");
                return false;
            }
        }

        /// <summary>
        /// Obtiene una lista paginada de películas de forma asíncrona.
        /// </summary>
        /// <remarks>Este método es útil para mejorar el rendimiento en lecturas del Frontend limitando la cantidad de datos en memoria transferidos usando los operadores Skip y Take.</remarks>
        /// <param name="pagina">El número de página a mostrar (iniciando convencionalmente en 1).</param>
        /// <param name="cantidadPorPagina">La cantidad máxima de películas a recuperar por página.</param>
        /// <returns>Una tarea que representa la consulta asíncrona limitando los resultados a los indicados para la página actual.</returns>
        public async Task<List<Pelicula>> ObtenerPeliculasPaginadasAsync(int pagina, int cantidadPorPagina)
        {
            return await _context.Peliculas
                .Skip((pagina - 1) * cantidadPorPagina)
                .Take(cantidadPorPagina)
                .ToListAsync();
        }

        /// <summary>
        /// Realiza una búsqueda textual asíncrona de películas.
        /// </summary>
        /// <remarks>Realiza una búsqueda aproximada verificando si el título de la película contiene el texto proporcionado (similar a al operador LIKE en SQL).</remarks>
        /// <param name="busqueda">La cadena de texto a buscar. Si es nula o vacía devolverá una lista vacía.</param>
        /// <returns>Una tarea con la colección de películas cuyos títulos coincidan parcial o totalmente con el parámetro especificado.</returns>
        public async Task<List<Pelicula>> BuscarPeliculasPorTituloAsync(string busqueda)
        {
            if (string.IsNullOrWhiteSpace(busqueda))
                return new List<Pelicula>();

            return await _context.Peliculas
                .Where(p => EF.Functions.Like(p.Title, $"%{busqueda}%"))
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene un ranking de las películas mejor puntuadas.
        /// </summary>
        /// <remarks>Recupera una porción especificada de películas ordenadas descendentemente en base a su campo 'ImdbRating'.</remarks>
        /// <param name="cantidad">El número máximo de películas a retornar. Por defecto se limitará a 10.</param>
        /// <returns>Una lista de películas con las calificaciones de IMDB más altas, limitadas al número suministrado.</returns>
        public async Task<List<Pelicula>> ObtenerTopPeliculasMejorValoradasAsync(int cantidad = 10)
        {
            return await _context.Peliculas
                .OrderByDescending(p => p.ImdbRating)
                .Take(cantidad)
                .ToListAsync();
        }

        /// <summary>
        /// Realiza una consulta asíncrona para obtener las películas estrenadas en un año en concreto.
        /// </summary>
        /// <remarks>Verifica la columna temporal 'Year' para emparejar registros.</remarks>
        /// <param name="anio">El año exacto el cual servirá como filtro principal.</param>
        /// <returns>Una tarea asíncrona con el listado de películas emparejadas con el año indicado.</returns>
        public async Task<List<Pelicula>> ObtenerPeliculasPorAnioAsync(int anio)
        {
            return await _context.Peliculas
                .Where(p => p.Year == anio)
                .ToListAsync();
        }

        // Consultas sobre películas

        /// <summary>
        /// Consulta base de datos de manera asíncrona para obtener una estadística del rating máximo para cada género categorizado.
        /// </summary>
        /// <remarks>Itera por toda la tabla, la agrupa por género, la ordena por 'ImdbRating' descendentemente y recopila solo al representante mayor, incluyéndolo en un Diccionario C#.</remarks>
        /// <returns>Un diccionario asíncrono donde la clave (<c>string</c>) es el nombre del Género, y el valor (<c>Pelicula</c>) resulta la película mejor rankeada poseedora de ese género.</returns>
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


        /// <summary>
        /// Obtiene asíncronamente al director más prolífico (aquél con la mayor cuenta de apariciones contables) de los datos existentes.
        /// </summary>
        /// <remarks>Carga los datos y los contabiliza por agrupación de propiedad 'Director', devolviendo una estructura tipo tupla (Tuple).</remarks>
        /// <returns>Una tarea asíncrona en forma de tupla (Tuple) empaquetando una cadena de texto (Director) junto a su valor numérico contabilizado (Cantidad).</returns>
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