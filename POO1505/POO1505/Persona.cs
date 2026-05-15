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

        public static int ContadorPersonas = 0; // Campo estático para contar el número de personas creadas

        // Constructor de la clase Persona

        // Constructor sin parámetros (opcional, ya que C# proporciona uno por defecto si no se define ningún constructor)
        public Persona()
        {
            ContadorPersonas++;
        }

        // Constructor con parámetros para inicializar las propiedades de la clase
        public Persona(string nombre, int edad, string email, decimal salario)
        {
            Nombre = nombre;
            Edad = edad;
            Email = email;
            Salario = salario;
            ContadorPersonas++;
        }


        public Persona(string nombre, int edad, string email)
        {
            Nombre = nombre;
            Edad = edad;
            Email = email;
            ContadorPersonas++;
        }

        // Constructor con parámetros para inicializar solo el nombre y la edad, dejando el email vacío
        public Persona(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
            Email = ""; // Email se deja vacío si no se proporciona
            ContadorPersonas++;
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

        // Método estático para mostrar el número total de personas creadas multiplicado por dos
        // Este método no requiere una instancia de la clase para ser llamado, ya que es estático.
        public static string MostrarContadorPersonasPorDos()
        {
            return $"Número total de personas creadas por dos: {ContadorPersonas * 2}";
        }

        public override string ToString()
        {
            return $"Persona: {Nombre}\nEdad: {Edad}\nMail: {Email}\nSueldo: {Salario:C}";
        }



    }
}
