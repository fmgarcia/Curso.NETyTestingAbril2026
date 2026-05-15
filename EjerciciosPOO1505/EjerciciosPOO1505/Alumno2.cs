namespace EjerciciosPOO1505
{
    internal class Alumno2
    {
        public string Nombre { get; set; } = string.Empty;
        public double[] Notas { get; set; } = [];

        public Alumno2() { }

        public Alumno2(string nombre, double[] notas)
        {
            Nombre = nombre;
            Notas = notas;
        }

        public double Media()
        {
            return Notas.DefaultIfEmpty().Average();
        }

        public double NotaMaxima()
        {
            return Notas.DefaultIfEmpty().Max();
        }

        public bool Aprobado()
        {
            return Media() >= 5;
        }

        public override string ToString()
        {
            return $"Alumno: {Nombre}, Notas: [{string.Join(", ", Notas)}], Media: {Media():0.##}, Nota máxima: {NotaMaxima():0.##}, Aprobado: {Aprobado()}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Alumno2 otro &&
                   Nombre == otro.Nombre &&
                   Notas.SequenceEqual(otro.Notas);
        }

        public override int GetHashCode()
        {
            return Notas.Aggregate(HashCode.Combine(Nombre), (hash, nota) => HashCode.Combine(hash, nota));
        }
    }
}
