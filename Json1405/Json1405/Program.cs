using System.Net.Http.Json;
using System.Text.Json;


namespace Json1405
{
    internal class Program
    {

        static ModeloDatos.DatosEmpresa JsonLocal(string rutaDirectorio, string nombreFichero)
        {
            // 1. Definimos la ruta del fichero: carpeta "archivos" y nombre "ejemplo.json"
            string rutaFichero = Path.Combine(rutaDirectorio, nombreFichero);
            try
            {
                if (!File.Exists(rutaFichero))
                {
                    Console.WriteLine($"Error: El fichero '{rutaFichero}' no existe.");
                    return null!;
                }

                // 2. Leemos el contenido del fichero y lo almacenamos en una variable
                string jsonString = File.ReadAllText(rutaFichero);

                // 3. Configuramos las opciones de deserialización (para entender el formato snake_case del JSON)
                var opciones = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower, // Para convertir snake_case a camelCase
                };

                // 4. Deserializamos el JSON a un registro de C# (record) llamado "DatosEmpresa"
                ModeloDatos.DatosEmpresa? datos = JsonSerializer.Deserialize<ModeloDatos.DatosEmpresa>(jsonString, opciones);

                return datos!;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: El fichero '{rutaFichero}' no se encontró.");
                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el fichero: {ex.Message}");
                return null!;
            }
        }


        static void ImprimirDatosEmpresa(ModeloDatos.DatosEmpresa datos)
        {
            Console.WriteLine($"Empresa: {datos.Empresa}");
            Console.WriteLine($"Fecha de Creación: {datos.FechaCreacion}");
            Console.WriteLine($"Activa: {datos.Activa}");
            Console.WriteLine("Proyectos:");
            foreach (var proyecto in datos.Proyectos)
            {
                Console.WriteLine($"\tID: {proyecto.Id}");
                Console.WriteLine($"\tNombre: {proyecto.Nombre}");
                Console.WriteLine($"\tEstado: {proyecto.Estado}");
                Console.WriteLine($"\tTecnologías: {string.Join(", ", proyecto.Tecnologias)}");
                Console.WriteLine($"\tPresupuesto: {proyecto.Presupuesto:C}");
                Console.WriteLine();
            }
            Console.WriteLine("Configuración del Sistema:");
            Console.WriteLine($"\tModo Depuración: {datos.ConfiguracionSistema.ModoDepuracion}");
            Console.WriteLine($"\tMax Intentos Conexión: {datos.ConfiguracionSistema.MaxIntentosConexion}");
            Console.WriteLine($"\tRutas de Almacenamiento:");
            Console.WriteLine($"\t\tTemporal: {datos.ConfiguracionSistema.RutasAlmacenamiento.Temporal}");
            Console.WriteLine($"\t\tPermanente: {datos.ConfiguracionSistema.RutasAlmacenamiento.Permanente}");
            Console.WriteLine("Usuarios Admin:");
            foreach (var usuario in datos.UsuariosAdmin)
            {
                Console.WriteLine($"\tID: {usuario.Id}");
                Console.WriteLine($"\tNombre: {usuario.Nombre}");
                Console.WriteLine($"\tEmail: {usuario.Email}");
                Console.WriteLine();
            }
        }

        static decimal CalcularPresupuestoTotal(List<ModeloDatos.Proyecto> proyectos)
        {
            decimal presupuestoTotal = 0;
            foreach (var proyecto in proyectos)
            {
                presupuestoTotal += proyecto.Presupuesto;
            }
            return presupuestoTotal;
        }


        static PersonajeStarWars StarWarsDesdeInternet(string url)
        {
            try
            {
                using var client = new HttpClient();

                var opciones = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                };
                string jsonString = client.GetStringAsync(url).Result;
                PersonajeStarWars? personaje = JsonSerializer.Deserialize<PersonajeStarWars>(jsonString, opciones);
                return personaje!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos de Star Wars: {ex.Message}");
                return null!;
            }
        }
        static Peliculas PeliculasStarWars(string url)
        {
            try
            {
                using var client = new HttpClient();

                var opciones = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                };
                string jsonString = client.GetStringAsync(url).Result;
                Peliculas? datos = JsonSerializer.Deserialize<Peliculas>(jsonString, opciones);
                return datos!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos de Star Wars: {ex.Message}");
                return null!;
            }
        }
        static Pokemon PokemonInternet(string url)
        {
            try
            {
                using var client = new HttpClient();

                var opciones = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                };
                string jsonString = client.GetStringAsync(url).Result;
                Pokemon? datos = JsonSerializer.Deserialize<Pokemon>(jsonString, opciones);
                return datos!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos de Star Wars: {ex.Message}");
                return null!;
            }
        }

        static async Task<PersonajeStarWars> StarWarsDesdeInternetAsincrono(string url)
        {
            try
            {
                using var client = new HttpClient();

                var opciones = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                };
                PersonajeStarWars? personaje = await client.GetFromJsonAsync<PersonajeStarWars>(url, opciones);
                return personaje!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos de Star Wars: {ex.Message}");
                return null!;
            }
        }


        public record PersonajeStarWars(
            string Name,
            string Height,
            string Mass
        );

        public record Peliculas
        (
            string Title,
            string EpisodeId,
            string OpeningCrawl
        );

        public record Pokemon(
            string Name,
            int Order,
            int BaseExperience,
            List<HabilidadPokemon> Abilities
        );
        // El elemento que está dentro de la lista(representa cada bloque con is_hidden y slot)
        public record HabilidadPokemon(
            DetalleHabilidad Ability,
            bool IsHidden,
            int Slot
        );

        // El objeto anidado con el nombre de la habilidad y su URL
        public record DetalleHabilidad(
            string Name,
            string Url
        );

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Para mostrar correctamente el símbolo de moneda
            //ModeloDatos.DatosEmpresa? datos = JsonLocal("archivos", "ejemplo.json");
            //if (datos != null)
            //{
            //    ImprimirDatosEmpresa(datos);
            //}

            //Console.WriteLine($"El presupuesto total de los proyectos es: {CalcularPresupuestoTotal(datos!.Proyectos):C}");
            //PersonajeStarWars luke = StarWarsDesdeInternet(@"https://swapi.info/api/people/1");
            //Console.WriteLine($"Nombre: {luke.Name}");
            //Console.WriteLine($"Altura: {luke.Height}");
            //Console.WriteLine($"Masa: {luke.Mass}");

            //PersonajeStarWars luke2 = StarWarsDesdeInternetAsincrono(@"https://swapi.info/api/people/1").Result;
            //Console.WriteLine($"Nombre: {luke2.Name}");
            //Console.WriteLine($"Altura: {luke2.Height}");
            //Console.WriteLine($"Masa: {luke2.Mass}");

            // Ejemplo coger personajes del 1 al 10 y guardarlos en un CSV
            //File.AppendAllText(Path.Combine("archivos", "personajes.csv"), $"Name;Height;Mass\n");
            //for (int i = 1; i <= 10; i++)
            //{
            //    string url = $"https://swapi.info/api/people/{i}";
            //    PersonajeStarWars personaje = StarWarsDesdeInternet(url);
            //    File.AppendAllText(Path.Combine("archivos", "personajes.csv"), $"{personaje.Name};{personaje.Height};{personaje.Mass}\n");
            //}
            //Console.WriteLine("Proceso completado");

            // Ejemplo coger datos Pokemon ditto y mostrarlo por consola
            Pokemon ditto = PokemonInternet(@"https://pokeapi.co/api/v2/pokemon/ditto");
            Console.WriteLine($"{ditto.Name}");
            Console.WriteLine($"{ditto.Order}");
            Console.WriteLine($"{ditto.BaseExperience}");
            foreach (var habilidad in ditto.Abilities)
            {
                Console.WriteLine($"Habilidad: {habilidad.Ability.Name}, Oculta: {habilidad.IsHidden}, Slot: {habilidad.Slot}");
            }

        }

    }

}
