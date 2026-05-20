using System;
using System.Collections.Generic;
using System.Text;
using System.IO; // Necesario para trabajar con archivos
using System.Text.Json; // Necesario para la serialización JSON


namespace EjerciciosPOOListas2005
{
    internal class SerializarObjeto<T>
    {

        public T objeto { get; set; }

        // Constructor genérico para inicializar el objeto a serializar
        public SerializarObjeto(T objeto) { this.objeto = objeto; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase SerializarObjeto utilizando el nombre de fichero especificado.
        /// </summary>
        /// <param name="nombreFichero">El nombre del fichero que se utilizará para la serialización. No puede ser nulo ni una cadena vacía.</param>
        public void Serializar(string nombreFichero)
        {

            // Convertimos el objeto a una cadena JSON utilizando la serialización de System.Text.Json
            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true, // Para que el JSON sea más legible, tabulándolo
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Para usar camelCase en las propiedades
            };
            string json = JsonSerializer.Serialize(objeto, opciones);
            // Escribimos la cadena JSON en el archivo especificado
            File.WriteAllText(nombreFichero, json);
        }

        /// <summary>
        /// Deserializa el contenido de un archivo JSON en una instancia del tipo especificado.
        /// </summary>
        /// <remarks>Utiliza System.Text.Json para la deserialización y aplica la convención camelCase a
        /// las propiedades. El tipo T debe ser compatible con la deserialización JSON.</remarks>
        /// <param name="nombreFichero">La ruta y el nombre del archivo JSON que se va a deserializar. No puede ser nulo ni estar vacío.</param>
        /// <returns>Una instancia del tipo T que representa los datos deserializados del archivo JSON.</returns>
        /// <exception cref="FileNotFoundException">Se produce si el archivo especificado por nombreFichero no existe.</exception>
        public T Deserializar(string nombreFichero)
        {
            if (!File.Exists(nombreFichero))
            {
                throw new FileNotFoundException($"El archivo '{nombreFichero}' no existe.");
            }
            // Leemos el contenido del archivo JSON
            string json = File.ReadAllText(nombreFichero);
            // Convertimos la cadena JSON de vuelta a un objeto del tipo T utilizando la deserialización de System.Text.Json
            var opciones = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Para usar camelCase en las propiedades
            };
            return JsonSerializer.Deserialize<T>(json, opciones)!;

        }
    }
}
