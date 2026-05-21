using System.Threading.Channels;

namespace LINQ
{
    internal class Program
    {



        static void EjemploSinLINQ()
        {
            // Sin LINQ, tendríamos que escribir código más extenso para filtrar y ordenar la lista de números.
            List<int> numeros = new() { 8, 3, 15, 1, 42, 7, 23, 5, 19, 2 };
            List<int> numerosParesOrdenados = new();
            foreach (int numero in numeros)
            {
                if (numero % 2 == 0)
                {
                    numerosParesOrdenados.Add(numero);
                }
            }
            numerosParesOrdenados.Sort();
        }

        static void EjemploConLINQ()
        {
            // Con LINQ, podemos escribir código más conciso y legible para lograr el mismo resultado.
            List<int> numeros = new() { 8, 3, 15, 1, 42, 7, 23, 5, 19, 2 };
            var numerosParesOrdenados = numeros
                .Where(n => n % 2 == 0)  // Filtramos los números pares.
                .OrderBy(n => n)        // Ordenamos los números pares de forma ascendente.
                .ToList();              // Convertimos el resultado a una lista.
        }

        static List<int> DevolverParesOrdenados(List<int> numeros)
        {
            // Podemos encapsular la lógica de filtrado y ordenamiento en un método reutilizable.
            // Sintaxis fluida (fluent syntax) con LINQ para devolver una lista de números pares ordenados.
            return numeros
                .Where(n => n % 2 == 0)  // Filtramos los números pares.
                .OrderBy(n => n)        // Ordenamos los números pares de forma ascendente.
                .ToList();              // Convertimos el resultado a una lista.
        }


        static List<int> DevolverParesOrdenadosQuerySyntax(List<int> numeros)
        {
            // Sintaxis de consulta (query syntax) con LINQ para devolver una lista de números pares ordenados.
            return (from n in numeros
                    where n % 2 == 0
                    orderby n
                    select n).ToList(); // Convertimos el resultado a una lista.
        }


        record Alumno(string Nombre, int Edad, double Nota, string Ciudad);
        static void LINQFundamentales()
        {
            List<Alumno> alumnos = new()
            {
                new("Ana", 22, 8.5, "Madrid"),
                new("Luis", 25, 6.0, "Barcelona"),
                new("María", 20, 9.2, "Madrid"),
                new("Pedro", 23, 4.5, "Sevilla"),
                new("Carmen", 21, 7.8, "Barcelona"),
                new("Javier", 24, 5.0, "Madrid"),
                new("Laura", 22, 9.5, "Valencia"),
                new("Carlos", 26, 3.2, "Sevilla"),
                new("Elena", 21, 8.0, "Valencia"),
                new("Diego", 23, 6.5, "Madrid")
            };

            // Where
            // Filtrar alumnos con nota mayor o igual a 5. Ejemplo de filtro simple.
            var alumnosAprobados = alumnos.Where(e => e.Nota >= 5).ToList();
            // Filtrar alumnos de Madrid con nota mayor o igual a 5. Ejemplo de filtro compuesto.
            var alumnosMadridAprobados = alumnos.Where(e => e.Nota >= 5 && e.Ciudad == "Madrid").ToList();

            // Where + foreach
            alumnos
                .Where(e => e.Nota >= 5)
                .ToList()
                .ForEach(a => Console.WriteLine($"{a.Nombre} - {a.Nota}"));

            // OrderBy, OrderByDescending, ThenBy, ThenByDescending
            alumnos
                .OrderByDescending(e => e.Nota) // Ordenar por nota de mayor a menor.
                .ToList()
                .ForEach(a => Console.WriteLine(a.ToString()));

            alumnos
                .OrderBy(e => e.Ciudad) // Ordenar por ciudad de forma ascendente.
                .ThenByDescending(e => e.Nota) // Luego ordenar por nota de mayor a menor dentro de cada ciudad.
                .ToList()
                .ForEach(a => Console.WriteLine(a.ToString()));

            // Select (en otros lenguajes se llama map)
            Console.WriteLine("Nombres de los alumnos:");
            alumnos
                .Select(e => e.Nombre)
                .ToList()
                .ForEach(a => Console.WriteLine(a));

            Console.WriteLine("Nombres de los alumnos separados por comas:");
            Console.WriteLine(string.Join(", ", alumnos.Select(e => e.Nombre)));

            // Select con creación de objetos anónimos con datos calculados.
            Console.WriteLine("Resumen de alumnos con estado y nota sobre 10:");
            var resumen = alumnos
                .Where(e => e.Ciudad == "Madrid")
                .Select(e => new
                {
                    e.Nombre,
                    e.Nota,
                    Estado = e.Nota >= 5 ? "Aprobado" : "Suspenso",
                    NotaSobre10 = e.Nota / 10 // Ejemplo de cálculo adicional.
                })
                .ToList();
            resumen.ForEach(r => Console.WriteLine($"{r.Nombre} - {r.Nota} - {r.Estado} - {r.NotaSobre10:F2}"));

            // Esto hace lo mismo que lo anterior pero sin crear la variable intermedia "resumen".
            alumnos
                .Where(e => e.Ciudad == "Madrid")
                .Select(e => new
                {
                    e.Nombre,
                    e.Nota,
                    Estado = e.Nota >= 5 ? "Aprobado" : "Suspenso",
                    NotaSobre10 = e.Nota / 10 // Ejemplo de cálculo adicional.
                })
                .ToList()
                .ForEach(r => Console.WriteLine($"{r.Nombre} - {r.Nota} - {r.Estado} - {r.NotaSobre10:F2}"));


        }

        // Take y Skip
        // Take se utiliza para tomar un número específico de elementos desde el inicio de una secuencia, mientras que Skip se utiliza para omitir un número específico de elementos desde el inicio de una secuencia.
        // Skip es especialmente útil para implementar paginación, donde puedes omitir los elementos de las páginas anteriores y tomar solo los elementos de la página actual.
        static void TakeSkip()
        {
            List<Alumno> alumnos = new()
            {
                new("Ana", 22, 8.5, "Madrid"),
                new("Luis", 25, 6.0, "Barcelona"),
                new("María", 20, 9.2, "Madrid"),
                new("Pedro", 23, 4.5, "Sevilla"),
                new("Carmen", 21, 7.8, "Barcelona"),
                new("Javier", 24, 5.0, "Madrid"),
                new("Laura", 22, 9.5, "Valencia"),
                new("Carlos", 26, 3.2, "Sevilla"),
                new("Elena", 21, 8.0, "Valencia"),
                new("Diego", 23, 6.5, "Madrid")
            };

            Console.WriteLine("Los 3 mejores alumnos:");
            alumnos
                .OrderByDescending(e => e.Nota) // Ordenar por nota de mayor a menor.
                .Take(3) // Tomar los 3 primeros (los mejores).
                .ToList()
                .ForEach(a => Console.WriteLine($"{a.Nombre} - {a.Nota}"));

            // Ejemplo de paginación: mostrar la página 2 con 3 elementos por página.
            int pagina = 2;
            int elementosPorPagina = 3;
            alumnos
                .Skip((pagina - 1) * elementosPorPagina) // Saltar los elementos de las páginas anteriores.
                .Take(elementosPorPagina) // Tomar los elementos de la página actual.
                .ToList()
                .ForEach(a => Console.WriteLine($"{a.Nombre} - {a.Nota}"));

        }

        // First, FirstOrDefault, Single, SingleOrDefault, Last, LastOrDefault
        // First se utiliza para obtener el primer elemento de una secuencia que cumple una condición específica. Si no se encuentra ningún elemento que cumpla la condición, se lanza una excepción.
        // FirstOrDefault se utiliza para obtener el primer elemento de una secuencia que cumple una condición específica. Si no se encuentra ningún elemento que cumpla la condición, devuelve el valor predeterminado del tipo (por ejemplo, null para tipos de referencia o 0 para tipos numéricos).
        // Single se utiliza para obtener el único elemento de una secuencia que cumple una condición específica. Si no se encuentra ningún elemento que cumpla la condición o si se encuentran varios elementos que cumplen la condición, se lanza una excepción.
        // SingleOrDefault se utiliza para obtener el único elemento de una secuencia que cumple una condición específica. Si no se encuentra ningún elemento que cumpla la condición, devuelve el valor predeterminado del tipo. Si se encuentran varios elementos que cumplen la condición, se lanza una excepción.
        // Last se utiliza para obtener el último elemento de una secuencia que cumple una condición específica. Si no se encuentra ningún elemento que cumpla la condición, se lanza una excepción.
        // LastOrDefault se utiliza para obtener el último elemento de una secuencia que cumple una condición específica. Si no se encuentra ningún elemento que cumpla la condición, devuelve el valor predeterminado del tipo.
        static void Posiciones()
        {
            List<Alumno> alumnos = new()
            {
                new("Ana", 22, 8.5, "Madrid"),
                new("Luis", 25, 6.0, "Barcelona"),
                new("María", 20, 9.2, "Madrid"),
                new("Pedro", 23, 4.5, "Sevilla"),
                new("Carmen", 21, 7.8, "Barcelona"),
                new("Javier", 24, 5.0, "Madrid"),
                new("Laura", 22, 9.5, "Valencia"),
                new("Carlos", 26, 3.2, "Sevilla"),
                new("Elena", 21, 8.0, "Valencia"),
                new("Diego", 23, 6.5, "Madrid")
            };

            Alumno primeroLista = alumnos.First(); // Devuelve el primer alumno de la lista.
            Alumno ultimoLista = alumnos.Last(); // Devuelve el último alumno de la lista.
            Alumno primeroListaCondicion = alumnos.FirstOrDefault(a => a.Nota == 10, new Alumno("Sin nombre", 0, 0.0, "Sin ciudad")); // Devuelve el primer alumno con nota igual a 10.
            Console.WriteLine($"Primero de la lista: {primeroListaCondicion.Nombre}");

            try
            {
                Alumno single = alumnos.Single(a => a.Nombre == "Fran"); // Devuelve el único alumno con nombre "Fran". Si hay más de uno o ninguno, lanza una excepción.
                Console.WriteLine($"Alumno con nombre Fran: {single.Nombre}");
            }
            catch (Exception)
            {
                Console.WriteLine("No existe ningún Fran o hay más de uno");
            }
        }


        // Any, All, Count
        // Any se utiliza para determinar si al menos un elemento de una secuencia cumple una condición específica. Devuelve true si se encuentra al menos un elemento que cumple la condición, o false si no se encuentra ningún elemento que cumpla la condición.
        // All se utiliza para determinar si todos los elementos de una secuencia cumplen una condición específica. Devuelve true si todos los elementos cumplen la condición, o false si al menos un elemento no cumple la condición.
        // Count se utiliza para contar el número de elementos en una secuencia que cumplen una condición específica. Devuelve el número de elementos que cumplen la condición.
        static void AnyAllCount()
        {
            List<Alumno> alumnos = new()
            {
                new("Ana", 22, 8.5, "Madrid"),
                new("Luis", 25, 6.0, "Barcelona"),
                new("María", 20, 9.2, "Madrid"),
                new("Pedro", 23, 4.5, "Sevilla"),
                new("Carmen", 21, 7.8, "Barcelona"),
                new("Javier", 24, 5.0, "Madrid"),
                new("Laura", 22, 9.5, "Valencia"),
                new("Carlos", 26, 3.2, "Sevilla"),
                new("Elena", 21, 8.0, "Valencia"),
                new("Diego", 23, 6.5, "Madrid")
            };
            // ¿Todos los alumnos de Madrid han aprobado?
            bool todosAprobadosMadrid = alumnos
                .Where(a => a.Ciudad == "Madrid")
                .All(a => a.Nota >= 5);
            Console.WriteLine($"¿Todos los alumnos de Madrid han aprobado? {(todosAprobadosMadrid ? "Sí" : "No")}");

            // ¿ Existe algún alumno de Barcelona con nota mayor a 9,5?
            bool algunAlumnoBarcelona = alumnos
                .Where(a => a.Ciudad == "Barcelona")
                .Any(a => a.Nota > 9.5);
            Console.WriteLine($"¿Existe algún alumno de Barcelona con nota mayor a 9,5? {(algunAlumnoBarcelona ? "Sí" : "No")}");

            // ¿Cuántos alumnos de Sevilla han suspendido?
            Console.WriteLine($"¿Cuántos alumnos de Sevilla han suspendido? {alumnos
                .Where(a => a.Ciudad == "Sevilla")
                .Count(a => a.Nota < 5)}");
        }


        static void EjemplosEstadisticas()
        {
            List<Alumno> alumnos = new()
            {
                new("Ana", 22, 8.5, "Madrid"),
                new("Luis", 25, 6.0, "Barcelona"),
                new("María", 20, 9.2, "Madrid"),
                new("Pedro", 23, 4.5, "Sevilla"),
                new("Carmen", 21, 7.8, "Barcelona"),
                new("Javier", 24, 5.0, "Madrid"),
                new("Laura", 22, 9.5, "Valencia"),
                new("Carlos", 26, 3.2, "Sevilla"),
                new("Elena", 21, 8.0, "Valencia"),
                new("Diego", 23, 6.5, "Madrid")
            };

            Alumno mejorNota = alumnos.OrderByDescending(a => a.Nota).First(); // Alumno con la mejor nota.
            Alumno alumnoMaximaNota = alumnos.MaxBy(a => a.Nota)!; // Alumno con la nota máxima (lo mismo que el anterior pero más directo).
            double notaMaxima = alumnos.Max(a => a.Nota); // Nota máxima entre todos los alumnos.
            double notaMinima = alumnos.Min(a => a.Nota); // Nota mínima entre todos los alumnos.
            double notaMedia = alumnos.Average(a => a.Nota); // Nota media entre todos los alumnos.
            double sumaNotas = alumnos.Sum(a => a.Nota); // Suma de todas las notas de los alumnos.
            int numeroAlumnos = alumnos.Count(); // Número total de alumnos.
            Console.WriteLine($"Mejor alumno: {mejorNota.Nombre} con nota {mejorNota.Nota}");
            Console.WriteLine($"Alumno con la nota máxima: {alumnoMaximaNota.Nombre} con nota {alumnoMaximaNota.Nota}");
            Console.WriteLine($"Nota máxima: {notaMaxima}");
            Console.WriteLine($"Nota mínima: {notaMinima}");
            Console.WriteLine($"Nota media: {notaMedia}");
            Console.WriteLine($"Suma de todas las notas: {sumaNotas}");
            Console.WriteLine($"Número total de alumnos: {numeroAlumnos}");
        }

        // Aggregate se utiliza para aplicar una función de acumulación a los elementos de una secuencia, lo que permite realizar operaciones como sumas, productos, concatenaciones, etc. La función de acumulación toma dos parámetros: el valor acumulado hasta el momento y el siguiente elemento de la secuencia. El resultado de la función se convierte en el nuevo valor acumulado para la siguiente iteración.
        // En otro lenguaje, esta función se conoce como reduce o fold (Scala).
        static void EjemploAggregate()
        {
            List<int> numeros = new() { 1, 2, 3, 4, 5 };
            int producto = numeros.Aggregate((a, b) => a * b); // Calcula el producto de todos los números de la lista.
            Console.WriteLine($"Producto de los números: {producto}");

            List<Alumno> alumnos = new()
            {
                new("Ana", 22, 8.5, "Madrid"),
                new("Luis", 25, 6.0, "Barcelona"),
                new("María", 20, 9.2, "Madrid"),
                new("Pedro", 23, 4.5, "Sevilla"),
                new("Carmen", 21, 7.8, "Barcelona"),
                new("Javier", 24, 5.0, "Madrid"),
                new("Laura", 22, 9.5, "Valencia"),
                new("Carlos", 26, 3.2, "Sevilla"),
                new("Elena", 21, 8.0, "Valencia"),
                new("Diego", 23, 6.5, "Madrid")
            };

            // Nombres de los alumnos separados por comas utilizando Aggregate.
            string nombresAlumnosSeparadosComas = alumnos
                .Select(a => a.Nombre)  // Seleccionamos solo los nombres de los alumnos.
                .Aggregate((a, b) => $"{a}, {b}"); // Concatenar los nombres de los alumnos separados por comas.
            Console.WriteLine($"Nombres de los alumnos separados por comas: {nombresAlumnosSeparadosComas}");

            // Listado de diferentes ciudades no repetidas donde viven los alumnos utilizando Aggregate.
            string ciudadesUnicas = alumnos
                .Select(a => a.Ciudad) // Seleccionamos solo las ciudades de los alumnos.
                .Distinct() // Eliminamos las ciudades repetidas.
                .OrderBy(c => c) // Ordenamos las ciudades alfabéticamente.
                .Aggregate((a, b) => $"{a}, {b}"); // Concatenar las ciudades únicas separadas por comas.
            Console.WriteLine($"Ciudades únicas donde viven los alumnos: {ciudadesUnicas}");

        }

        static void EjemplosDistintosConjuntos()
        {
            List<Alumno> alumnos = new()
            {
                new("Ana", 22, 8.5, "Madrid"),
                new("Luis", 25, 6.0, "Barcelona"),
                new("María", 20, 9.2, "Madrid"),
                new("Pedro", 23, 4.5, "Sevilla"),
                new("Carmen", 21, 7.8, "Barcelona"),
                new("Javier", 24, 5.0, "Madrid"),
                new("Laura", 22, 9.5, "Valencia"),
                new("Carlos", 26, 3.2, "Sevilla"),
                new("Elena", 21, 8.0, "Valencia"),
                new("Diego", 23, 6.5, "Madrid")
            };

            // Listado de diferentes ciudades no repetidas donde viven los alumnos utilizando Distinct.
            List<string> ciudades = alumnos
                .Select(a => a.Ciudad) // Seleccionamos solo las ciudades de los alumnos.
                .Distinct()
                .ToList(); // Eliminamos las ciudades repetidas y convertimos el resultado a una lista.
            Console.WriteLine($"Ciudades únicas donde viven los alumnos: {string.Join(", ", ciudades)}");

            // Quiero quedarme con una lista de alumnos de uno por cada ciudad, es decir, un alumno representativo de cada ciudad.
            List<Alumno> alumnosRepresentativos = alumnos
                .DistinctBy(e => e.Ciudad) // Eliminamos los alumnos repetidos por ciudad, quedándonos con un alumno representativo de cada ciudad.
                .ToList();
            Console.WriteLine("Alumnos representativos de cada ciudad:");
            alumnosRepresentativos.ForEach(a => Console.WriteLine($"{a.Nombre} - {a.Ciudad}"));


            // Union, Intersect, Except
            List<int> lista1 = new() { 1, 2, 3, 4, 5 };
            List<int> lista2 = new() { 3, 4, 5, 6, 7 };

            var union = lista1.Union(lista2).ToList();       // [1,2,3,4,5,6,7]
            var unionAll = lista1.Concat(lista2).ToList();   // [1,2,3,4,5,3,4,5,6,7]
            var inter = lista1.Intersect(lista2).ToList();   // [3,4,5]
            var excepto = lista1.Except(lista2).ToList();    // [1,2]
            var diferenciaSimetrica = lista1.Except(lista2).Union(lista2.Except(lista1)).ToList(); // [1,2,6,7]

            Console.WriteLine($"Union: {string.Join(", ", union)}");
            Console.WriteLine($"Union All: {string.Join(", ", unionAll)}");
            Console.WriteLine($"Intersección: {string.Join(", ", inter)}");
            Console.WriteLine($"Excepto: {string.Join(", ", excepto)}");
            Console.WriteLine($"Diferencia simétrica: {string.Join(", ", diferenciaSimetrica)}");

        }



        record AgendaTelefonica(string Nombre, string Telefono);

        // Transformaciones de colecciones: ToList, ToArray, ToLookup, ToDictionary
        static void TransformacionesColecciones()
        {
            List<Alumno> alumnos = new()
            {
                new("Ana", 22, 8.5, "Madrid"),
                new("Luis", 25, 6.0, "Barcelona"),
                new("María", 20, 9.2, "Madrid"),
                new("Pedro", 23, 4.5, "Sevilla"),
                new("Carmen", 21, 7.8, "Barcelona"),
                new("Javier", 24, 5.0, "Madrid"),
                new("Laura", 22, 9.5, "Valencia"),
                new("Carlos", 26, 3.2, "Sevilla"),
                new("Elena", 21, 8.0, "Valencia"),
                new("Diego", 23, 6.5, "Madrid")
            };

            List<string> nombres = alumnos.Select(a => a.Nombre).ToList(); // Transformar a una lista de nombres.
            string[] nombresArray = nombres.ToArray(); // Transformar a un array de nombres.
            Dictionary<string, double> diccionarioNotas = alumnos
                .ToDictionary(a => a.Nombre, a => a.Nota); // Transformar a un diccionario con el nombre como clave y la nota como valor.
            Console.WriteLine($"La nota de Ana es: {diccionarioNotas["Ana"]}"); // La nota de Ana es: 8.5
            // ToLookup es similar a ToDictionary pero permite que haya claves repetidas, devolviendo una colección de valores para cada clave en lugar de un solo valor. Es útil cuando quieres agrupar elementos por una clave común.
            var lookupCiudades = alumnos.ToLookup(a => a.Ciudad); // Transformar a un Lookup con la ciudad como clave y los alumnos como valores.
            lookupCiudades["Madrid"].ToList().ForEach(a => Console.WriteLine($"Alumno de Madrid: {a.Nombre} - {a.Nota}")); // Imprime los alumnos de Madrid con sus notas.

            List<AgendaTelefonica> agenda = new()
            {
                new("Ana", "123456789"),
                new("Luis", "987654321"),
                new("María", "555555555"),
                new("Pedro", "111111111"),
                new("Carmen", "222222222"),
                new("Javier", "333333333"),
                new("Laura", "444444444"),
                new("Carlos", "666666666"),
                new("Elena", "777777777"),
                new("Diego", "888888888"),
                new("andrés", "666666666"),
            };

            var lookupAgenda = agenda.ToLookup(a => a.Nombre.ToUpper()[0]); // Agrupar por la primera letra del nombre en mayúscula.
            lookupAgenda['A'].ToList().ForEach(a => Console.WriteLine($"Alumno cuyo nombre empieza por A: {a.Nombre} - {a.Telefono}"));

        }

        static void ConsultasComplejas()
        {
            List<Alumno> alumnos = new()
            {
                new("Ana", 22, 8.5, "Madrid"),
                new("Luis", 25, 6.0, "Barcelona"),
                new("María", 20, 9.2, "Madrid"),
                new("Pedro", 23, 4.5, "Sevilla"),
                new("Carmen", 21, 7.8, "Barcelona"),
                new("Javier", 24, 5.0, "Madrid"),
                new("Laura", 22, 9.5, "Valencia"),
                new("Carlos", 26, 3.2, "Sevilla"),
                new("Elena", 21, 8.0, "Valencia"),
                new("Diego", 23, 6.5, "Madrid")
            };

            // Informe completo: alumnos aprobados de Madrid, ordenados por nota descendente
            alumnos
                .Where(a => a.Ciudad == "Madrid")     // Filtrar por ciudad
                .Where(a => a.Nota >= 5)              // Filtrar aprobados
                .OrderByDescending(a => a.Nota)       // Ordenar por nota
                .Select(a => new                      // Proyectar datos
                {
                    a.Nombre,
                    NotaFormateada = $"{a.Nota:F1}/10",
                    Calificacion = a.Nota switch
                    {
                        >= 9 => "Sobresaliente",
                        >= 7 => "Notable",
                        >= 5 => "Aprobado",
                        _ => "Suspendido"
                    }
                })
                .ToList()
                .ForEach(e => Console.WriteLine($"{e.Nombre}: {e.NotaFormateada} ({e.Calificacion})"));
            // Salida:
            // María: 9.2/10 (Sobresaliente)
            // Ana: 8.5/10 (Notable)
            // Diego: 6.5/10 (Aprobado)
            // Javier: 5.0/10 (Aprobado)

        }

        static void EjecucionesDiferidas()  // Lazy Evaluation
        {
            List<Alumno> alumnos = new()
            {
                new("Ana", 22, 8.5, "Madrid"),
                new("Luis", 25, 6.0, "Barcelona"),
                new("María", 20, 9.2, "Madrid"),
                new("Pedro", 23, 4.5, "Sevilla"),
                new("Carmen", 21, 7.8, "Barcelona"),
                new("Javier", 24, 5.0, "Madrid"),
                new("Laura", 22, 9.5, "Valencia"),
                new("Carlos", 26, 3.2, "Sevilla"),
                new("Elena", 21, 8.0, "Valencia"),
                new("Diego", 23, 6.5, "Madrid")
            };

            var consulta = alumnos.Where(a => a.Nota >= 5);  // Genera una plantilla de consulta, pero no se ejecuta nada todavía.
            // ¡Aquí NO se ha ejecutado nada todavía!

            // Se ejecuta al recorrer o materializar
            var lista = consulta.ToList();      // Se ejecuta ahora
            int total = consulta.Count();        // Se ejecuta de nuevo
            foreach (var a in consulta) { }      // Se ejecuta de nuevo

        }


        static void Main(string[] args)
        {
            //DevolverParesOrdenados(new List<int> { 8, 3, 15, 1, 42, 7, 23, 5, 19, 2 }).ForEach(n => Console.WriteLine(n));
            //DevolverParesOrdenadosQuerySyntax(new List<int> { 8, 3, 15, 1, 42, 7, 23, 5, 19, 2 }).ForEach(n => Console.WriteLine(n));
            //LINQFundamentales();
            //TakeSkip();
            //Posiciones();
            //AnyAllCount();
            //EjemplosEstadisticas();
            //EjemploAggregate();
            //EjemplosDistintosConjuntos();
            //TransformacionesColecciones();
            //ConsultasComplejas();
            //EjecucionesDiferidas();
        }
    }
}