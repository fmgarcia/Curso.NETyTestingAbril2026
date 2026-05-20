namespace PolimorfismoInterfaces
{
    class Program
    {



        static void EjemploPolimorfismo()
        {

            // Polimorfismo en acción: todos son Animal, pero cada uno actúa diferente
            List<Animal> animales = new()
            {
                new Perro { Nombre = "Rex" },
                new Gato { Nombre = "Luna" },
                new Pato { Nombre = "Donald" }
            };

            foreach (Animal animal in animales)
            {
                // HacerSonido() llama al método correcto según el tipo REAL
                Console.WriteLine($"{animal.Nombre}: {animal.HacerSonido()}");
            }
            // Rex: ¡Guau!
            // Luna: ¡Miau!
            // Donald: ¡Cuac!
        }

        static void EjemplosInterfaces()
        {
            // Puedes crear una lista de "cosas que vuelan" sin importar qué sean
            List<IVolador> voladores = new()
            {
                new Pato { Nombre = "Donald" },
                new Avion()
            };

            foreach (IVolador v in voladores)
            {
                v.Despegar();
                Console.WriteLine($"Altura: {v.AlturaActual}m");
                v.Aterrizar();
                Console.WriteLine("---");
            }
        }

        static void ProbarInteracesSistema()
        {
            Alumno fran = new()
            {
                Nombre = "Fran",
                FechaNacimiento = new DateTime(1976, 10, 15),
                CodigoAlumno = "A12345"
            };
            Alumno consuelo = new()
            {
                Nombre = "Consuelo",
                FechaNacimiento = new DateTime(1998, 10, 20),
                CodigoAlumno = "A12345"
            };
            Alumno dani = new()
            {
                Nombre = "Dani",
                FechaNacimiento = new DateTime(1995, 5, 10),
                CodigoAlumno = "A54321"
            };

            List<Alumno> alumnos = new() { fran, consuelo, dani };

            if (fran.Equals(consuelo))
            {
                Console.WriteLine("¡Son el mismo alumno!");
            }
            else
            {
                Console.WriteLine("Son alumnos diferentes.");
            }


            // Comparar edades usando IComparable
            if (fran.CompareTo(consuelo) > 0)
            {
                Console.WriteLine($"Fran es mayor que Consuelo");
            }
            else if (fran.CompareTo(consuelo) < 0)
            {
                Console.WriteLine($"Fran es menor que Consuelo");
            }
            else
            {
                Console.WriteLine($"Fran y Consuelo tienen la misma edad");
            }
            // Podemos ordenar la lista de alumnos por edad usando el método Sort, que utiliza IComparable
            alumnos.Sort();
            Console.WriteLine("Alumnos ordenados por edad:");
            foreach (var alumno in alumnos)
            {
                Console.WriteLine(alumno);
            }
        }

        // Declaración concisa de un record
        record Coordenada(double Latitud, double Longitud);

        static void EjemploRecord()
        {

            // Uso
            var madrid = new Coordenada(40.4168, -3.7038);
            var barcelona = new Coordenada(41.3879, 2.1699);

            Console.WriteLine(madrid);    // Coordenada { Latitud = 40.4168, Longitud = -3.7038 }

            // Igualdad por valor (no por referencia)
            var madrid2 = new Coordenada(40.4168, -3.7038);
            Console.WriteLine(madrid == madrid2);  // True (con class sería False)

            // Copia con modificación usando 'with'
            var madridCerca = madrid with { Latitud = 40.42 };
            Console.WriteLine(madridCerca);  // Coordenada { Latitud = 40.42, Longitud = -3.7038 }

            // madrid.Latitud = 40.5; // Error: los records son inmutables por defecto, no se pueden modificar sus propiedades después de la creación

        }

        // Ejemplo de patrón switch con tipos


        static void PruebasSwithTipos()
        {
            var formas = new Forma[]
            {
                new Circulo { Radio = 5 },
                new Rectangulo { Ancho = 4, Alto = 6 },
                new Triangulo { Base = 3, Altura = 8 }
            };

            foreach (var f in formas)
            {
                Console.WriteLine($"{f.GetType().Name}: área = {f.CalcularArea():F2}");
            }

            Circulo circulo = new() { Radio = 5 };
            Console.WriteLine($"área = {circulo.CalcularArea():F2}");

        }

        // Ejemplo de patrón switch con propiedades de un record
        record Pedido(string Cliente, double Total, string Pais);

        static double CalcularEnvio(Pedido pedido) => pedido switch
        {
            { Total: > 100, Pais: "España" } => 0,           // Envío gratis en España +100€
            { Pais: "España" } => 4.99,                       // España < 100€
            { Pais: "Portugal" or "Francia" } => 9.99,        // Países vecinos
            { Total: > 200 } => 14.99,                        // Gran pedido internacional
            _ => 19.99                                         // Resto del mundo
        };


        static void Main(string[] args)
        {
            //EjemploPolimorfismo();
            //EjemplosInterfaces();
            //ProbarInteracesSistema();
            //EjemploRecord();
            PruebasSwithTipos();
        }
    }
}
