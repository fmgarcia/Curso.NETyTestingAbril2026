
//El programa “piensa” un número aleatorio entre 1 y 100. 
//El usuario tiene que adivinarlo. El programa dice “Más alto” o “Más bajo” tras cada intento
using System.Globalization;

static void EjercicioAdivinarNumero()
{
    Random random = new Random();  // Crear una instancia de la clase Random para generar números aleatorios

    int secreto = random.Next(1, 101);  // Generar un número aleatorio entre 1 y 100
    int intento = 0;  // Variable para almacenar el número de intentos del usuario
    int contadorIntentos = 0;  // Contador para el número de intentos realizados por el usuario

    Console.WriteLine("Adivina el número entre 1 y 100:");

    do
    {
        Console.Write("Introduce tu intento: ");
        intento = int.Parse(Console.ReadLine()!);  // Leer el intento del usuario y convertirlo a entero
        contadorIntentos++; // Incrementar el contador de intentos
        if (intento < secreto)
        {
            Console.WriteLine("El número es más alto. Intenta de nuevo.");
        }
        else if (intento > secreto)
        {
            Console.WriteLine("El número es más bajo. Intenta de nuevo.");
        }
        else
        {
            Console.WriteLine($"¡Has adivinado el número en {contadorIntentos} {(contadorIntentos > 1 ? "intentos" : "intento")}!");
        }
    } while (intento != secreto);

}

static void EjercicioAdivinarNumeroConMejoras()
{
    Random random = new Random();  // Crear una instancia de la clase Random para generar números aleatorios

    int secreto = random.Next(1, 101);  // Generar un número aleatorio entre 1 y 100
    int intento = 0;  // Variable para almacenar el número de intentos del usuario
    int contadorIntentos = 0;  // Contador para el número de intentos realizados por el usuario
    int intentoAnterior = 1000; // Variable para almacenar el intento anterior del usuario
    bool masAlto = false; // Variable para indicar si el número es más alto o más bajo

    Console.WriteLine("Adivina el número entre 1 y 100:");

    do
    {
        Console.Write("Introduce tu intento: ");
        intento = int.Parse(Console.ReadLine()!);  // Leer el intento del usuario y convertirlo a entero           
        contadorIntentos++; // Incrementar el contador de intentos

        if (masAlto && intento <= intentoAnterior)
        {
            Console.WriteLine("Te dije que el número es más alto y no me has hecho caso.");
        }
        else if (!masAlto && intento >= intentoAnterior)
        {
            Console.WriteLine("Te dije que el número es más bajo y no me has hecho caso.");
        }
        else
        {
            if (intento < secreto)
            {
                Console.WriteLine("El número es más alto. Intenta de nuevo.");
                masAlto = true;
            }
            else if (intento > secreto)
            {
                Console.WriteLine("El número es más bajo. Intenta de nuevo.");
                masAlto = false;
            }
            else
            {
                Console.WriteLine($"¡Has adivinado el número en {contadorIntentos} {(contadorIntentos > 1 ? "intentos" : "intento")}!");
            }
            intentoAnterior = intento; // Actualizar el intento anterior con el intento actual
        }

    } while (intento != secreto);

}

//Calcula el factorial de un número usando un bucle for:
// 5! = 5 × 4 × 3 × 2 × 1 = 120
static void FactorialFor()
{

    int acumulador = 1;

    for (int i = 2; i <= 5; i++)
    {
        acumulador *= i;
    }

    //for (int i = 5; i >= 2; i--)
    //{
    //    acumulador = acumulador * i;
    //}

    Console.WriteLine($"El factorial de 5 es: {acumulador}");
}

// Pide un número al usuario y determina si es primo (solo divisible por 1 y por sí mismo).
static void NumeroPrimo()
{
    bool esPrimo = true; // Variable para indicar si el número es primo o no, presupongo que es primo

    Console.WriteLine("Introduce un número: ");
    int numero = int.Parse(Console.ReadLine()!); // Leer el número del usuario y convertirlo a entero

    for (int i = 2; i < numero; i++) // Recorro los números desde el 2 hasta el número introducido por el usuario
    {
        if (numero % i == 0) // Si el número es divisible por alguno de esos números, entonces no es primo
        {
            esPrimo = false;
            break; // Salir del bucle si se encuentra un divisor
        }
    }

    if (esPrimo)
    {
        Console.WriteLine("El número es primo.");
    }
    else
    {
        Console.WriteLine("El número no es primo.");
    }
}
static void NumeroPrimoMejorado()
{
    bool esPrimo = true; // Variable para indicar si el número es primo o no, presupongo que es primo

    Console.WriteLine("Introduce un número: ");
    int numero = int.Parse(Console.ReadLine()!); // Leer el número del usuario y convertirlo a entero

    for (int i = 2; i <= (numero / 2); i++) // Recorro los números desde el 2 hasta el número introducido por el usuario
    {
        if (numero % i == 0) // Si el número es divisible por alguno de esos números, entonces no es primo
        {
            esPrimo = false;
            break; // Salir del bucle si se encuentra un divisor
        }
    }
    Console.WriteLine($"El número {(esPrimo ? "es" : "no es")} primo.");
}

//Crea esta pirámide pidiendo el número de filas:

//    1
//   1 2
//  1 2 3
// 1 2 3 4
//1 2 3 4 5
static void PiramideNumeros()
{
    Console.WriteLine("Introduce un número: ");
    int numero = int.Parse(Console.ReadLine()!); // Leer el número del usuario y convertirlo a entero

    for (int i = 1; i <= numero; i++) // Recorro las filas de la pirámide
    {
        for (int j = 1; j <= numero - i; j++)  //  Imprimo los espacios en blanco antes de los números
        {
            Console.Write(" ");
        }
        for (int k = 1; k <= i; k++) // Imprimo los números de cada fila
        {
            Console.Write(k + " ");
        }
        Console.WriteLine(); // Salto de línea después de cada fila
    }
}

//Imprime los números del 1 al 100, pero:

//Si es múltiplo de 3, imprime “Fizz”
//Si es múltiplo de 5, imprime “Buzz”
//Si es múltiplo de ambos, imprime “FizzBuzz”
static void FizzBuzz()
{
    for (int i = 1; i <= 100; i++)
    {
        if (i % 3 == 0 && i % 5 == 0)
        {
            Console.WriteLine("FizzBuzz");
        }
        else if (i % 3 == 0)
        {
            Console.WriteLine("Fizz");
        }
        else if (i % 5 == 0)
        {
            Console.WriteLine("Buzz");
        }
        else
        {
            Console.WriteLine(i);
        }
    }
}

static void FizzBuzzMejorado()
{
    for (int i = 1; i <= 100; i++)
    {
        string resultado = (i % 3 == 0, i % 5 == 0) switch // disponible a partir de C# 14.0, permite evaluar múltiples condiciones en una sola expresión switch
        {
            (true, true) => "FizzBuzz",
            (true, false) => "Fizz",
            (false, true) => "Buzz",
            _ => i.ToString()
        };
        Console.WriteLine(resultado);
    }
}


//EjercicioAdivinarNumero();
//EjercicioAdivinarNumeroConMejoras();
//FactorialFor();
//NumeroPrimo();
//NumeroPrimoMejorado();
//PiramideNumeros();
//FizzBuzz();
FizzBuzzMejorado();

