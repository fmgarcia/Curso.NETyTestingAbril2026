
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
            while (!salir)
            {
                string opcion = interfaz.MostrarMenu();
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

        static void Main(string[] args)
        {
            Ejercicio1();

        }
    }
}