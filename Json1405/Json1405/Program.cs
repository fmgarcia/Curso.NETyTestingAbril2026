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
                    return null;
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
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el fichero: {ex.Message}");
                return null;
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



        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Para mostrar correctamente el símbolo de moneda
            ModeloDatos.DatosEmpresa? datos = JsonLocal("archivos", "ejemplo.json");
            if (datos != null)
            {
                ImprimirDatosEmpresa(datos);
            }

            Console.WriteLine($"El presupuesto total de los proyectos es: {CalcularPresupuestoTotal(datos!.Proyectos):C}");
        }

    }

}
