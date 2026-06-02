using System;
using System.Collections.Generic;
using System.Text;

namespace Linq4_0206.Entities
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public decimal Salario { get; set; }

        public Empleado()
        {

        }

        public Empleado(int id, string nombre, string apellido, string departamento, decimal salario)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Departamento = departamento;
            Salario = salario;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre} {Apellido}, Departamento: {Departamento}, Salario: {Salario:C}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Empleado empleado &&
                   Id == empleado.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
