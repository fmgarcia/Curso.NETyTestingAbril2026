using System;
using System.Collections.Generic;
using System.Text;

namespace PolimorfismoInterfaces
{
    interface IRegistrable
    {
        string Nombre { get; }

        // Método con implementación por defecto. Disponible desde C# 8.0
        void Registrar()
        {
            Console.WriteLine($"Registrando: {Nombre} a las {DateTime.Now:HH:mm:ss}");
        }
    }
}
