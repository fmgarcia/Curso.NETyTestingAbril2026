namespace Enumeraciones1205
{

    enum EstadoPedido
    {
        Pendiente,    // 0
        Procesando,   // 1
        Enviado,      // 2
        Entregado,    // 3
        Cancelado     // 4
    }

    enum DiaSemana
    {
        Lunes,      // 0
        Martes,     // 1
        Miércoles,  // 2
        Jueves,     // 3
        Viernes,    // 4
        Sábado,     // 5
        Domingo     // 6
    }

    enum Prioridad
    {
        Baja = 1,
        Media = 5,
        Alta = 10,
        Urgente = 100
    }

    enum Semaforo { Rojo, Amarillo, Verde }

    enum Color { Rojo, Verde, Azul }

    enum Estacion { Primavera, Verano, Otoño, Invierno }

    [Flags]  // Disponible a partir de C# 7.3, indica que los valores pueden combinarse con operadores bit a bit
    enum Permisos
    {
        Ninguno = 0,      // 0000
        Leer = 1,         // 0001
        Escribir = 2,     // 0010
        Ejecutar = 4,     // 0100
        Eliminar = 8,     // 1000
                          // Combinación predefinida
        Todos = Leer | Escribir | Ejecutar | Eliminar  // 1111 = 15
    }

    enum ClasePersonaje { Guerrero, Mago, Arquero, Sanador, Pícaro }
    enum Raza { Humano, Elfo, Enano, Orco }


    internal class Program
    {

        static void MostrarPersonaje(string nombre, ClasePersonaje clase, Raza raza)
        {
            Console.WriteLine($"╔══════════════════════════╗");
            Console.WriteLine($"  Nombre: {nombre}");
            Console.WriteLine($"  Clase:  {clase}");
            Console.WriteLine($"  Raza:   {raza}");
            Console.WriteLine($"  Stats base:");

            var (ataque, defensa, magia) = clase switch
            {
                ClasePersonaje.Guerrero => (15, 12, 3),
                ClasePersonaje.Mago => (5, 6, 18),
                ClasePersonaje.Arquero => (12, 8, 5),
                ClasePersonaje.Sanador => (4, 7, 16),
                ClasePersonaje.Pícaro => (10, 6, 8),
                _ => (8, 8, 8)
            };

            int bonoAtaque = raza == Raza.Orco ? 3 : 0;
            int bonoMagia = raza == Raza.Elfo ? 3 : 0;
            int bonoDefensa = raza == Raza.Enano ? 3 : 0;

            Console.WriteLine($"    Ataque:  {ataque + bonoAtaque}");
            Console.WriteLine($"    Defensa: {defensa + bonoDefensa}");
            Console.WriteLine($"    Magia:   {magia + bonoMagia}");
            Console.WriteLine($"╚══════════════════════════╝");
        }

        static void MetodosEnumeraciones()
        {
            // Obtener todos los valores
            Estacion[] valores = Enum.GetValues<Estacion>();
            foreach (Estacion e in valores)
            {
                Console.WriteLine($"{e} = {(int)e}");
            }
            // Primavera = 0
            // Verano = 1
            // Otoño = 2
            // Invierno = 3

            // Obtener todos los nombres como string
            string[] nombres = Enum.GetNames<Estacion>();
            Console.WriteLine(string.Join(", ", nombres));
            // Primavera, Verano, Otoño, Invierno

            // Comprobar si un valor existe
            Console.WriteLine(Enum.IsDefined<Estacion>((Estacion)2));  // True (Otoño)
            Console.WriteLine(Enum.IsDefined<Estacion>((Estacion)99)); // False
        }

        static void GestionPermisos()
        {
            // Combinar permisos con |
            Permisos usuario = Permisos.Leer | Permisos.Escribir;
            Console.WriteLine(usuario);  // "Leer, Escribir"

            // Comprobar si tiene un permiso con HasFlag
            if (usuario.HasFlag(Permisos.Leer))
            {
                Console.WriteLine("Puede leer");
            }

            if (!usuario.HasFlag(Permisos.Ejecutar))
            {
                Console.WriteLine("No puede ejecutar");
            }

            // Añadir un permiso
            usuario |= Permisos.Ejecutar;  // Ahora tiene Leer, Escribir, Ejecutar

            // Quitar un permiso
            usuario &= ~Permisos.Escribir;  // Ahora tiene Leer, Ejecutar
            Console.WriteLine(usuario);     // "Leer, Ejecutar"
        }


        static void Main(string[] args)
        {
            EstadoPedido estado = EstadoPedido.Enviado;

            if (estado == EstadoPedido.Enviado)
            {
                Console.WriteLine("Tu pedido está en camino");
            }

            DiaSemana hoy = DiaSemana.Miércoles;
            Console.WriteLine(hoy);         // Miércoles
            Console.WriteLine((int)hoy);   // 2

            Prioridad p = Prioridad.Alta;
            Console.WriteLine(p);           // Alta
            Console.WriteLine((int)p);     // 10

            // Switch expression (moderno)
            Semaforo luz = Semaforo.Verde;
            string accion = luz switch
            {
                Semaforo.Rojo => "Parar",
                Semaforo.Amarillo => "Precaución",
                Semaforo.Verde => "Avanzar",
                _ => "Desconocido"
            };

            // Conversiones de enumeraciones
            // enum → int
            Color c = Color.Verde;
            int numero = (int)c;          // 1

            // int → enum
            Color c2 = (Color)2;         // Color.Azul
            Console.WriteLine(c2);        // Azul

            // enum → string
            Color c3 = Color.Rojo;
            string nombre = c3.ToString();  // "Rojo"

            // string → enum
            Color c4 = Enum.Parse<Color>("Verde");
            Console.WriteLine(c4);  // Verde

            // string → enum (seguro, sin excepción)
            if (Enum.TryParse<Color>("Azul", out Color resultado))
            {
                Console.WriteLine($"Convertido: {resultado}");
            }
            else
            {
                Console.WriteLine("Valor no válido");
            }

            // Ignorar mayúsculas/minúsculas
            Enum.TryParse<Color>("rojo", ignoreCase: true, out Color r);  // Funciona


            MostrarPersonaje("Aragorn", ClasePersonaje.Guerrero, Raza.Humano);
            MostrarPersonaje("Legolas", ClasePersonaje.Arquero, Raza.Elfo);
            MostrarPersonaje("Gimli", ClasePersonaje.Guerrero, Raza.Enano);
            MostrarPersonaje("Gandalf", ClasePersonaje.Mago, Raza.Humano);
            MostrarPersonaje("Frodo", ClasePersonaje.Pícaro, Raza.Humano);

        }



    }

}