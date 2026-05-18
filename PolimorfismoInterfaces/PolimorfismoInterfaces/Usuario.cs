using System;
using System.Collections.Generic;
using System.Text;

namespace PolimorfismoInterfaces
{
    class Usuario : IRegistrable
    {
        public string Nombre { get; set; } = "";
        // No necesita implementar Registrar() si le vale la implementación por defecto

        // Si quieres personalizar el comportamiento de Registrar, puedes hacerlo así:
        //public void Registrar()
        //{
        //    Console.WriteLine($"Usuario {Nombre} registrado exitosamente a las {DateTime.Now:HH:mm:ss}");
        //}
    }
}
