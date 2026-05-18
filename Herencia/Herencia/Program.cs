namespace Herencia
{
    class Program
    {

        static void PruebasAnimales()
        {
            Animal animal1 = new Animal();
            animal1.Nombre = "Generic Animal";
            animal1.Edad = 5;

            animal1.Comer(); // Output: "Generic Animal está comiendo."
            animal1.Dormir(); // Output: "Generic Animal está durmiendo."



            Perro perro = new Perro
            {
                Nombre = "Rex",       // Heredado de Animal
                Edad = 3,             // Heredado de Animal
                Raza = "Pastor alemán" // Propio de Perro
            };

            perro.Comer();   // Heredado de Animal: "Rex está comiendo."
            perro.Ladrar();  // Propio de Perro: "Rex dice: ¡Guau!"
            perro.HacerSonido(); // Sobrescrito en Perro, hará el sonido genérico del padre y luego el específico del perro: "(sonido genérico)" seguido de "¡Guau guau!"

            Gato gato = new Gato { Nombre = "Luna", Edad = 2, EsDeInterior = true };
            gato.Comer();    // Heredado de Animal
            gato.Maullar();  // Propio de Gato 
        }


        static void PruebasIsCastingAnimales()
        {
            Animal miAnimal = new Perro { Nombre = "Rex", Raza = "Labrador" };

            // Comprobar tipo con 'is'
            if (miAnimal is Perro perro)
            {
                Console.WriteLine($"Es un perro de raza {perro.Raza}");
            }

            // Casting explícito
            if (miAnimal is Perro)
            {
                Perro p = (Perro)miAnimal;  // Cast directo (lanza excepción si no es Perro)
            }

            // Casting con 'as' (devuelve null si no es compatible)
            Gato? gato = miAnimal as Gato;  // null porque miAnimal es Perro, no Gato
            if (gato is not null)
            {
                Console.WriteLine($"Es un gato: {gato.Nombre}");
            }
        }

        static void PruebasToStringAnimales()
        {
            var p = new Perro { Nombre = "Rex", Raza = "Labrador" };
            Console.WriteLine(p);  // "Perro: Rex, Raza: Labrador"
        }

        static void PruebasEmpleados()
        {
            // Uso
            var emp = new Empleado { Nombre = "Ana", SalarioBase = 2000 };
            var com = new EmpleadoConComision
            {
                Nombre = "Luis",
                SalarioBase = 1500,
                Ventas = 50000,
                PorcentajeComision = 5
            };
            var dir = new Directivo { Nombre = "María", SalarioBase = 4000, BonoAnual = 12000 };

            Console.WriteLine(emp);  // Ana: 2.000,00 €
            Console.WriteLine(com);  // Luis: 4.000,00 €  (1500 + 50000*5%)
            Console.WriteLine(dir);  // María: 5.000,00 €  (4000 + 12000/12)
        }

        static void PruebasVehiculos()
        {
            var coche = new Coche("Toyota", "Corolla", 2024, 4);
        }


        static void PruebasFiguras()
        {
            // Uso
            // Figura f = new Figura();  // ERROR: no se puede instanciar una clase abstracta

            Figura circulo = new Circulo(5) { Color = "Rojo" };
            Figura rect = new Rectangulo(4, 6) { Color = "Azul" };

            circulo.MostrarInfo();
            rect.MostrarInfo();

            // Polimorfismo: una lista de diferentes figuras
            List<Figura> figuras = new() { circulo, rect, new Triangulo
            {
                Base = 3, Altura = 4, Lado1 = 3, Lado2 = 4, Lado3 = 5
            }};

            double areaTotal = 0;
            foreach (Figura f in figuras)
            {
                areaTotal += f.CalcularArea();  // Cada figura calcula su propia área
            }
            Console.WriteLine($"Área total: {areaTotal:F2}");
        }

        static void PruebaConfiguracion()
        {
            var config = ConfiguracionApp.Instancia;
            Console.WriteLine(config.NombreApp);
        }


        static void Main(string[] args)
        {
            //PruebasAnimales();
            //PruebasEmpleados();
            //PruebasFiguras();
            //PruebaConfiguracion();
            //PruebasIsCastingAnimales();
            PruebasToStringAnimales();



        }
    }

}
