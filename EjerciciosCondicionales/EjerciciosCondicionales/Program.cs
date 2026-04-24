//Pide un número al usuario y muestra si es par o impar.
static void Ejercicio1()
{
    Console.Write("Introduce un número: ");
    int numero = int.Parse(Console.ReadLine());

    if (numero % 2 == 0)
    {
        Console.WriteLine("El número es par.");
    }
    else
    {
        Console.WriteLine("El número es impar.");
    }
}

static void Ejercicio1Fran()
{
    Console.WriteLine("Introduce un número: ");
    Console.WriteLine($"{(int.Parse(Console.ReadLine()!) % 2 == 0 ? "El número es par." : "El número es impar.")}");
    //Console.WriteLine($"{(int.TryParse(Console.ReadLine()!, out int numero) && numero % 2 == 0 ? "El número es par." : "El número es impar.")}");
    //Console.WriteLine($"{int.TryParse(Console.ReadLine(), out int numero)}");
}

//Ejercicio 2: Máximo de tres números
//Pide tres números al usuario y muestra cuál es el mayor.
static void Ejercicio2() // versión con if-else if-else tradicional
{
    Console.WriteLine("Introduce tres números");
    if (int.TryParse(Console.ReadLine(), out int num1) &&
        int.TryParse(Console.ReadLine(), out int num2) &&
        int.TryParse(Console.ReadLine(), out int num3))
    {
        double mayor;
        if (num1 >= num2 && num1 >= num3)
        {
            mayor = num1;
        }
        else if (num2 >= num1 && num2 >= num3)
        {
            mayor = num2;
        }
        else
        {
            mayor = num3;
        }
        Console.WriteLine($"El número mayor es: {mayor}");
    }
    else
    {
        Console.WriteLine("Por favor, introduce números válidos.");
    }
}
static void Ejercicio2b() // Versión con operador ternario
{
    Console.WriteLine("Introduce tres números");
    if (int.TryParse(Console.ReadLine(), out int num1) &&
        int.TryParse(Console.ReadLine(), out int num2) &&
        int.TryParse(Console.ReadLine(), out int num3))
    {
        double mayor = (num1 >= num2 && num1 >= num3) ? num1 :
                       (num2 >= num1 && num2 >= num3) ? num2 : num3;
        Console.WriteLine($"El número mayor es: {mayor}");
    }
    else
    {
        Console.WriteLine("Por favor, introduce números válidos.");
    }
}
static void Ejercicio2c() // Versión con Math.Max
{
    Console.WriteLine("Introduce tres números");
    if (int.TryParse(Console.ReadLine(), out int num1) &&
        int.TryParse(Console.ReadLine(), out int num2) &&
        int.TryParse(Console.ReadLine(), out int num3))
    {
        double mayor = Math.Max(num1, Math.Max(num2, num3));
        Console.WriteLine($"El número mayor es: {mayor}");
    }
    else
    {
        Console.WriteLine("Por favor, introduce números válidos.");
    }
}

//Crea un programa que lea una letra tecleada por el usuario y diga si se trata de un
//signo de puntuación (. , ; :), una cifra numérica (del 0 al 9) u otro carácter, usando
//"switch" (pista: necesitarás usar un dato de tipo "char").
static void Ejercicio10Parte21()
{
    Console.WriteLine("Introduce una letra: ");
    char letra = Console.ReadKey().KeyChar;
    Console.WriteLine();
    string resultado = letra switch  // Expresión switch disponible a partir de C# 8.0, pero con mejoras en C# 14.0
    {
        '.' or ',' or ';' or ':' => "Es un signo de puntuación.",
        >= '0' and <= '9' => "Es una cifra numérica.",
        (>= 'A' and <= 'Z') or 'Ñ' => "Es una letra mayúscula.",
        (>= 'a' and <= 'z') or 'ñ' => "Es una letra minúscula.",
        _ => "Es otro carácter."
    };
    Console.WriteLine(resultado);
}



//Ejercicio1();
//Ejercicio1Fran();
//Ejercicio2();
//Ejercicio2b();
//Ejercicio2c();
Ejercicio10Parte21();