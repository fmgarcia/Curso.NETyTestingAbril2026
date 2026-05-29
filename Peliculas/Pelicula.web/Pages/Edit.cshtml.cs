using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Peliculas;

namespace Pelicula.web.Pages
{
    public class EditModel : PageModel
    {
        private readonly PeliculaService _peliculaService;

        public EditModel()
        {
            _peliculaService = new PeliculaService();
        }

        [BindProperty]
        public Peliculas.Pelicula PeliculaData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string imdbID)
        {
            if (string.IsNullOrEmpty(imdbID))
            {
                return NotFound();
            }

            var peliculaBuscada = await _peliculaService.ObtenerPeliculaPorIdAsync(imdbID);

            if (peliculaBuscada == null)
            {
                return NotFound();
            }

            PeliculaData = peliculaBuscada;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var seActualizo = await _peliculaService.ActualizarPeliculaAsync(PeliculaData);

            if (!seActualizo)
            {
                // Si ocurre un error, añadimos un mensaje genérico al modelo
                ModelState.AddModelError(string.Empty, "Hubo un error al actualizar. Puede que la película ya no exista.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}