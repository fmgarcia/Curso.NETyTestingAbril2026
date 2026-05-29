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

        // Lista temporal estática u oculta en sesión para mostrar los mensajes. 
        // Para simplificar la demo, los guardaremos en TempData, lo cual es ideal para mensajes entre Post/Get en web.
        public List<string> MensajesOperacion { get; set; } = new List<string>();

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

            // Realizamos la importación aquí e iteramos directamente.
            var listaMensajes = new List<string>();

            // Para no sobrecargar la UI web con 100 llamadas HTTP de muy larga duración, 
            // este es un bucle que bloqueará al usuario hasta finalizar. 
            // En proyectos muy grandes esto debiese ser manejado por WebSockets (SignalR) o colas.
            for (int i = ImdbIDInicial; i < ImdbIDInicial + NumeroPeliculas; i++)
            {
                string status = await UtilidadesImdb.ImportarPeliculaIndividualAsync(i, OmdbApiKey);
                listaMensajes.Add(status);
            }

            TempData["MensajesImportacion"] = string.Join("||", listaMensajes);

            // Volvemos a trazar la vista para poder mostrar el log
            return RedirectToPage("./Import");
        }
    }
}