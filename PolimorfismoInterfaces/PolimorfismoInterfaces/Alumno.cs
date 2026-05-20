using System;
using System.Collections.Generic;
using System.Text;

namespace PolimorfismoInterfaces
{
    internal class Alumno : IComparable<Alumno>
    {
        // Atributos de la clase Alumno
        public string Nombre { get; set; } = "";
        public DateTime FechaNacimiento { get; set; }
        public string CodigoAlumno { get; set; } = "";

        // Constructor de la clase Alumno
        public Alumno()
        {

        }
        public Alumno(string nombre, DateTime fechaNacimiento, string codigoAlumno)
        {
            Nombre = nombre;
            FechaNacimiento = fechaNacimiento;
            CodigoAlumno = codigoAlumno;
        }

        // Métodos adicionales de la clase Alumno

        public int CalcularEdad()
        {
            var hoy = DateTime.Today;
            var edad = hoy.Year - FechaNacimiento.Year;
            if (FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
            return edad;
        }

        // Sobrescribir el método ToString() para mostrar información del alumno
        public override string ToString()
        {
            return $"Alumno: {Nombre}, Código: {CodigoAlumno}, Edad: {CalcularEdad()} años";
        }

        // Método HashCode y Equals para comparar objetos Alumno por su CódigoAlumno
        public override bool Equals(object? obj)
        {
            return obj is Alumno alumno &&
                   CodigoAlumno == alumno.CodigoAlumno;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CodigoAlumno);
        }

        public int CompareTo(Alumno? other)
        {
            if (other == null) return 1;
            //return string.Compare(CodigoAlumno, other.CodigoAlumno, StringComparison.Ordinal); // Comparar por código de alumno
            return CalcularEdad().CompareTo(other.CalcularEdad()); // Comparar por edad
        }
    }
}
