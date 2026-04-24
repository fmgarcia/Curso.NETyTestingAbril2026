using System.Reflection.PortableExecutable;

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

static void EjemploFor()
{
    // Sintaxis: for (inicialización; condición; actualización)
    // Contar del 1 al 5 usando for
    for (int i = 1; i <= 5; i++)
    {
        Console.WriteLine($"Contador: {i}");
    }
    Console.WriteLine("¡Fin del bucle!");
}

static void OtrosEjemplosFor()
{
    // Contar hacia atrás
    for (int i = 10; i > 0; i--)
    {
        Console.Write($"{i}... ");
    }
    Console.WriteLine("¡DESPEGUE!");

    // De 2 en 2
    for (int i = 0; i <= 20; i += 2)
    {
        Console.Write($"{i} ");
    }
    // Salida: 0 2 4 6 8 10 12 14 16 18 20

    // Tabla de multiplicar
    int tabla = 7;
    Console.WriteLine($"\nTabla del {tabla}:");
    for (int i = 1; i <= 10; i++)
    {
        Console.WriteLine($"  {tabla} x {i} = {tabla * i}");
    }
}

static void ForRaros()
{
    for (int i = 1, j = 10; i <= 10 && j >= 5; i++, j--)
    {
        Console.WriteLine($"i: {i}, j: {j}");
    }
}

static void EjemplosForEach()
{
    // foreach con un array
    string[] frutas = { "Manzana", "Banana", "Cereza", "Dátil" };

    foreach (string fruta in frutas)
    {
        Console.WriteLine($"Fruta: {fruta}");
    }

    // foreach con un string (recorre carácter por carácter)
    string cadena = "Hola mundo";

    foreach (char letra in cadena)
    {
        Console.Write($"[{letra}] ");
    }
    // Salida: [H] [o] [l] [a] [ ] [m] [u] [n] [d] [o]
}

static void ForConPosicion()
{
    string cadena = "Hola mundo";
    for (int i = 0; i < cadena.Length; i++)
    {
        Console.WriteLine($"Posición {i}: {cadena[i]}");
    }
}

static void EjemplosBreakContinue()
{
    // Ejemplo de break
    for (int i = 1; i <= 10; i++)
    {
        if (i == 5)
        {
            Console.WriteLine("¡Número 5 encontrado, saliendo del bucle!");
            break; // Sale del bucle cuando i es 5
        }
        Console.WriteLine($"Número: {i}");
    }
    // Ejemplo de continue
    for (int i = 1; i <= 10; i++)
    {
        if (i % 2 == 0)
        {
            continue; // Salta el resto del código para números pares
        }
        Console.WriteLine($"Número impar: {i}");
    }
}

static void EvitarBreak()
{
    // En lugar de usar break, podemos usar una variable de control
    bool encontrado = false;
    for (int i = 1; i <= 10 && !encontrado; i++)
    {
        if (i == 5)
        {
            Console.WriteLine("¡Número 5 encontrado, saliendo del bucle!");
            encontrado = true; // Marcamos que lo encontramos
        }
        else
        {
            Console.WriteLine($"Número: {i}");
        }
    }
}

static void FlagWhile()
{
    bool continuar = true;
    while (continuar)
    {
        Console.WriteLine("¿Deseas continuar? (s/n)");
        string respuesta = Console.ReadLine()!.ToLower();
        if (respuesta == "n")
        {
            continuar = false; // Cambiamos la bandera para salir del bucle
            Console.WriteLine("¡Hasta luego!");
        }
        else if (respuesta == "s")
        {
            Console.WriteLine("¡Continuamos!");
        }
        else
        {
            Console.WriteLine("Respuesta no válida, por favor ingresa 's' o 'n'.");
        }
    }
}
static void NoFlagWhile()
{
    while (true) // Bucle infinito, se sale con break
    {
        Console.WriteLine("¿Deseas continuar? (s/n)");
        string respuesta = Console.ReadLine()!.ToLower();
        if (respuesta == "n")
        {
            Console.WriteLine("¡Hasta luego!");
            break; // Salimos del bucle usando break
        }
        else if (respuesta == "s")
        {
            Console.WriteLine("¡Continuamos!");
        }
        else
        {
            Console.WriteLine("Respuesta no válida, por favor ingresa 's' o 'n'.");
        }
    }
}

static void SeraInfinito()
{
    for (short i = 1; i > 0; i++)  // El tipo short tiene un rango de -32,768 a 32,767, por lo que al superar 32,767 se desbordará y volverá a -32,768 y saldrá del bucle.
    {
        Console.WriteLine($"Número: {i}");
    }
}

//EjemploWhile();
//WhileMenu();
//EjemploDoWhile();
//DoWhileMenu();
//EjemploFor();
//OtrosEjemplosFor();
//ForRaros();
//EjemplosForEach();
//ForConPosicion();
//EjemplosBreakContinue();
//EvitarBreak();
//FlagWhile();
//NoFlagWhile();
//SeraInfinito();