
namespace POO1505
{
    class Program
    {

        static void EjemplosPersona()
        {
            Persona fran = new Persona(); // Crear una instancia de la clase Persona. Sin datos iniciales, se asignan valores predeterminados (null para string, 0 para int).
            fran.Nombre = "Francisco";
            fran.Edad = 30;
            fran.Email = "francisco@example.com";
            fran.Salario = 50000.00m;


            Persona paco = new Persona("Paco", 49, "paco@ejemplo.com");
            paco.Edad = 100;
            Persona consuelo = new Persona("Consuelo", 25);
            Console.WriteLine(consuelo.Salario);

            fran.Presentarse();
            paco.Presentarse();
            consuelo.Presentarse();

            fran.CumplirAños();
            fran.Presentarse();

            Persona dani = new Persona("Dani", 40, "dani@example.com", 60000.00m);
            Persona pablo = new()
            {
                Nombre = "Pablo",
                Edad = 35,
                Email = ""
            };

            var luis = new Persona();
        }

        static void EjemplosRectangulo()
        {
            Rectangulo rectangulo1 = new Rectangulo(10, 5);
            rectangulo1.Ancho = 20;
            Console.WriteLine($"El área del rectángulo es: {rectangulo1.CalcularArea()}");
            Console.WriteLine($"El área del rectángulo es {rectangulo1.Area}");
        }

        static void EjemplosCuentaBancaria()
        {
            CuentaBancaria cuenta1 = new CuentaBancaria("Juan Pérez", 1000);
            cuenta1.Saldo = -1000; // Esto no debería ser permitido, pero no hay validación en la clase.
            Console.WriteLine($"Saldo actual: {cuenta1.Saldo}");
            cuenta1.Deuda = -1000;
            Console.WriteLine($"La deuda actual: {cuenta1.Deuda}");

            CuentaBancaria cuenta2 = new CuentaBancaria("María Gómez", 500, -1000);
            Console.WriteLine(cuenta2.Deuda);
            cuenta2.AsignarValorNegativoDeuda(-500);
            Console.WriteLine(cuenta2.Deuda);
            cuenta2.AsignarValorNegativoSaldo(-500);
            Console.WriteLine(cuenta2.Saldo);

        }

        static void Main(string[] args)
        {
            //EjemplosPersona();
            //EjemplosRectangulo();
            EjemplosCuentaBancaria();
        }
    }
}





