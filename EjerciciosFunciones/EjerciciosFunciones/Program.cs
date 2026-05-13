
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EjerciciosFunciones
{
    internal class Program
    {


        //Ejercicio 1: Calculadora con funciones
        //Crea una calculadora donde cada operación (Sumar, Restar, Multiplicar, Dividir) sea una función separada. El programa muestra un menú, pide dos números y la operación.
        static void Ejercicio1()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Para mostrar caracteres especiales como el símbolo de división
            InterfazUsuario interfaz = new InterfazUsuario();
            LogicaPrincipal principal = new LogicaPrincipal();
            bool salir = false;
            string menuTexto = " === CALCULADORA BÁSICA ===\n1. Sumar\n2. Restar\n3. Multiplicar\n4. Dividir\n0. Salir";

            while (!salir)
            {
                string opcion = interfaz.MostrarMenu(menuTexto);
                if (opcion == "0")
                {
                    interfaz.MostrarMensaje("¡Hasta luego!");
                    salir = true;
                    continue;
                }
                if (principal.EsOpcionValida(opcion))
                {
                    principal.EjecutarCalculo(opcion);
                }
                else
                {
                    interfaz.MostrarError("Opción no válida. Inténtalo de nuevo.");
                }
            }
        }

        //Ejercicio 2: Conversor de temperaturas
        //Crea funciones:

        //CelsiusAFahrenheit(double celsius) → retorna Fahrenheit
        //FahrenheitACelsius(double fahrenheit) → retorna Celsius
        //CelsiusAKelvin(double celsius) → retorna Kelvin
        static void Ejercicio2()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Para mostrar caracteres especiales como el símbolo de división
            InterfazUsuario interfaz = new InterfazUsuario();
            ConversorTemperatura LogicaPrincipal = new ConversorTemperatura();
            bool salir = false;
            string menuTexto = " === CONVERSOR DE TEMPERATURAS ===\n1. Celsius a Fahrenheit\n2. Fahrenheit a Celsius\n3. Celsius a Kelvin\n0. Salir";
            while (!salir)
            {
                string opcion = interfaz.MostrarMenu(menuTexto);
                if (opcion == "0")
                {
                    interfaz.MostrarMensaje("¡Hasta luego!");
                    salir = true;
                    continue;
                }
                if (opcion == "1")
                {
                    interfaz.MostrarMensaje("Introduce la temperatura en Celsius:");
                    double numero;
                    while (!double.TryParse(Console.ReadLine(), out numero))
                    {
                        interfaz.MostrarError("Entrada no válida. Por favor, ingrese un número.");
                    }
                    double resultado = LogicaPrincipal.CelsiusAFahrenheit(numero);
                    interfaz.MostrarMensaje($"{numero} °C son {resultado:F2} °F");
                }
                else if (opcion == "2")
                {
                    interfaz.MostrarMensaje("Introduce la temperatura en Fahrenheit:");
                    double numero;
                    while (!double.TryParse(Console.ReadLine(), out numero))
                    {
                        interfaz.MostrarError("Entrada no válida. Por favor, ingrese un número.");
                    }
                    double resultado = LogicaPrincipal.FahrenheitACelsius(numero);
                    interfaz.MostrarMensaje($"{numero} °F son {resultado:F2} °C");
                }
                else if (opcion == "3")
                {
                    interfaz.MostrarMensaje("Introduce la temperatura en Celsius:");
                    double numero;
                    while (!double.TryParse(Console.ReadLine(), out numero))
                    {
                        interfaz.MostrarError("Entrada no válida. Por favor, ingrese un número.");
                    }
                    double resultado = LogicaPrincipal.CelsiusAKelvin(numero);
                    interfaz.MostrarMensaje($"{numero} °C son {resultado:F2} K");
                }
                else
                {
                    interfaz.MostrarError("Opción no válida. Inténtalo de nuevo.");
                }
            }
        }


        static void Main(string[] args)
        {
            //Ejercicio1();
            Ejercicio2();
        }
    }
}