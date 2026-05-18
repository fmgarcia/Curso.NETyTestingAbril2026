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

        static void Main(string[] args)
        {
            //EjemploPolimorfismo();
            EjemplosInterfaces();
        }
    }
}
