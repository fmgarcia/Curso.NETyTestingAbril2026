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

        public static void PoblarBaseDatosImdb(int imdbIDInicial, int numeroPeliculas, string key)
        {
            for (int i = imdbIDInicial; i < imdbIDInicial + numeroPeliculas; i++)
            {
                string imdbID = CambiarNumeroAImdbID(i);
                string url = $"{URL_BASE}{imdbID}{PARAMETROS}{key}";
                try
                {
                    Pelicula pelicula = UtilidadesJson<Pelicula>.DescargarJsonAsincrono(url).Result; // Aquí puedes llamar a UtilidadesJson.DescargarJsonAsincrono(url) para obtener los datos
                    peliculaService.CrearPeliculaAsync(pelicula).Wait();
                }
                catch (Exception excepcion)
                {
                    Console.WriteLine($"Error al procesar la película con IMDb ID {imdbID}: {excepcion.Message}");

                }
            }
        }


    }
}
