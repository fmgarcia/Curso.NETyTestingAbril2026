using System;
using System.Collections.Generic;
using System.Text;

namespace POOLinq
{
    static public class UtilidadesTextos
    {

        // Definimos un array de caracteres que se considerarán como separadores de palabras
        static char[] separadores = new char[] { ' ', '\t', '\n', '\r', '.', ',', ';', ':', '!', '?', '-', '_', '(', ')', '[', ']', '{', '}', '"', '\'', '!', '¡' };
        // Definimos un array de caracteres que se considerarán como vocales para el conteo de vocales
        static char[] vocales = new char[] { 'a', 'e', 'i', 'o', 'u', 'á', 'é', 'í', 'ó', 'ú', 'à', 'è', 'ì', 'ò', 'ù', 'ä', 'ë', 'ï', 'ö', 'ü', 'â', 'ê', 'î', 'ô', 'û' }; // Definimos un array de vocales


        /// <summary>
        /// Dado un texto, contar cuántas veces aparece cada palabra y devolver un diccionario con el resultado.
        /// </summary>
        /// <param name="texto">El texto a analizar.</param>
        /// <returns>Un diccionario donde la clave es la palabra y el valor es la cantidad de veces que aparece.</returns>
        static public Dictionary<string, int> ContarPalabras(string texto)
        {
            var resultado = new Dictionary<string, int>();
            // Si el texto es nulo o vacío, devolvemos un diccionario vacío
            if (string.IsNullOrWhiteSpace(texto))
                return resultado;

            resultado = texto.ToLower() // Convertimos el texto a minúsculas para contar palabras sin distinguir mayúsculas/minúsculas
                .Split(separadores, StringSplitOptions.RemoveEmptyEntries) // Separamos el texto en palabras usando los separadores definidos
                .GroupBy(p => p) // Agrupamos las palabras iguales
                .ToDictionary(g => g.Key, g => g.Count()); // Creamos un diccionario donde la clave es la palabra y el valor es la cantidad de veces que aparece

            return resultado;
        }

        /// <summary>
        /// Encuentra la palabra más frecuente en el texto dado. En caso de empate, devuelve una de las palabras más frecuentes.
        /// </summary>
        /// <param name="texto">El texto a analizar.</param>
        /// <returns>La palabra más frecuente en el texto.</returns>
        static public string PalabraMasFrecuente(string texto)
        {
            string resultado = string.Empty;
            if (string.IsNullOrWhiteSpace(texto)) // Si el texto es nulo o vacío, devolvemos una cadena vacía
                return resultado;

            var palabras = ContarPalabras(texto);  // Obtenemos el diccionario de palabras y sus frecuencias
            if (palabras.Count == 0)    // Si no hay palabras, devolvemos una cadena vacía
                return resultado;

            // Encontramos la palabra con la mayor frecuencia
            return palabras
                .OrderByDescending(p => p.Value)
                .First()
                .Key;
        }

        /// <summary>
        /// Dado un texto y un número mínimo de letras, voy a devolver una lista de las palabras que tienen al menos ese mínimo de letras, ordenadas alfabéticamente.
        /// </summary>
        /// <param name="texto">El texto a analizar.</param>
        /// <param name="numeroMinimoLetras">Entero que representa el número mínimo de letras que debe tener una palabra para ser incluida en la lista.</param>
        /// <returns>Una lista de palabras que cumplen con el criterio, ordenadas alfabéticamente.</returns>
        static public List<string> OrdenarAlfabeticamentePalabrasNLetras(string texto, int numeroMinimoLetras)
        {
            if (string.IsNullOrWhiteSpace(texto)) // Si el texto es nulo o vacío, devolvemos una cadena vacía
                return new List<string>();

            return texto.ToLower() // Convertimos el texto a minúsculas para contar palabras sin distinguir mayúsculas/minúsculas
                .Split(separadores, StringSplitOptions.RemoveEmptyEntries) // Separamos el texto en palabras usando los separadores definidos
                .Where(p => p.Length >= numeroMinimoLetras) // Filtramos las palabras que tienen al menos el número mínimo de letras
                .Distinct() // Eliminamos palabras duplicadas
                .OrderBy(p => p) // Ordenamos alfabéticamente
                .ToList(); // Convertimos a lista
        }

        /// <summary>
        /// Dado un texto contar cuántas vocales tiene. Se deben contar tanto las vocales mayúsculas como las minúsculas. Cuenta también las vocales acentuadas, con diéresis o cincunflejo.
        /// </summary>
        /// <param name="texto">El texto a analizar.</param>
        /// <returns>El número de vocales en el texto.</returns>
        static public int ContarVocales(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) // Si el texto es nulo o vacío, devolvemos 0
                return 0;

            return texto.ToLower() // Convertimos el texto a minúsculas para contar vocales sin distinguir mayúsculas/minúsculas
                .Count(c => vocales.Contains(c)); // Contamos cuántos caracteres en el texto son vocales
        }



    }
}
