using EjerciciosPOOListas2005.Ejercicio3POO;

namespace EjerciciosPOOListas2005
{
    internal class Program
    {

        // Ejercicio 3: Biblioteca
        // Crea clases Libro y Biblioteca.La biblioteca tiene una lista de libros y métodos para: añadir, buscar por título/autor,
        // prestar (marcar como no disponible), devolver.Sobrescribe ToString().

        static void MostrarMenuBiblioteca()
        {
            Console.WriteLine("1. Agregar libro");
            Console.WriteLine("2. Buscar por título");
            Console.WriteLine("3. Buscar por autor");
            Console.WriteLine("4. Prestar libro");
            Console.WriteLine("5. Devolver libro");
            Console.WriteLine("6. Mostrar biblioteca");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
        }

        static void Ejercicio3POO()
        {
            string titulo = "";
            string autor = "";
            Biblioteca biblioteca;
            SerializarObjeto<Biblioteca> serializador;
            if (File.Exists(@"biblioteca.json")) // Si el archivo existe, se carga la biblioteca desde el archivo.
            {
                serializador = new SerializarObjeto<Biblioteca>(new Biblioteca());
                biblioteca = serializador.Deserializar(@"biblioteca.json");
                Console.WriteLine("Biblioteca cargada desde archivo.");
            }
            else  // Es la primera vez que se ejecuta el programa, no existe el archivo, así que se crea una nueva biblioteca.
            {
                biblioteca = new Biblioteca("Mi Biblioteca");
            }
            while (true)
            {
                MostrarMenuBiblioteca();
                string opcion = Console.ReadLine()!;
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Introduce el título del libro:");
                        titulo = Console.ReadLine()!;
                        Console.WriteLine("Introduce el autor del libro:");
                        autor = Console.ReadLine()!;
                        biblioteca.AgregarLibro(new Libro(titulo, autor));
                        break;
                    case "2":
                        Console.WriteLine("Introduce el título del libro:");
                        titulo = Console.ReadLine()!;
                        Console.WriteLine(biblioteca.BuscarPorTitulo(titulo));
                        break;
                    case "3":
                        Console.WriteLine("Introduce el autor del libro:");
                        autor = Console.ReadLine()!;
                        Console.WriteLine(biblioteca.BuscarPorAutor(autor));
                        break;
                    case "4":
                        Console.WriteLine("Introduce el título del libro:");
                        titulo = Console.ReadLine()!;
                        biblioteca.PrestarLibro(titulo);
                        break;
                    case "5":
                        Console.WriteLine("Introduce el título del libro:");
                        titulo = Console.ReadLine()!;
                        biblioteca.DevolverLibro(titulo);
                        break;
                    case "6":
                        Console.WriteLine(biblioteca);
                        break;
                    case "7":
                        serializador = new(biblioteca);
                        serializador.Serializar(@"biblioteca.json"); // Se guarda la biblioteca en un archivo para que esté disponible la próxima vez que se ejecute el programa.
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            Ejercicio3POO();
        }
    }

}
