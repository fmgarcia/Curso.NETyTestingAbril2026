namespace ManejoErrores1305
{
    internal class Program
    {

        static void MostrarSaludo(string nombre)
        {
            Console.WriteLine($"Hola {nombre}!");
        }

        static void DivisionZeroSinControlar()
        {
            int a = 10;
            int b = 0;
            int resultado = a / b; // Esto lanzará una excepción de división por cero
        }

        static void DivisionZeroControlada()
        {
            int a = 10;
            int b = 0;
            try
            {
                int resultado = a / b;
            }
            catch (Exception)
            {

                Console.WriteLine("No se puede dividir por cero");
            }
        }
        static void DivisionZeroControladaConIf()
        {
            int a = 10;
            int b = 0;

            if (b != 0)
            {
                int resultado = a / b;
            }
            else
            {
                Console.WriteLine("No se puede dividir por cero");
            }

        }
        static void MultiplesExcepciones()
        {
            int a = 10;
            int b = 0;
            try
            {
                int resultado = a / b;
                string contenido = File.ReadAllText("archivo_inexistente.txt"); // Esto lanzará una excepción de archivo no encontrado
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"No se puede dividir por cero: {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"El archivo no se encontró: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
            }
        }


        static void LecturaFichero()
        {
            StreamReader? lector = null;

            try
            {
                lector = new StreamReader("datos.txt");
                string contenido = lector.ReadToEnd();
                Console.WriteLine(contenido);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("El archivo no existe.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al leer: {ex.Message}");
            }
            finally
            {
                // Se ejecuta SIEMPRE
                lector?.Close();  // ?. → solo llama a Close si lector no es null
                Console.WriteLine("Recurso liberado.");
            }
        }

        static double CalcularIMC(double peso, double altura)
        {
            if (peso <= 0)
                throw new ArgumentException("El peso debe ser mayor que 0", nameof(peso));

            if (altura <= 0)
                throw new ArgumentException("La altura debe ser mayor que 0", nameof(altura));

            return peso / (altura * altura);
        }

        static void Main(string[] args)
        {
            //DivisionZeroSinControlar();
            //DivisionZeroControlada();
            //MultiplesExcepciones();
            try
            {
                double imc = CalcularIMC(0, 1.70);
                Console.WriteLine($"Su IMC es: {imc:F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Datos inválidos: {ex.Message}");
                // "Datos inválidos: La altura debe ser mayor que 0 (Parameter 'altura')"
                //throw; // Re-lanza la excepción para que el programa termine con error
            }
            Console.WriteLine("Fin del programa");

            // Programa
            var cuenta = new CuentaBancaria(100);

            try
            {
                cuenta.Retirar(50);   // OK
                cuenta.Retirar(80);   // Error: solo tiene 50
            }
            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Te faltan: {ex.MontoSolicitado - ex.SaldoActual:C2}");
            }

        }
    }
}
