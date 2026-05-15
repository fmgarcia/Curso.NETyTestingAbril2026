namespace EjerciciosPOO1505
{
    internal class Program
    {



        static void Ejercicio1A()
        {
            Alumno2[] alumnos =
            [
                new Alumno2("Ana", [7.5, 8.0, 6.5]),
                new Alumno2("Luis", [4.0, 5.0, 3.5]),
                new Alumno2("Marta", [9.0, 8.5, 9.5]),
                new Alumno2("Pablo", [5.0, 5.5, 6.0])
            ];

            alumnos
                .Select(alumno => alumno.ToString())
                .ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine();
            Console.WriteLine($"¿Ana y Luis son iguales?: {alumnos[0].Equals(alumnos[1])}");
            Console.WriteLine($"¿Ana y otra Ana con mismas notas son iguales?: {alumnos[0].Equals(new Alumno2("Ana", [7.5, 8.0, 6.5]))}");
        }

        static void Ejercicio1()
        {
            Alumno fran = new Alumno("Fran", new double[] { 5.5, 7.0, 8.0 });
            Alumno consuelo = new Alumno("Consuelo", new double[] { 4.0, 6.5, 9.0 });

            Console.WriteLine($"Alumno: {fran.Nombre}");
            Console.WriteLine($"Media: {fran.Media()}");
            Console.WriteLine($"Nota máxima: {fran.NotaMaxima()}");
            Console.WriteLine($"Aprobado: {fran.Aprobado()}");

            Console.WriteLine($"Alumno: {consuelo.Nombre}");
            Console.WriteLine($"Media: {consuelo.Media()}");
            Console.WriteLine($"Nota máxima: {consuelo.NotaMaxima()}");
            Console.WriteLine($"Aprobado: {consuelo.Aprobado()}");

        }

        static void Main(string[] args)
        {
            Ejercicio1();
            Console.WriteLine();
            Ejercicio1A();
            Console.WriteLine();

        }
    }

}
