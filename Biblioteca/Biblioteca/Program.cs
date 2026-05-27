namespace Biblioteca
{
    internal class Program
    {

        static BibliotecaService servicio = new BibliotecaService();

        static async Task CrearAutoresLibros()
        {
            // Crear autor
            var autor = new Autor
            {
                Nombre = "Gabriel García Márquez",
                Pais = "Colombiana"
            };
            int codigoAutor = await servicio.CrearAutorAsync(autor);

            // Crear un libro
            var libro = new Libro
            {
                Titulo = "Cien Años de Soledad",
                ISBN = "978-3-16-148410-0",
                Anio = 1967
            };
            int codigoLibro = await servicio.CrearLibroConAutoresAsync(libro, new List<int> { codigoAutor });
            Console.WriteLine($"Libro creado con ID: {codigoLibro}");
        }

        static async Task MostrasDatosLibrosAutores()
        {

            Console.WriteLine($"Mostrar todos los libros con sus autores:");
            var librosConAutores = await servicio.ObtenerLibrosConAutoresAsync();
            foreach (var libro in librosConAutores)
            {
                Console.WriteLine($"Libro: {libro.Titulo} (ISBN: {libro.ISBN}, Año: {libro.Anio})");
                Console.WriteLine("Autores:");
                foreach (var autor in libro.Autores)
                {
                    Console.WriteLine($"- {autor.Nombre} ({autor.Pais})");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Mostrar el libro con ID 1:");
            var libroPorId = await servicio.ObtenerLibroPorIdAsync(1); // Obtener el libro con ID 1
            if (libroPorId != null)
            {
                Console.WriteLine($"Libro: {libroPorId.Titulo} (ISBN: {libroPorId.ISBN}, Año: {libroPorId.Anio})");
                Console.WriteLine("Autores:");
                foreach (var autor in libroPorId.Autores)
                {
                    Console.WriteLine($"- {autor.Nombre} ({autor.Pais})");
                }
                Console.WriteLine();
            }


            Console.WriteLine($"Mostrar todos los autores con sus libros:");
            var autoresConLibros = await servicio.ObtenerAutoresConLibrosAsync();
            foreach (var autor in autoresConLibros)
            {
                Console.WriteLine($"Autor: {autor.Nombre} ({autor.Pais})");
                Console.WriteLine("Libros:");
                foreach (var libro in autor.Libros)
                {
                    Console.WriteLine($"- {libro.Titulo} (ISBN: {libro.ISBN}, Año: {libro.Anio})");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Mostrar el autor con ID 1:");
            var autorPorId = await servicio.ObtenerAutorPorIdAsync(1); // Obtener el autor con ID 1
            if (autorPorId != null)
            {
                Console.WriteLine($"Autor: {autorPorId.Nombre} ({autorPorId.Pais})");
                Console.WriteLine("Libros:");
                foreach (var libro in autorPorId.Libros)
                {
                    Console.WriteLine($"- {libro.Titulo} (ISBN: {libro.ISBN}, Año: {libro.Anio})");
                }
                Console.WriteLine();
            }


        }


        static async Task ActualizarLibroAutor()
        {
            // Actualizar autor
            var datosNuevos = new Autor
            {
                Id = 5, // ID del autor a modificar
                Nombre = "Gabriel GM",
                Pais = "Colombia"
            };

            var autorActualizado = await servicio.ActualizarAutorAsync(datosNuevos);
            Console.WriteLine($"{(autorActualizado != null ?
                $"Autor actualizado:  {autorActualizado.Nombre} {autorActualizado.Pais}"
                : "No se pudo actualizar el autor")}");

            // Actualizar libro
            int IdModificar = 5; // ID del libro a modificar
            var datosNuevosLibro = new Libro
            {
                Id = IdModificar,
                Titulo = "Cien Años de Soledad - Edición Especial",
                ISBN = "978-3-16-148410-0",
                Anio = 2024
            };
            var autoresNuevoLibro = new List<int> { 1 }; // Asociar el libro al autor actualizado
            var libroActualizado = await servicio.ActualizarLibroAsync(datosNuevosLibro, autoresNuevoLibro);
            Console.WriteLine($"{(libroActualizado != null ?
                $"Libro actualizado: {libroActualizado.Titulo} (ISBN: {libroActualizado.ISBN}, Año: {libroActualizado.Anio})"
                : "No se pudo actualizar el libro")}");
        }

        static async Task Main(string[] args)
        {
            //await CrearAutoresLibros();
            //await MostrasDatosLibrosAutores();
            await ActualizarLibroAutor();


        }
    }
}
