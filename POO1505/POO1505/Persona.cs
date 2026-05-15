using System;
using System.Collections.Generic;
using System.Text;

namespace POO1505
{
    internal class Persona
    {
        // Propiedades de la clase Persona
        public string Nombre { get; set; } = "";
        public int Edad { get; set; } = 0;
        public string Email { get; set; } = "";
        public decimal Salario { get; set; } = 0.0m;

        // Constructor de la clase Persona

        // Constructor sin parámetros (opcional, ya que C# proporciona uno por defecto si no se define ningún constructor)
        public Persona() { }

        // Constructor con parámetros para inicializar las propiedades de la clase
        public Persona(string nombre, int edad, string email, decimal salario)
        {
            Nombre = nombre;
            Edad = edad;
            Email = email;
            Salario = salario;
        }


        public Persona(string nombre, int edad, string email)
        {
            Nombre = nombre;
            Edad = edad;
            Email = email;
        }

        // Constructor con parámetros para inicializar solo el nombre y la edad, dejando el email vacío
        public Persona(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
            Email = ""; // Email se deja vacío si no se proporciona
        }


        // Métodos de la clase Persona
        public void Presentarse()
        {
            Console.WriteLine($"Hola, mi nombre es {Nombre}, tengo {Edad} años y mi email es {Email}.");
        }

        public void Despedirse()
        {
            Console.WriteLine($"Adiós, soy {Nombre}.");
        }

        public void CumplirAños()
        {
            Edad++;
            Console.WriteLine($"¡Feliz cumpleaños, {Nombre}! Ahora tienes {Edad} años.");
        }

    }
}
