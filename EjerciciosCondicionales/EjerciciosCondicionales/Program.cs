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

//Ejercicio1();
Ejercicio1Fran();