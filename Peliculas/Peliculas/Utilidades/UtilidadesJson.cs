using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Peliculas
{
    public static class UtilidadesJson<T>
    {
        /// <summary>
        /// Obtiene datos de una URL y los deserializa a un objeto del tipo T de forma asíncrona.
        /// </summary>
        /// <param name="url">La URL desde la cual se obtendrán los datos JSON.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El valor de la tarea contiene el objeto deserializado del tipo T.</returns>
        public static async Task<T> DescargarJsonAsincrono(string url)
        {
            try
            {
                using var client = new HttpClient();
                T? resultado = await client.GetFromJsonAsync<T>(url);
                return resultado!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos: {ex.Message}");
                return default(T)!;
            }
        }


    }
}
