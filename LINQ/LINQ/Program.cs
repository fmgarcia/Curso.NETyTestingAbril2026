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


        static void Main(string[] args)
        {
            //DevolverParesOrdenados(new List<int> { 8, 3, 15, 1, 42, 7, 23, 5, 19, 2 }).ForEach(n => Console.WriteLine(n));
            //DevolverParesOrdenadosQuerySyntax(new List<int> { 8, 3, 15, 1, 42, 7, 23, 5, 19, 2 }).ForEach(n => Console.WriteLine(n));
            LINQFundamentales();
        }
    }
}