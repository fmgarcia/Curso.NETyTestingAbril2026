namespace Ficheros1405
{
    internal class Program
    {

        static string LeerFicheroModerno(string ruta)
        {
            return File.ReadAllText(ruta);
        }

        static string[] LeerFicheroLineas(string ruta)
        {
            return File.ReadAllLines(ruta);
        }

        static void FormaModernaLectura()
        {
            string rutaAbsoluta = @"C:\Users\Fran\Documents\EOI2026\04_NetTestingAbril\Proyectos\Ficheros1405\Ficheros1405\bin\Debug\net10.0\ficheros\fran.txt";
            string rutaRelativa = @"ficheros\fran.txt";
            try
            {
                //Console.WriteLine(LeerFicheroModerno(rutaAbsoluta));
                //Console.WriteLine(LeerFicheroModerno(rutaRelativa));
                //string[] lineas = LeerFicheroLineas(rutaRelativa);
                //for (int i = 0; i < lineas.Length; i++)
                //{
                //    Console.WriteLine($"La linea {i + 1}: {lineas[i]}");
                //}
            }
            catch (Exception)
            {

                Console.WriteLine("El fichero no se pudo leer.");
            }
        }


        static void FormaModernaEscritura()
        {
            string ruta = @"ficheros\fran3.txt";
            string texto = "Hola, soy un nuevo texto.\nEsto es una segunda línea";
            string[] lineas = new string[] { "Hola, soy una nueva línea", "Esto es otra línea nueva" };

            try
            {
                // Escribir texto (sobrescribe el contenido anterior)
                //File.WriteAllText(ruta,texto);
                //File.WriteAllLines(ruta, lineas);
                // Añadir texto al final (no sobreescribe)
                //File.AppendAllText(ruta, "Esta línea se añade al final con AppendAllText.\nEsta también con AppendAllText\n");
                //File.AppendAllLines(ruta, new[] { "Línea añadida con AppendAllLines", "Otra con AppendAllLines" });
                Console.WriteLine("Fichero escrito correctamente.");
            }
            catch (Exception)
            {
                Console.WriteLine("El fichero no se pudo escribir.");
            }
        }

        static void MasEjemplosFile()
        {
            string ruta = @"ficheros\fran3.txt";
            if (File.Exists(ruta))
            {
                File.Copy(ruta, @"ficheros\fran3_copia.txt", true); // El tercer parámetro indica si se sobrescribe o no
                File.Delete(ruta);  // Elimina el fichero original
                Console.WriteLine("Proceso finalizado.");
            }
            else
            {
                Console.WriteLine("El fichero no existe.");
            }
        }

        static void TrabajarConPath()
        {
            string ruta = @"C:\Users\Fran\Documents\EOI2026\04_NetTestingAbril\Proyectos\Ficheros1405\Ficheros1405\bin\Debug\net10.0\ficheros\fran.txt";
            string rutaRelativa = @"ficheros\fran.txt";

            Console.WriteLine($"Directorio: {Path.GetDirectoryName(ruta)}");
            Console.WriteLine($"Nombre del fichero: {Path.GetFileName(ruta)}");
            Console.WriteLine($"Extensión del fichero: {Path.GetExtension(ruta)}");

            string rutaCompleta = Path.Combine(Path.GetDirectoryName(ruta)!, Path.GetFileName(ruta));
            Console.WriteLine(rutaCompleta);
        }

        static void LeerFicheroEnOtraRuta()
        {
            string ruta = @"..\..\..\textoaniveldeprogram.txt";
            Console.WriteLine(File.ReadAllText(ruta));
        }

        static void TrabajarConDirectorios()
        {
            string carpeta = "MisArchivos";

            // Crear directorio
            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
                Console.WriteLine($"Carpeta '{carpeta}' creada.");
            }

            // Listar archivos
            string[] archivos = Directory.GetFiles(carpeta);
            foreach (string archivo in archivos)
            {
                Console.WriteLine(archivo);
            }

            // Listar archivos con filtro
            string[] textos = Directory.GetFiles(carpeta, "*.txt");
            Console.WriteLine("Mostrando los archivos .txt");
            foreach (string texto in textos)
            {
                Console.WriteLine(texto);
            }
            string[] todos = Directory.GetFiles(carpeta, "*.*", SearchOption.AllDirectories);
            Console.WriteLine("Mostrando TODOS los archivos");
            foreach (string archivo in todos)
            {
                Console.WriteLine(archivo);
            }

            // Listar subcarpetas
            string[] subcarpetas = Directory.GetDirectories(carpeta);
            Console.WriteLine("Mostrando las subcarpetas");
            foreach (string subcarpeta in subcarpetas)
            {
                Console.WriteLine(subcarpeta);
            }

            // Obtener directorio actual
            string actual = Directory.GetCurrentDirectory();
            Console.WriteLine($"Directorio actual: {actual}");

        }

        static void CrearFicheroEnDirectorio()
        {
            string carpetaSalida = "Resultados";
            string carpetaEntrada = "MisArchivos";

            if (!Directory.Exists(carpetaSalida))
            {
                Directory.CreateDirectory(carpetaSalida);
            }
            if (Directory.Exists(carpetaEntrada))
            {
                string[] archivos = Directory.GetFiles(carpetaEntrada, "*.txt", SearchOption.AllDirectories);
                foreach (string archivo in archivos)
                {
                    File.AppendAllText(Path.Combine(carpetaSalida, "resultados.txt"), $"{File.ReadAllText(archivo)}\n");
                }
                Console.WriteLine("Proceso Finalizado.");
            }
            else
            {
                Console.WriteLine($"La carpeta '{carpetaEntrada}' no existe.");
            }
        }

        static void InformacionFichero()
        {
            FileInfo info = new FileInfo(@"Resultados\resultados.txt");

            if (info.Exists)
            {
                Console.WriteLine($"Nombre: {info.Name}");
                Console.WriteLine($"Tamaño: {info.Length} bytes");
                Console.WriteLine($"Creado: {info.CreationTime}");
                Console.WriteLine($"Modificado: {info.LastWriteTime}");
                Console.WriteLine($"Extensión: {info.Extension}");
                Console.WriteLine($"Directorio: {info.DirectoryName}");
                Console.WriteLine($"Solo lectura: {info.IsReadOnly}");
            }

        }


        static void Main(string[] args)
        {
            // La clase File existe desde .NET Framework 2.0, pero se han añadido métodos nuevos en versiones posteriores que facilitan la lectura y escritura de ficheros.
            //FormaModernaLectura();
            //FormaModernaEscritura
            //MasEjemplosFile();
            //TrabajarConPath();
            //LeerFicheroEnOtraRuta();
            //TrabajarConDirectorios();
            //CrearFicheroEnDirectorio();
            InformacionFichero();
        }
    }
}
