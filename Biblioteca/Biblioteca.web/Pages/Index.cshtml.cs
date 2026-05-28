using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca
{
    public class IndexModel : PageModel
    {
        private readonly BibliotecaService _servicio = new BibliotecaService(); // Instancia del contexto de la base de datos para acceder a los datos
        public List<Libro> Libros { get; set; } = new List<Libro>();  // Propiedad para almacenar los libros que se mostrarán en la vista
        public List<Autor> Autores { get; set; } = new List<Autor>(); // Propiedad para almacenar los autores que se mostrarán en la vista


        [BindProperty(SupportsGet = true)] // Permite enlazar el término de búsqueda desde la consulta GET
        public string BuscarLibro { get; set; } = string.Empty; // Propiedad para almacenar el término de búsqueda ingresado por el usuario

        [BindProperty(SupportsGet = true)] // Permite enlazar el término de búsqueda desde la consulta GET
        public string BuscarAutor { get; set; } = string.Empty; // Propiedad para almacenar el término de búsqueda de autor ingresado por el usuario

        [BindProperty] // Permite enlazar los datos del nuevo libro desde el formulario POST
        public Libro NuevoLibro { get; set; } = new Libro(); // Propiedad para almacenar los datos del nuevo libro que se va a agregar
        [BindProperty]
        public Autor NuevoAutor { get; set; } = new Autor(); // Propiedad para almacenar los datos del nuevo autor que se va a agregar


        [BindProperty] // Permite enlazar los IDs de los autores seleccionados desde el formulario POST
        public List<int> IdsAutoresSeleccionados { get; set; } = new List<int>(); // Propiedad para almacenar los IDs de los autores seleccionados



        public async Task OnGetAsync()
        {
            // Filtro de los libros usando los métodos del servicio.
            // Si el término de búsqueda no está vacío, se buscan los libros por título;
            // de lo contrario, se obtienen todos los libros con sus autores.
            if (!string.IsNullOrEmpty(BuscarLibro))
            {
                Libros = await _servicio.BuscarLibrosPorTituloAsync(BuscarLibro);
            }
            else
            {
                Libros = await _servicio.ObtenerLibrosConAutoresAsync();
            }

            // Filtro de los autores usando los métodos del servicio.
            if (!string.IsNullOrEmpty(BuscarAutor))
            {
                Autores = await _servicio.BuscarAutoresPorNombreAsync(BuscarAutor);
            }
            else
            {
                Autores = await _servicio.ObtenerAutoresConLibrosAsync();
            }

        }

        // Método para manejar la solicitud POST de agregar un nuevo libro.
        // Se valida el modelo y, si es válido, se llama al servicio para crear el libro con los autores seleccionados.
        public async Task<IActionResult> OnPostCrearLibroAsync()
        {
            // Agregar el nuevo libro a la base de datos
            await _servicio.CrearLibroConAutoresAsync(NuevoLibro, IdsAutoresSeleccionados);
            return RedirectToPage(); // Redirige a la misma página para mostrar el libro agregado
        }

        // Método para manejar la solicitud POST de agregar un nuevo autor.
        public async Task<IActionResult> OnPostCrearAutorAsync()
        {
            // Agregar el nuevo autor a la base de datos
            await _servicio.CrearAutorAsync(NuevoAutor);
            return RedirectToPage(); // Redirige a la misma página para mostrar el autor agregado

        }

        // Métodos de eliminaciones de libros y autores
        public async Task<IActionResult> OnPostEliminarLibroAsync(int id)
        {
            await _servicio.EliminarLibroAsync(id);
            return RedirectToPage(); // Redirige a la misma página para mostrar los cambios
        }

        public async Task<IActionResult> OnPostEliminarAutorAsync(int id)
        {
            await _servicio.EliminarAutorAsync(id);
            return RedirectToPage(); // Redirige a la misma página para mostrar los cambios
        }

    }
}
