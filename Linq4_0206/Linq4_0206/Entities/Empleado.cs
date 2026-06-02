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
        public int DepartamentoId { get; set; }
        public decimal Salario { get; set; }

        public Empleado()
        {

        }

        public Empleado(int id, string nombre, string apellido, int departamentoId, decimal salario)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            DepartamentoId = departamentoId;
            Salario = salario;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre} {Apellido}, DepartamentoId: {DepartamentoId}, Salario: {Salario:C}";
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
