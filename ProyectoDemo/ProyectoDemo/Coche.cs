using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoDemo
{
    public class Coche
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Matricula { get; set; } = string.Empty;

        public Coche() { }

        public Coche(int id, string marca, string modelo, string matricula)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Matricula = matricula;
        }

        public override string ToString()
        {
            return $"Coche: Id={Id},  Marca={Marca}, Modelo={Modelo}, Matricula={Matricula}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Coche coche &&
                   Id == coche.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
