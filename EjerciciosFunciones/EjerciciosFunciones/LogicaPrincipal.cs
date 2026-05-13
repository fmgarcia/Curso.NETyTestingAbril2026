using System;
using System.Collections.Generic;
using System.Text;

namespace EjerciciosFunciones
{
    internal class LogicaPrincipal
    {

        public bool EsOpcionValida(string opcion) => opcion is "1" or "2" or "3" or "4";

        public bool EjecutarCalculo(string opcion)
        {
            InterfazUsuario interfaz = new InterfazUsuario();
            double num1 = PedirNumero("Ingrese el primer número:");
            double num2 = PedirNumero("Ingrese el segundo número:");
            // Valido que no se divida por cero
            if (opcion == "4" && num2 == 0)
            {
                interfaz.MostrarError("No se puede dividir por cero. Inténtalo de nuevo.");
                return false;
            }
            // Ya sé que la opción es válida.
            double resultado = EvaluarOperacion(opcion, num1, num2);
            interfaz.MostrarMensaje($"El resultado es: {resultado}");
            return true;

        }

        public double PedirNumero(string mensaje)
        {
            double numero;
            InterfazUsuario interfaz = new InterfazUsuario();
            interfaz.MostrarMensaje(mensaje);
            while (!double.TryParse(Console.ReadLine(), out numero))
            {
                interfaz.MostrarError("Entrada no válida. Por favor, ingrese un número.");
            }
            return numero;
        }

        public double EvaluarOperacion(string opcion, double num1, double num2)
        {
            OperacionesMatematicas operaciones = new OperacionesMatematicas();
            return opcion switch
            {
                "1" => operaciones.Sumar(num1, num2),
                "2" => operaciones.Restar(num1, num2),
                "3" => operaciones.Multiplicar(num1, num2),
                "4" => operaciones.Dividir(num1, num2),
                _ => throw new InvalidOperationException("Opción no válida.")
            };
        }


    }
}
