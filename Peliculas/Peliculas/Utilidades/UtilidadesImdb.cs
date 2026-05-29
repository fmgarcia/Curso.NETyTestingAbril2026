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

        public static async Task PoblarBaseDatosImdbAsync(int imdbIDInicial, int numeroPeliculas, string key)
        {
            for (int i = imdbIDInicial; i < imdbIDInicial + numeroPeliculas; i++)
            {
                string imdbIDNumerico = CambiarNumeroAImdbID(i);
                string imdbIDCompleto = $"tt{imdbIDNumerico}";
                string url = $"{URL_BASE}{imdbIDNumerico}{PARAMETROS}{key}";
                try
                {
                    // 1. Verificamos si la película ya existe para no intentar insertarla de nuevo
                    var peliculaExistente = await peliculaService.ObtenerPeliculaPorIdAsync(imdbIDCompleto);
                    if (peliculaExistente != null)
                    {
                        continue; // Ya existe en la base de datos, pasamos a la siguiente
                    }

                    // 2. Descargar de forma asíncrona (usamos await en lugar de .Result)
                    Pelicula pelicula = await UtilidadesJson<Pelicula>.DescargarJsonAsincrono(url); 

                    // 3. Validar si el JSON obtenido tenía realmente formato de película (y no un error de OMDB como "Movie not found!")
                    if (pelicula != null && !string.IsNullOrWhiteSpace(pelicula.Title) && pelicula.Title != "N/A")
                    {
                        // Aseguramos que el identificador está bien formateado
                        if (string.IsNullOrWhiteSpace(pelicula.ImdbID) || pelicula.ImdbID == "N/A")
                            pelicula.ImdbID = imdbIDCompleto;

                        await peliculaService.CrearPeliculaAsync(pelicula);
                    }
                }
                catch (Exception excepcion)
                {
                    // 4. Si el JSON no pudo parsearse o hubo otro fallo, imprimimos en consola y el bucle continúa
                    Console.WriteLine($"Error al procesar la película con IMDb ID {imdbIDCompleto}: {excepcion.Message}");
                }
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
