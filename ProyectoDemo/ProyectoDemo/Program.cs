namespace ProyectoDemo
{
    internal class Program
    {

        static List<Coche> coches = new List<Coche>();

        public static void ImprimirMenu()
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Agregar coche");
            Console.WriteLine("2. Listar coches");
            Console.WriteLine("3. Eliminar coche");
            Console.WriteLine("4. Actualizar coche");
            Console.WriteLine("5. Buscar coche");
            Console.WriteLine("0. Salir");
            Console.WriteLine("Selecciona una opción: ");
        }

        /// <summary>
        /// Declaramos una variable de tipo coche, pedimos los datos y lo añadimos a la lista
        /// </summary>
        static void AgregarCoche()
        {
            Coche coche = new Coche(); // Creamos un coche sin datos
            Console.WriteLine("Introduzca el Id del coche");
            if (int.TryParse(Console.ReadLine(), out int idParseado))
            {
                coche.Id = idParseado;
            }
            else
            {
                Console.WriteLine("Error: Formato de ID incorrecto. Se asignará 0 por defecto.");
                coche.Id = 0;
            }

            Console.Write("Introduce la Marca: ");
            coche.Marca = Console.ReadLine() ?? string.Empty;

            Console.Write("Introduce el Modelo: ");
            coche.Modelo = Console.ReadLine() ?? string.Empty;

            Console.Write("Introduce la Matrícula: ");
            coche.Matricula = Console.ReadLine() ?? string.Empty;
            coches.Add(coche);  // Añado el coche a la lista
        }

        /// <summary>
        /// Recorremos la lista de coches y mostramos su ToString
        /// </summary>
        static void ListarCoches()
        {
            coches.ForEach(c => Console.WriteLine(c));
        }

        /// <summary>
        /// Solicitamos el Id del coche que queremos borrar y lo eliminamos de la lista
        /// </summary>
        static void EliminarCoche()
        {
            Console.WriteLine("Introduzca el Id del coche");
            if (int.TryParse(Console.ReadLine(), out int idParseado))  // Si se introduce un número entero
            {
                var cocheABorrar = coches.FirstOrDefault(c => c.Id == idParseado);  // Primer coche que cumple el criterio de borrado
                if (cocheABorrar != null)
                {
                    coches.Remove(cocheABorrar); // Elimina el coche de la lista
                    Console.WriteLine("El coche ha sido eliminado correctamente.");
                }
                else
                    Console.WriteLine("No existe un coche con ese identificador.");

            }
            else
            {
                Console.WriteLine("Error: Identificador no válido, no se puede eliminar el coche.");
            }
        }

        /// <summary>
        /// Solicitamos el Id del coche que queremos actualizar y sus nuevos datos y modificamos el coche ya existente
        /// </summary>
        static void ActualizarCoche()
        {
            Console.WriteLine("Introduzca el Id del coche a actualizar");
            if (int.TryParse(Console.ReadLine(), out int idParseado))
            {
                var cocheAActualizar = coches.FindIndex(c => c.Id == idParseado);  // indice de la posición del coche dentro de la lista
                if (cocheAActualizar == -1)  // No se encuentra el coche
                {
                    Console.WriteLine("El Identificador introducido no pertenece a ningún coche");
                    return;
                }
                // Ha encontrado el coche
                Console.Write("Introduce la Marca: ");
                string marca = Console.ReadLine() ?? string.Empty;

                Console.Write("Introduce el Modelo: ");
                string modelo = Console.ReadLine() ?? string.Empty;

                Console.Write("Introduce la Matrícula: ");
                string matricula = Console.ReadLine() ?? string.Empty;
                coches[cocheAActualizar] = new Coche(idParseado, marca, modelo, matricula);

            }
            else
            {
                Console.WriteLine("Error: Formato de ID incorrecto. No se puede actualizar coche.");
            }
        }

        /// <summary>
        /// Solicitamos el Id del coche que queremos buscar y mostramos sus datos
        /// </summary>
        static void BuscarCoche()
        {
            Console.WriteLine("Introduzca el Id del coche");
            if (int.TryParse(Console.ReadLine(), out int idParseado))  // Si se introduce un número entero
            {
                var cocheBuscado = coches.FirstOrDefault(c => c.Id == idParseado);  // Primer coche que cumple el criterio de borrado
                if (cocheBuscado != null)
                    Console.WriteLine(cocheBuscado);
                else
                    Console.WriteLine("No existe un coche con ese identificador");

            }
            else
            {
                Console.WriteLine("Error: Identificador no válido, no se puede eliminar el coche.");
            }
        }

        static void Salir()
        {
            Console.WriteLine("Gracias por usar el programa. Esperamos volver a verle pronto.");
        }
        static void MostrarErrorOpcion()
        {
            Console.WriteLine("Ha seleccionado una opción incorrecta. Inténtelo de nuevo.");
        }

        static void Main(string[] args)
        {
            string opcion = "";

            do
            {
                ImprimirMenu();
                opcion = Console.ReadLine()!;
                Action accionAEjecutar = opcion switch
                {
                    "1" => AgregarCoche,
                    "2" => ListarCoches,
                    "3" => EliminarCoche,
                    "4" => ActualizarCoche,
                    "5" => BuscarCoche,
                    "0" => Salir,
                    _ => MostrarErrorOpcion
                };
                accionAEjecutar();

            } while (opcion != "0");

        }
    }
}
