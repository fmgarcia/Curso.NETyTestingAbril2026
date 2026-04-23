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

//EjemploIf();
//EjemploIfElse();
//EjemploIfElseIfElse();
EjemploSwitchClasico();