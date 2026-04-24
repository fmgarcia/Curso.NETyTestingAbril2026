static void EjemploWhile()
{
    // Contar del 1 al 5
    int contador = 1;

    while (contador <= 5)
    {
        Console.WriteLine($"Contador: {contador}");
        contador++;
    }
    Console.WriteLine("¡Fin del bucle!");
}

static void WhileMenu()
{
    string opcion = "";

    while (opcion != "0")
    {
        Console.WriteLine("\n═══ MENÚ ═══");
        Console.WriteLine("1. Saludar");
        Console.WriteLine("2. Mostrar fecha");
        Console.WriteLine("3. Mostrar hora");
        Console.WriteLine("0. Salir");
        Console.Write("Elige una opción: ");
        opcion = Console.ReadLine()!;

        switch (opcion)
        {
            case "1":
                Console.WriteLine("¡Hola, bienvenido!");
                break;
            case "2":
                Console.WriteLine($"Hoy es: {DateTime.Now:dd/MM/yyyy}");
                break;
            case "3":
                Console.WriteLine($"Son las: {DateTime.Now:HH:mm:ss}");
                break;
            case "0":
                Console.WriteLine("¡Hasta luego!");
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }
}

static void EjemploDoWhile()
{
    // Contar del 1 al 5 usando do-while
    int contador = 1;
    do
    {
        Console.WriteLine($"Contador: {contador}");
        contador++;
    } while (contador <= 5);
    Console.WriteLine("¡Fin del bucle!");
}

static void DoWhileMenu()
{
    string opcion = "";
    do
    {
        Console.WriteLine("\n═══ MENÚ ═══");
        Console.WriteLine("1. Saludar");
        Console.WriteLine("2. Mostrar fecha");
        Console.WriteLine("3. Mostrar hora");
        Console.WriteLine("0. Salir");
        Console.Write("Elige una opción: ");
        opcion = Console.ReadLine()!;

        switch (opcion)
        {
            case "1":
                Console.WriteLine("¡Hola, bienvenido!");
                break;
            case "2":
                Console.WriteLine($"Hoy es: {DateTime.Now:dd/MM/yyyy}");
                break;
            case "3":
                Console.WriteLine($"Son las: {DateTime.Now:HH:mm:ss}");
                break;
            case "0":
                Console.WriteLine("¡Hasta luego!");
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    } while (opcion != "0");
}

//EjemploWhile();
//WhileMenu();
//EjemploDoWhile();
DoWhileMenu();
