namespace Colecciones
{
    internal class Program
    {

        static void EjemplosListas()
        {
            // Crear una lista
            List<string> nombres = new List<string>();

            // Añadir elementos
            nombres.Add("Ana");
            nombres.Add("Luis");
            nombres.Add("María");

            // Crear una lista con valores iniciales
            var colores = new List<string> { "Rojo", "Verde", "Azul" };
            // Inicialización directa
            List<int> numeros = new() { 1, 2, 3, 4, 5 };


            // Insertar en posición
            nombres.Insert(1, "Pedro");  // Inserta en índice 1

            // Acceder por índice
            Console.WriteLine(nombres[0]);  // Ana
            Console.WriteLine(nombres[^1]); // María (último)

            // Tamaño
            Console.WriteLine($"Total: {nombres.Count}");  // 4

            // Recorrer
            foreach (string nombre in nombres)
            {
                Console.WriteLine(nombre);
            }

            // Eliminar
            nombres.Remove("Pedro");        // Elimina por valor (la primera ocurrencia)
            nombres.RemoveAt(0);            // Elimina por índice
            nombres.RemoveAll(n => n.StartsWith("M"));  // Elimina por condición. También puedes hacer n.Equals("Pedro") y borra todos los "Pedro"

            // Modificar
            nombres[0] = "Carlos";  // Modificar por índice
            nombres[nombres.FindIndex(n => n.Equals("Luis"))] = "Luisito";  // Modificar por condición

            // Comprobar
            bool existe = nombres.Contains("Luis");  // True

            // Buscar
            string? encontrado = nombres.Find(n => n.Length > 3);    // Primer match
            List<string> varios = nombres.FindAll(n => n.Length > 3); // Todos los match
            int indice = nombres.IndexOf("Luis");                     // Posición

            // Ordenar
            nombres.Sort();           // Alfabético
            nombres.Reverse();        // Invertir
            nombres.Sort((a, b) => a.Length.CompareTo(b.Length));  // Por longitud

            // Convertir a array
            string[] array = nombres.ToArray();

        }

        static void EjemplosDiccionarios()
        {
            // Crear un diccionario
            Dictionary<string, int> edades = new()
            {
                ["Ana"] = 25,
                ["Luis"] = 30,
                ["María"] = 22
            };

            // Acceder por clave
            Console.WriteLine(edades["Ana"]);  // 25

            // Añadir
            edades["Pedro"] = 28;

            // Modificar
            edades["Ana"] = 26;

            // Comprobar si existe una clave
            if (edades.ContainsKey("Luis"))
            {
                Console.WriteLine($"Luis tiene {edades["Luis"]} años");
            }

            // Acceso seguro con TryGetValue
            if (edades.TryGetValue("Carmen", out int edad))
            {
                Console.WriteLine($"Carmen tiene {edad} años");
            }
            else
            {
                Console.WriteLine("Carmen no encontrada");
            }

            // Eliminar
            edades.Remove("María");

            // Recorrer
            foreach (KeyValuePair<string, int> par in edades)
            {
                Console.WriteLine($"{par.Key}: {par.Value} años");
            }

            // Forma más limpia con desestructuración
            foreach (var (nombre, edadVal) in edades)
            {
                Console.WriteLine($"{nombre}: {edadVal} años");
            }

            // Obtener solo claves o valores
            ICollection<string> claves = edades.Keys;
            ICollection<int> valores = edades.Values;

            Console.WriteLine($"Personas: {string.Join(", ", claves)}");

        }

        static void EjemploDiccionarioTraductor()
        {
            Dictionary<string, string> traductor = new()
            {
                ["hola"] = "hello",
                ["adiós"] = "goodbye",
                ["gracias"] = "thank you"
            };
            Console.WriteLine(traductor["hola"]);  // hello
        }

        static void TraductorTiempoReal()
        {
            string busqueda = "";
            Dictionary<string, string> spanish_english = new() { }; // Creo un diccionario vacío para almacenar las traducciones
            // Leer el archivo de traducciones
            string[] lineas = File.ReadAllLines(@"archivos/data.csv");
            // cargar en el diccionario todas las traducciones del archivo
            foreach (string linea in lineas)
            {
                string[] partes = linea.Split(','); // Divido cada línea en partes usando la coma como separador
                if (partes.Length == 2) // Verifico que haya exactamente dos partes (palabra en español y su traducción en inglés)
                {
                    string spanish = partes[1].Trim(); // Obtengo la palabra en español y elimino espacios en blanco
                    string english = partes[0].Trim(); // Obtengo la traducción en inglés y elimino espacios en blanco
                    spanish_english[spanish] = english; // Agrego la traducción al diccionario
                }
            }
            while (busqueda != "salir")
            {
                Console.WriteLine("Ingrese una palabra en español (o 'salir' para terminar):");
                busqueda = Console.ReadLine() ?? "";
                if (spanish_english.TryGetValue(busqueda, out string traduccion))
                {
                    Console.WriteLine($"La traducción de '{busqueda}' es: {traduccion}");
                }
                else
                {
                    if (busqueda != "salir")
                    {
                        Console.WriteLine($"No se encontró la traducción de '{busqueda}'");
                    }
                }
            }
        }


        static void ContadorPalabras(string texto)
        {
            string[] palabras = texto.Split(' ');

            Dictionary<string, int> contador = new();

            // Crea una entrada en el diccionario para cada palabra y cuenta cuántas veces aparece
            foreach (string palabra in palabras)
            {
                if (contador.ContainsKey(palabra))
                    contador[palabra]++; // Si la palabra ya existe, incrementa su contador
                else
                    contador[palabra] = 1; // Si la palabra no existe, la agrega al diccionario con un contador inicial de 1
            }

            // Imprime el resultado
            foreach (var (palabra, cuenta) in contador)
            {
                Console.WriteLine($"'{palabra}': {cuenta} {(cuenta == 1 ? "vez" : "veces")}");
            }
            // 'el': 3 veces
            // 'gato': 1 vez
            // 'y': 2 veces
            // 'perro': 1 vez
            // 'pez': 1 vez

        }

        static void EjemploCola()
        {
            Queue<string> cola = new();

            // Encolar (añadir al final)
            cola.Enqueue("Cliente 1");
            cola.Enqueue("Cliente 2");
            cola.Enqueue("Cliente 3");


            Console.WriteLine($"En cola: {cola.Count}");  // 3

            // Ver el primero sin sacarlo
            Console.WriteLine($"Siguiente: {cola.Peek()}");  // Cliente 1

            // Desencolar (sacar el primero)
            while (cola.Count > 0)
            {
                string cliente = cola.Dequeue();
                Console.WriteLine($"Atendiendo a: {cliente}");
            }
            // Atendiendo a: Cliente 1
            // Atendiendo a: Cliente 2
            // Atendiendo a: Cliente 3
        }


        static void EjemploPila()
        {
            Stack<string> historial = new();

            // Apilar (push)
            historial.Push("google.com");
            historial.Push("github.com");
            historial.Push("stackoverflow.com");

            // Ver lo de arriba sin sacarlo
            Console.WriteLine($"Actual: {historial.Peek()}");  // stackoverflow.com

            // Desapilar (pop): retroceder en el historial
            Console.WriteLine($"Atrás: {historial.Pop()}");    // stackoverflow.com
            Console.WriteLine($"Actual: {historial.Peek()}");  // github.com
        }

        static void EjemploPilaDeshacerRehacer()
        {
            Stack<string> historial = new();
            Stack<string> rehacer = new();
            string textoActual = "";

            void EscribirTexto(string nuevoTexto)
            {
                historial.Push(textoActual);  // Guardar estado anterior
                rehacer.Clear();               // Limpiar rehacer al hacer un cambio
                textoActual = nuevoTexto;
            }

            void Deshacer()
            {
                if (historial.Count > 0)
                {
                    rehacer.Push(textoActual);
                    textoActual = historial.Pop();
                }
            }

            void Rehacer()
            {
                if (rehacer.Count > 0)
                {
                    historial.Push(textoActual);
                    textoActual = rehacer.Pop();
                }
            }

            EscribirTexto("Hola");
            EscribirTexto("Hola mundo");
            EscribirTexto("Hola mundo!");

            Console.WriteLine(textoActual);  // "Hola mundo!"
            Deshacer();
            Console.WriteLine(textoActual);  // "Hola mundo"
            Deshacer();
            Console.WriteLine(textoActual);  // "Hola"
            Rehacer();
            Console.WriteLine(textoActual);  // "Hola mundo"

        }


        static void EjemploAnalizadorSintactico(string expresion)
        {
            // Aquí podrías implementar un analizador sintáctico simple usando pilas para validar la correcta anidación de paréntesis, corchetes, etc.
            // Por ejemplo, podrías leer una expresión matemática y verificar que todos los paréntesis estén correctamente balanceados.
            Stack<char> pila = new();
            foreach (char c in expresion)
            {
                if (c == '(')
                {
                    pila.Push(c);
                }
                else if (c == ')')
                {
                    if (pila.Count == 0 || pila.Pop() != '(')
                    {
                        Console.WriteLine("Expresión no válida: paréntesis desbalanceados");
                        return;
                    }
                }
            }
            if (pila.Count == 0)
            {
                Console.WriteLine("Expresión válida: paréntesis balanceados");
            }
            else
            {
                Console.WriteLine("Expresión no válida: paréntesis desbalanceados");
            }
        }

        static void EjemploHashSet()
        {
            HashSet<string> frutas = new() { "Manzana", "Plátano", "Naranja" };

            // Añadir (devuelve false si ya existe)
            bool añadido1 = frutas.Add("Fresa");     // true
            bool añadido2 = frutas.Add("Manzana");   // false (ya existe)

            Console.WriteLine($"Total: {frutas.Count}");  // 4

            // Comprobar existencia (muy rápido)
            Console.WriteLine(frutas.Contains("Naranja"));  // True

            // Operaciones de conjuntos
            HashSet<string> tropicales = new() { "Plátano", "Mango", "Piña" };

            // Unión: todas las frutas (de ambos conjuntos)
            HashSet<string> union = new(frutas);
            union.UnionWith(tropicales);
            Console.WriteLine($"Unión: {string.Join(", ", union)}");

            // Intersección: solo las que están en ambos
            HashSet<string> comunes = new(frutas);
            comunes.IntersectWith(tropicales);
            Console.WriteLine($"Comunes: {string.Join(", ", comunes)}");  // Plátano

            // Diferencia: las que están en frutas pero no en tropicales
            HashSet<string> diferencia = new(frutas);
            diferencia.ExceptWith(tropicales);
            Console.WriteLine($"Solo en frutas: {string.Join(", ", diferencia)}");

        }

        // Ejemplos de genéricos
        // T es un "placeholder" para cualquier tipo
        static T ObtenerMayor<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }


        static void Main(string[] args)
        {
            //EjemplosListas();
            //EjemplosDiccionarios();
            //EjemploDiccionarioTraductor();
            //TraductorTiempoReal();
            //ContadorPalabras("el gato y el perro y el pez");
            //EjemploCola();
            //EjemploPila();
            //EjemploPilaDeshacerRehacer();
            //EjemploAnalizadorSintactico("((2 + 3) * (5 - 1))");
            //EjemploAnalizadorSintactico("(2 + 3)) * (5 - 1)");
            //EjemploHashSet();
            //int mayor = ObtenerMayor(4, 5);
            //Console.WriteLine($"El mayor es: {mayor}");
            //Console.WriteLine(ObtenerMayor("hola", "mundo"));
            //var cajaNumeros = new Caja<int>(42);
            //Console.WriteLine(cajaNumeros.ObtenerContenido());  // 42

            //var cajaTexto = new Caja<string>("Hola");
            //Console.WriteLine(cajaTexto);  // Caja con: Hola

            List<Juguete> juguetes = new()
            {
                new Juguete(1, "Muñeca", "Una muñeca de trapo", 15.99m),
                new Juguete(2, "Coche de juguete", "Un coche de plástico", 25.50m),
                new Juguete(3, "Rompecabezas", "Un rompecabezas de 100 piezas", 10.00m)
            };

            juguetes.Sort(); // Ordenar por Id (por defecto)
            foreach (var juguete in juguetes)
            {
                Console.WriteLine(juguete);
            }
            juguetes.Sort((a, b) => a.Precio.CompareTo(b.Precio)); // Ordenar por precio
            foreach (var juguete in juguetes)
            {
                Console.WriteLine(juguete);
            }
            Caja<Juguete> cajaJuguete = new(juguetes[0]);  // Esta caja solo puede contener un Juguete
            Caja<List<Juguete>> cajaJuguetes = new(juguetes);  // Esta caja puede contener una lista de Juguetes

            Console.WriteLine(cajaJuguete);  // Caja con: Juguete: Rompecabezas, Descripción: Un rompecabezas de 100 piezas, Precio: 10,00 ?
            Console.WriteLine(cajaJuguetes);  // Caja con: System.Collections.Generic.List`1[Colecciones.Juguete]

            Juguete jugueteEnCaja = cajaJuguete.ObtenerContenido();
            Console.WriteLine(jugueteEnCaja);

            List<Juguete> juguetesEnCaja = cajaJuguetes.ObtenerContenido();
            foreach (var juguete in juguetesEnCaja)
            {
                Console.WriteLine(juguete);
            }

            // Ejemplos de Serialización con la clase Genérica SerializarObjeto
            SerializarObjeto<List<Juguete>> serializadorJuguetes = new(juguetes);
            SerializarObjeto<Juguete> serializadorJuguete = new(juguetes[0]);
            SerializarObjeto<Caja<List<Juguete>>> serializarCajaListaJuguetes = new(cajaJuguetes);

            if (!Directory.Exists("archivos"))
            {
                Directory.CreateDirectory("archivos");
            }
            serializadorJuguetes.Serializar(@"archivos/juguetes.json");
            serializadorJuguete.Serializar(@"archivos/juguete.json");
            serializarCajaListaJuguetes.Serializar(@"archivos/caja_juguetes.json");

            Juguete jugueteDesdeArchivo = serializadorJuguete.Deserializar(@"archivos/juguete.json");
            List<Juguete> listaJuguetesDesdeArchivo = serializadorJuguetes.Deserializar(@"archivos/juguetes.json");

            // Imprimimos lo que hemos recuperado de los ficheros
            Console.WriteLine("Recuperando datos desde ficheros:");
            Console.WriteLine(jugueteDesdeArchivo);
            foreach (var juguete in listaJuguetesDesdeArchivo)
            {
                Console.WriteLine(juguete);

            }
        }
    }
}
