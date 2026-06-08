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

        }

        /// <summary>
        /// Recorremos la lista de coches y mostramos su ToString
        /// </summary>
        static void ListarCoches()
        {

        }

        /// <summary>
        /// Solicitamos el Id del coche que queremos borrar y lo eliminamos de la lista
        /// </summary>
        static void EliminarCoche()
        {

        }

        /// <summary>
        /// Solicitamos el Id del coche que queremos actualizar y sus nuevos datos y modificamos el coche ya existente
        /// </summary>
        static void ActualizarCoche()
        {

        }

        /// <summary>
        /// Solicitamos el Id del coche que queremos buscar y mostramos sus datos
        /// </summary>
        static void BuscarCoche()
        {

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
