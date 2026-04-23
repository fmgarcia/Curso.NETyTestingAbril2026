static void EjemploIf()
{
    int edad = 15;
    if (edad < 18)
    {
        Console.WriteLine("Eres menor de edad.");
    }
    Console.WriteLine("Fin del programa");
}

static void EjemploIfElse()
{
    int edad = 20;
    if (edad < 18)
    {
        Console.WriteLine("Eres menor de edad.");
    }
    else
    {
        Console.WriteLine("Eres mayor de edad.");
    }
    Console.WriteLine("Fin del programa");
}

static void EjemploIfElseIfElse()
{
    Console.Write("Introduce tu nota (0-10): ");
    double nota = double.Parse(Console.ReadLine()!);

    if (nota < 0 || nota > 10)
    {
        Console.WriteLine("Nota inválida. Debe estar entre 0 y 10.");
        nota = 4.0; // Asignamos una nota por defecto para continuar con el programa. Esto no provoca que entre en el bloque de SUSPENSO, ya que el programa seguirá evaluando la nota asignada.
    }
    else if (nota < 5)
    {
        Console.WriteLine("SUSPENSO");
    }
    else if (nota < 6)
    {
        Console.WriteLine("APROBADO");
    }
    else if (nota < 7)
    {
        Console.WriteLine("BIEN");
    }
    else if (nota < 9)
    {
        Console.WriteLine("NOTABLE");
    }
    else
    {
        Console.WriteLine("SOBRESALIENTE");
    }
    Console.WriteLine("Fin del programa");
}

static void EjemploSwitchClasico()
{
    Console.Write("Introduce un número del 1 al 7 para conocer el día de la semana: ");
    int dia = int.Parse(Console.ReadLine()!);
    switch (dia)
    {
        case 1:
            Console.WriteLine("Lunes");
            break;
        case 2:
            Console.WriteLine("Martes");
            break;
        case 3:
            Console.WriteLine("Miércoles");
            break;
        case 4:
            Console.WriteLine("Jueves");
            break;
        case 5:
            Console.WriteLine("Viernes");
            break;
        case 6:
            Console.WriteLine("Sábado");
            break;
        case 7:
            Console.WriteLine("Domingo");
            break;
        default:
            Console.WriteLine("Número inválido. Debe estar entre 1 y 7.");
            break;
    }
    Console.WriteLine("Fin del programa");
}

static void EjemploSwitchExpresion() // Disponible a partir de C# 8.0
{
    Console.Write("Introduce un número del 1 al 7 para conocer el día de la semana: ");
    int dia = int.Parse(Console.ReadLine()!);
    string nombreDia = dia switch
    {
        1 => "Lunes",
        2 => "Martes",
        3 => "Miércoles",
        4 => "Jueves",
        5 => "Viernes",
        6 => "Sábado",
        7 => "Domingo",
        _ => "Número inválido. Debe estar entre 1 y 7."
    };
    Console.WriteLine(nombreDia);
    Console.WriteLine("Fin del programa");
}

static void EjemploSwitchTypePattern() // Disponible a partir de C# 14.0, permite usar patrones de tipo en switch expressions
{
    Console.Write("Introduce un número del 1 al 7 para conocer si es un día laborable: ");
    int dia = int.Parse(Console.ReadLine()!);
    string resultado = dia switch
    {
        >= 1 and <= 5 => "Es un día laborable.",
        6 or 7 => "No es un día laborable.",
        _ => "Número inválido. Debe estar entre 1 y 7."
    };
    Console.WriteLine(resultado);
    Console.WriteLine("Fin del programa");
}

static void EjemploSwitchTypePatternWithWhen()  // Disponible a partir de C# 14.0, permite usar patrones de tipo en switch expressions con condiciones adicionales usando 'when'
{
    int nota = 85;
    string clasificacion = nota switch
    {
        < 10 => "Es pequeño",
        // El patrón 'when' permite agregar condiciones adicionales a los patrones de tipo
        int n when n >= 100 => "Es muy grande",
        _ => "número normal"
    };
}

static void EjemploSwitchConObject()  // Disponible a partir de C# 14.0, permite usar patrones de tipo en switch expressions con objetos
{
    object valor = 3; // Puede ser cualquier tipo de dato
    string resultado = valor switch
    {
        int n when n >= 1 && n <= 5 => "Es un número entre 1 y 5.",
        int n when n == 6 || n == 7 => "Es un número entre 6 y 7.",
        string s => $"Es una cadena: {s}",
        _ => "Valor no reconocido."
    };
    Console.WriteLine(resultado);
}

static void EjemploSwitchMultiple() // Disponible a partir de C# 14.0, permite usar patrones de tupla en switch expressions
{
    int x = 1, y = 0;
    string posicion = (x, y) switch
    {
        (0, 0) => "Origen",
        (0, _) => "Eje Y",
        (_, 0) => "Eje X",
        _ => "Cuadrante"
    };
    Console.WriteLine(posicion);
}

static void EjemploReadKey()
{
    Console.WriteLine("Presiona una tecla para continuar...");
    char tecla = Console.ReadKey().KeyChar;
    Console.WriteLine($"\nHas presionado la tecla: {tecla}");
}

static void EjemploReadKey2()
{
    Console.WriteLine("Presiona una tecla para continuar...");
    ConsoleKeyInfo tecla = Console.ReadKey();
    Console.WriteLine($"\nHas presionado la tecla: {tecla.KeyChar}");
}

//EjemploIf();
//EjemploIfElse();
//EjemploIfElseIfElse();
//EjemploSwitchClasico();
//EjemploSwitchExpresion();
//EjemploSwitchTypePattern();
//EjemploSwitchTypePatternWithWhen();
//EjemploSwitchConObject();
//EjemploSwitchMultiple();
//EjemploReadKey();
//EjemploReadKey2();