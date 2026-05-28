using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca
{
    // Esta clase se puede utilizar para implementar la lógica de negocio relacionada con la biblioteca,
    // como operaciones CRUD, consultas específicas, etc.
    // Es lo que se conoce como una capa de servicio, que actúa como intermediaria entre el controlador (o la interfaz de usuario) y el contexto de la base de datos.
    // Es un manejador de la lógica de negocio, y es donde se implementarán los métodos para interactuar con los datos de la biblioteca.

    public class BibliotecaService
    {
        private readonly BibliotecaContext _context = new BibliotecaContext();

        // ================================
        // C - CREATE (Crear)
        // ================================

        /// <summary>
        /// Crea un nuevo libro y lo asocia con los autores existentes a través de sus IDs.
        /// </summary>
        /// <param name="libro">El libro a crear.</param>
        /// <param name="autorIds"></param>
        /// <returns></returns>
        public async Task<int> CrearLibroConAutoresAsync(Libro libro, List<int> autorIds)
        {
            // Obtener los autores existentes por sus IDs
            libro.Autores = await _context.Autores.Where(a => autorIds.Contains(a.Id)).ToListAsync();
            // Agregar el libro al contexto y guardar cambios
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
            return libro.Id;
        }

        /// <summary>
        /// Crea un nuevo autor en la base de datos.
        /// </summary>
        /// <param name="autor">El autor a crear.</param>
        /// <returns></returns>
        public async Task<int> CrearAutorAsync(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
            return autor.Id;
        }

        // ================================
        // R - READ (Leer)
        // ================================

        /// <summary>
        /// Obtiene una lista de todos los libros en la base de datos, incluyendo sus autores asociados.
        /// </summary>
        /// <returns>Una lista de libros con sus autores.</returns>
        public async Task<List<Libro>> ObtenerLibrosConAutoresAsync()
        {
            return await _context.Libros
                .Include(l => l.Autores)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene de forma asincrónica un libro por su identificador único, incluyendo la información de sus autores
        /// asociados.
        /// </summary>
        /// <remarks>El resultado incluye los autores relacionados con el libro. Esta operación no realiza
        /// seguimiento de cambios sobre las entidades devueltas.</remarks>
        /// <param name="id">El identificador único del libro que se va a buscar. Debe ser un valor mayor que cero.</param>
        /// <returns>Un objeto <see cref="Libro"/> que representa el libro encontrado, o <see langword="null"/> si no existe
        /// ningún libro con el identificador especificado.</returns>
        public async Task<Libro?> ObtenerLibroPorIdAsync(int id)
        {
            return await _context.Libros
                .Include(l => l.Autores)
                .FirstOrDefaultAsync(l => l.Id == id);

        }

        /// <summary>
        /// Obtiene una lista de todos los autores en la base de datos, incluyendo sus libros asociados.
        /// </summary>
        /// <returns>Una lista de autores con sus libros.</returns>
        public async Task<List<Autor>> ObtenerAutoresConLibrosAsync()
        {
            return await _context.Autores
                .Include(a => a.Libros)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene de forma asincrónica un autor por su identificador, incluyendo la información de sus libros
        /// asociados.
        /// </summary>
        /// <remarks>El resultado incluye la colección de libros asociados al autor. Esta operación no
        /// realiza seguimiento de cambios sobre las entidades recuperadas.</remarks>
        /// <param name="id">El identificador único del autor a recuperar. Debe ser un valor mayor que cero.</param>
        /// <returns>Un objeto Autor que representa el autor encontrado, o null si no existe ningún autor con el identificador
        /// especificado.</returns>
        public async Task<Autor?> ObtenerAutorPorIdAsync(int id)
        {
            return await _context.Autores
                .Include(a => a.Libros)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        // ================================
        // U - UPDATE (Actualizar)
        // ================================

        /// <summary>
        /// Actualiza la información de un libro existente y sus autores asociados de forma asíncrona.
        /// </summary>
        /// <remarks>Los autores previamente asociados al libro serán reemplazados por los autores
        /// indicados en la lista. Los cambios se guardan en la base de datos al finalizar la operación.</remarks>
        /// <param name="libroModificado">El libro con los nuevos datos que se desean actualizar. Debe contener un identificador válido de un libro
        /// existente.</param>
        /// <param name="autorIds">La lista de identificadores de autores que se asociarán al libro. Cada identificador debe corresponder a un
        /// autor existente.</param>
        /// <returns>El libro actualizado, o null si no se encuentra el libro.</returns>
        /// <exception cref="ArgumentException">Se produce si el libro especificado no existe.</exception>
        public async Task<Libro?> ActualizarLibroAsync(Libro libroModificado, List<int> autorIds)
        {
            // Obtener el libro existente
            var libroExistente = await _context.Libros
                .Include(l => l.Autores)
                .FirstOrDefaultAsync(l => l.Id == libroModificado.Id);

            if (libroExistente == null)
            {
                throw new ArgumentException("El libro no existe.");
            }

            // Actualizar las propiedades del libro
            libroExistente.Titulo = libroModificado.Titulo;
            libroExistente.ISBN = libroModificado.ISBN;
            libroExistente.Anio = libroModificado.Anio;

            // Actualizar los autores asociados
            libroExistente.Autores.Clear(); // Limpiar autores actuales
            libroExistente.Autores = await _context.Autores  // Añadir los nuevos autores por sus IDs
                .Where(a => autorIds.Contains(a.Id))
                .ToListAsync();

            await _context.SaveChangesAsync();
            return libroExistente;
        }


        /// <summary>
        /// Actualiza la información de un autor existente de forma asíncrona.  
        /// </summary>
        /// <param name="autorModificado">El autor con los datos actualizados. Debe tener un identificador válido que corresponda a un autor
        /// existente.</param>
        /// <returns>El autor actualizado si la operación se realiza correctamente; de lo contrario, null.</returns>
        /// <exception cref="ArgumentException">Se produce si no existe un autor con el identificador especificado en <paramref name="autorModificado"/>.</exception>
        public async Task<Autor?> ActualizarAutorAsync(Autor autorModificado)
        {
            var autorExistente = await _context.Autores
                .Include(a => a.Libros)
                .FirstOrDefaultAsync(a => a.Id == autorModificado.Id);
            if (autorExistente == null)
            {
                throw new ArgumentException("El autor no existe.");
            }
            autorExistente.Nombre = autorModificado.Nombre;
            autorExistente.Pais = autorModificado.Pais;

            await _context.SaveChangesAsync();
            return autorExistente;

        }


        // ================================
        // D - DELETE (Eliminar)
        // ================================

        /// <summary>
        /// Elimina un libro de la base de datos de forma asíncrona, identificándolo por su ID. Si el libro existe, se eliminará junto con las asociaciones a sus autores.
        /// </summary>
        /// <param name="id">El ID del libro a eliminar.</param>
        /// <returns>True si el libro se eliminó correctamente; de lo contrario, false.</returns>
        public async Task<bool> EliminarLibroAsync(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return false; // No se encontró el libro
            }
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return true; // Libro eliminado exitosamente
        }


        /// <summary>
        /// Elimina de forma asíncrona el autor identificado por el identificador especificado.
        /// </summary>
        /// <remarks>Si no se encuentra ningún autor con el identificador proporcionado, no se realiza
        /// ninguna acción y el método devuelve <see langword="false"/>.</remarks>
        /// <param name="id">El identificador único del autor que se va a eliminar. Debe ser un valor positivo.</param>
        /// <returns>Un valor que indica si el autor fue eliminado correctamente. Devuelve <see langword="true"/> si el autor
        /// existía y fue eliminado; de lo contrario, <see langword="false"/>.</returns>
        public async Task<bool> EliminarAutorAsync(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
            {
                return false; // No se encontró el autor
            }
            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
            return true; // Autor eliminado exitosamente
        }

        // ================================
        // BÚSQUEDAS Y CONSULTAS ESPECÍFICAS
        // ================================

        // 1. Búsqueda por título de libro (contiene el texto, ignorando mayúsculas/minúsculas)
        /// <summary>
        /// Busca de forma asincrónica los libros cuyo título contiene el texto especificado, sin distinguir entre
        /// mayúsculas y minúsculas.
        /// </summary>
        /// <param name="texto">El texto a buscar dentro de los títulos de los libros. No distingue entre mayúsculas y minúsculas.</param>
        /// <returns>Una lista de objetos Libro que contienen el texto especificado en su título. Si no se encuentran
        /// coincidencias, se devuelve una lista vacía.</returns>
        public async Task<List<Libro>> BuscarLibrosPorTituloAsync(string texto)
        {
            return await _context.Libros
                .Include(l => l.Autores)
                //.Where(l => l.Titulo.Contains(texto, StringComparison.OrdinalIgnoreCase))
                .Where(l => l.Titulo.ToLower().Contains(texto.ToLower()))
                .ToListAsync();
        }


        // 2. Búsqueda de libros por año de publicación 
        /// <summary>
        /// Busca de forma asincrónica los libros cuyo año de publicación es igual al año especificado.
        /// </summary>
        /// <param name="anio">El año de publicación de los libros a buscar.</param>
        /// <returns>Una lista de objetos Libro que cumplen con el criterio de búsqueda. Si no se encuentran
        /// coincidencias, se devuelve una lista vacía.</returns>
        public async Task<List<Libro>> BuscarLibrosPorAnioAsync(int anio)
        {
            return await _context.Libros
                .Include(l => l.Autores)
                .Where(l => l.Anio == anio)
                .ToListAsync();
        }


        // 3. Búsqueda por nombre de autor (contiene el texto, ignorando mayúsculas/minúsculas)
        /// <summary>
        /// Busca de forma asincrónica los autores cuyo nombre contiene el texto especificado, sin distinguir entre
        /// mayúsculas y minúsculas.
        /// </summary>
        /// <param name="texto">El texto a buscar dentro de los nombres de los autores. No distingue entre mayúsculas y minúsculas.</param>
        /// <returns>Una lista de objetos Autor que contienen el texto especificado en su nombre. Si no se encuentran
        /// coincidencias, se devuelve una lista vacía.</returns>
        public async Task<List<Autor>> BuscarAutoresPorNombreAsync(string texto)
        {
            return await _context.Autores
                .Where(a => a.Nombre.ToLower().Contains(texto.ToLower()))
                .ToListAsync();
        }

        // 4. Búsqueda de los libros de un autor por nombre del autor (contiene el texto, ignorando mayúsculas/minúsculas)
        /// <summary>
        /// Busca de forma asincrónica los libros que tiene al menos un autor que contiene el texto especificado en su nombre, sin distinguir entre
        /// mayúsculas y minúsculas.
        /// </summary>
        /// <param name="texto">El texto a buscar dentro de los nombres de los autores. No distingue entre mayúsculas y minúsculas.</param>
        /// <returns>Una lista de objetos Libro que contienen el texto especificado en el nombre de su autor. Si no se encuentran
        /// coincidencias, se devuelve una lista vacía.</returns>
        public async Task<List<Libro>> BuscarLibrosPorNombreAutorAsync(string texto)
        {
            return await _context.Libros
                .Include(l => l.Autores)
                // Any verifica si al menos un autor del libro cumple con la condición de contener el texto en su nombre, ignorando mayúsculas/minúsculas
                .Where(l => l.Autores.Any(a => a.Nombre.ToLower().Contains(texto.ToLower())))
                .ToListAsync();
        }
    }
}