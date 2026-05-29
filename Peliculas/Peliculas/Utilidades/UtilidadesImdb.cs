using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peliculas
{
    static public class UtilidadesImdb
    {

        static string URL_BASE = "https://www.omdbapi.com/?i=tt";
        static string PARAMETROS = "&apikey=";
        static PeliculaService peliculaService = new PeliculaService();


        private static string CambiarNumeroAImdbID(int numero)
        {
            return numero.ToString("D7");
        }

        // Método extraído que procesa una única película de forma íntegra para poder llamarla paso a paso desde el Frontend
        public static async Task<string> ImportarPeliculaIndividualAsync(int i, string key)
        {
            string imdbIDNumerico = CambiarNumeroAImdbID(i);
            string imdbIDCompleto = $"tt{imdbIDNumerico}";
            string url = $"{URL_BASE}{imdbIDNumerico}{PARAMETROS}{key}";
            
            try
            {
                var peliculaExistente = await peliculaService.ObtenerPeliculaPorIdAsync(imdbIDCompleto);
                if (peliculaExistente != null)
                {
                    return $"⚠️ Omitido: {imdbIDCompleto} ya está registrada.";
                }

                Pelicula pelicula = await UtilidadesJson<Pelicula>.DescargarJsonAsincrono(url); 

                if (pelicula != null && !string.IsNullOrWhiteSpace(pelicula.Title) && pelicula.Title != "N/A")
                {
                    if (string.IsNullOrWhiteSpace(pelicula.ImdbID) || pelicula.ImdbID == "N/A")
                        pelicula.ImdbID = imdbIDCompleto;

                    await peliculaService.CrearPeliculaAsync(pelicula);
                    return $"✅ Insertado: {imdbIDCompleto} ('{pelicula.Title}') añadida con éxito.";
                }
                
                return $"❌ Ignorado: {imdbIDCompleto} devuelto como nulo o no encontrado en OMDB.";
            }
            catch (Exception excepcion)
            {
                return $"💥 Error: Excepción procesando {imdbIDCompleto} ({excepcion.Message}).";
            }
        }

        // Mantenemos el método general por si se invoca desde la consola u otros clientes
        public static async Task PoblarBaseDatosImdbAsync(int imdbIDInicial, int numeroPeliculas, string key)
        {
            for (int i = imdbIDInicial; i < imdbIDInicial + numeroPeliculas; i++)
            {
                string mensaje = await ImportarPeliculaIndividualAsync(i, key);
                Console.WriteLine(mensaje);
            }
        }


        public static async Task MejorPeliculaPorGeneroAsync()
        {
            var mejorPeliculaPorGenero = await peliculaService.ObtenerMejorPeliculaPorGeneroAsync();
            foreach (var genero in mejorPeliculaPorGenero.Keys)
            {
                Console.WriteLine($"Género: {genero}, Mejor Película: {mejorPeliculaPorGenero[genero].Title}, Puntuación: {mejorPeliculaPorGenero[genero].ImdbRating}");
            }
        }

        public static async Task DirectorConMasPeliculas()
        {
            var directorConMasPeliculas = await peliculaService.ObtenerDirectorConMasPeliculasAsync();
            Console.WriteLine($"Director con más películas: {directorConMasPeliculas.Director}, Cantidad de películas: {directorConMasPeliculas.Cantidad}");

        }
    }
}
