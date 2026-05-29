using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Peliculas;

namespace Pelicula.web.Pages
{
    public class CreateModel : PageModel
    {
        private readonly PeliculaService _peliculaService;

        public CreateModel()
        {
            _peliculaService = new PeliculaService();
        }

        [BindProperty]
        public Peliculas.Pelicula PeliculaData { get; set; } = new Peliculas.Pelicula();

        public void OnGet()
        {
            // Inicialización al cargar la página si es necesario
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Si las validaciones fallan, retorna a la página mostrando los errores.
            }

            // Crea la película llamando al servicio local
            await _peliculaService.CrearPeliculaAsync(PeliculaData);

            // Redirige al listado principal
            return RedirectToPage("./Index");
        }
    }
}