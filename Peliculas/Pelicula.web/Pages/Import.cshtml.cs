using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Peliculas;

namespace Pelicula.web.Pages
{
    public class ImportModel : PageModel
    {
        [BindProperty]
        public int ImdbIDInicial { get; set; } = 111161; // Valor por defecto sugerido (ej. "Cadena Perpetua")

        [BindProperty]
        public int NumeroPeliculas { get; set; } = 10;

        [BindProperty]
        public string OmdbApiKey { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(OmdbApiKey))
            {
                ModelState.AddModelError(string.Empty, "Debe proveer una Api Key válida de OMDB.");
                return Page();
            }

            // Llamamos al método utilitario
            await UtilidadesImdb.PoblarBaseDatosImdbAsync(ImdbIDInicial, NumeroPeliculas, OmdbApiKey);

            // Tras la importación finalizada, devolvemos al usuario al índice principal de películas
            return RedirectToPage("./Index");
        }
    }
}