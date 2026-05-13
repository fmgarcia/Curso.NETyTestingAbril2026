using System;
using System.Collections.Generic;
using System.Text;

namespace EjerciciosFunciones
{
    internal class InterfazUsuario
    {

        public bool MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
            return true;
        }

        public bool MostrarError(string mensaje)
        {
            Console.WriteLine($"❌ Error: {mensaje}");
            return true;
        }

        public string MostrarMenu()
        {
            Console.WriteLine($" === CALCULADORA BÁSICA ===");
            Console.WriteLine("1. Sumar");
            Console.WriteLine("2. Restar");
            Console.WriteLine("3. Multiplicar");
            Console.WriteLine("4. Dividir");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            return Console.ReadLine() ?? "";
        }


    }
}
