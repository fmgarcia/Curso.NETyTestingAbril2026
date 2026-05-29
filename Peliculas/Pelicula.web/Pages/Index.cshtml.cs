using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Peliculas; // Agregado para usar las clases PeliculaContext/PeliculaService si correspondieran

namespace Pelicula.web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PeliculaService _peliculaService;

        public IndexModel()
        {
            _peliculaService = new PeliculaService();
        }

        public IList<Peliculas.Pelicula> Peliculas { get; set; } = new List<Peliculas.Pelicula>();

        [BindProperty(SupportsGet = true)]
        public string? BuscarTitulo { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PaginaActual { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int ElementosPorPagina { get; set; } = 10;

        [BindProperty(SupportsGet = true)]
        public string? OrdenPor { get; set; }

        public SelectList OpcionesPaginacion { get; set; } = new SelectList(new[] { 5, 10, 20, 50 });

        public async Task OnGetAsync()
        {
            // Inicializar la lista por si el servicio devuelve vacío
            Peliculas = new List<Peliculas.Pelicula>();

            if (!string.IsNullOrWhiteSpace(BuscarTitulo))
            {
                // Si hay búsqueda, obviamos paginación y ordenamiento complejo para simplificar en esta demo, 
                // pero se podría integrar un método de servicio más avanzado.
                Peliculas = await _peliculaService.BuscarPeliculasPorTituloAsync(BuscarTitulo);
            }
            else
            {
                // Obtener paginados
                Peliculas = await _peliculaService.ObtenerPeliculasPaginadasAsync(PaginaActual, ElementosPorPagina);
            }

            // Aplicar ordenamiento en memoria (idealmente debería delegarse al servicio/Entity Framework para mayor eficiencia)
            if (Peliculas != null && Peliculas.Any())
            {
                switch (OrdenPor)
                {
                    case "Titulo":
                        Peliculas = Peliculas.OrderBy(p => p.Title).ToList();
                        break;
                    case "TituloDesc":
                        Peliculas = Peliculas.OrderByDescending(p => p.Title).ToList();
                        break;
                    case "Anio":
                        Peliculas = Peliculas.OrderBy(p => p.Year).ToList();
                        break;
                    case "AnioDesc":
                        Peliculas = Peliculas.OrderByDescending(p => p.Year).ToList();
                        break;
                    case "Rating":
                        Peliculas = Peliculas.OrderBy(p => p.ImdbRating).ToList();
                        break;
                    case "RatingDesc":
                        Peliculas = Peliculas.OrderByDescending(p => p.ImdbRating).ToList();
                        break;
                    default:
                        // Orden por defecto, puede ser por Id o simplemente mantener como viene
                        break;
                }
            }
        }
        
        public async Task<IActionResult> OnPostEliminarAsync(string imdbID)
        {
            if (string.IsNullOrEmpty(imdbID))
                return RedirectToPage();

            await _peliculaService.EliminarPeliculaAsync(imdbID);
            
            return RedirectToPage();
        }
    }
}
