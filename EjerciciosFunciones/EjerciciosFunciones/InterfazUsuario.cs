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

        public string MostrarMenu(string texto)
        {
            Console.WriteLine(texto);
            Console.Write("Seleccione una opción: ");
            return Console.ReadLine() ?? "";
        }


    }
}
