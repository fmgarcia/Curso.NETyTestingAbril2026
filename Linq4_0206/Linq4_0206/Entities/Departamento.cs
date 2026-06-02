using System;
using System.Collections.Generic;
using System.Text;

namespace Linq4_0206.Entities
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public List<Empleado> Empleados { get; set; } = new List<Empleado>();

        public Departamento()
        {

        }

        public Departamento(int departamentoId, string nombre)
        {
            DepartamentoId = departamentoId;
            Nombre = nombre;
        }

        public Departamento(int departamentoId, string nombre, List<Empleado> empleados)
        {
            DepartamentoId = departamentoId;
            Nombre = nombre;
            Empleados = empleados;
        }

        public override string ToString()
        {
            return $"DepartamentoId: {DepartamentoId}, Nombre: {Nombre}, Empleados: {Empleados.Count}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Departamento departamento &&
                DepartamentoId == departamento.DepartamentoId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DepartamentoId);
        }

    }
}
