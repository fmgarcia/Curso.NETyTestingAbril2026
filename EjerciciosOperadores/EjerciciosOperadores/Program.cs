//Introduce el primer número: 15
//Introduce el segundo número: 4

//  15 + 4 = 19
//  15 - 4 = 11
//  15 * 4 = 60
//  15 / 4 = 3.75
//  15 % 4 = 3

using System.IO.Pipelines;

static void Ejercicio1()
{
    Console.WriteLine("Introduce el primer número:");
    int num1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Introduce el segundo número:");
    int num2 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
    Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
    Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
    Console.WriteLine($"{num1} / {num2} = {(double)num1 / num2}");
    Console.WriteLine($"{num1} % {num2} = {num1 % num2}");
}

//Crea un programa que pida el radio de un círculo y calcule:

//Área = π × r²
//Perímetro = 2 × π × r
//Usa Math.PI y Math.Pow().

static void Ejercicio2()
{
    Console.WriteLine("Introduce el radio del círculo (5 por defecto): ");
    double radio = (double.TryParse(Console.ReadLine(), out double numero)) ? numero : 5;
    double perimetro = 2 * Math.PI * radio;
    double area = Math.PI * Math.Pow(radio, 2);
    Console.WriteLine($"El perímetro del círculo es: {perimetro:F2}");
    Console.WriteLine($"El área del círculo es: {area:F2}");
}
static void Ejercicio2b()
{
    const double PI = 3.14159; // Definimos una constante para el valor de π

    Console.WriteLine("Introduce el radio del círculo: ");
    double radio = Convert.ToDouble(Console.ReadLine());
    double perimetro = 2 * PI * radio;
    double area = PI * radio * radio;
    Console.WriteLine($"El perímetro del círculo es: {perimetro:F2}");
    Console.WriteLine($"El área del círculo es: {area:F2}");
}

// Usando el operador ternario, crea un programa que pida la edad y muestre si la persona es “menor de edad” o “mayor de edad”.
static void Ejercicio3()
{
    Console.WriteLine("Introduzca su edad en valor numérico: ");
    int edad = (int.TryParse(Console.ReadLine(), out int numero)) ? numero : -1000; // Si la conversión falla, asignamos un valor fuera del rango válido para indicar que no se ha introducido un número válido
    Console.WriteLine($"{(edad is -1000 or < 0 or > 100 ? "No ha introducido un número válido"
                                 : edad < 18 ? "menor de edad"
                                 : "mayor de edad")}");
}

static void Ejercicio3b()
{
    Console.WriteLine("Introduzca su edad: ");
    Console.WriteLine($"Usted es {(int.Parse(Console.ReadLine()) < 18 ? "menor de edad" : "mayor de edad")}");
}
static void Ejercicio3c()
{
    Console.WriteLine("Introduzca su edad: ");
    int edad = int.Parse(Console.ReadLine());
    Console.WriteLine($"Usted es {(edad is < 0 or > 100 ? "edad no válida"
                                 : edad < 18 ? "menor de edad"
                                 : "mayor de edad")}");
}


//Pide una nota numérica (0-10) y muestra la calificación usando una expresión switch:

//0 - 4.99: Suspenso
//5-5.99: Aprobado
//6-6.99: Bien
//7-8.99: Notable
//9-10: Sobresaliente
static void Ejercicio4()
{
    Console.WriteLine("introduzca la nota ");
    double? nota = (double.TryParse(Console.ReadLine(), out double numero)) ? numero : null;
    string resultado = nota switch
    {
        >= 0 and < 5 => "Suspenso",
        >= 5 and < 6 => "Aprobado",
        >= 6 and < 7 => "Bien",
        >= 7 and < 9 => "Notable",
        >= 9 and <= 10 => "Sobresaliente",
        _ => "Incorrecta o fuera de rango"
    };
    Console.WriteLine($"NOTA: {resultado}");
}

static void Ejercicio4b()
{
    Console.WriteLine("introduzca la nota ");
    double nota = Convert.ToDouble(Console.ReadLine());
    string resultado = nota switch
    {
        >= 0 and < 5 => "Suspenso",
        >= 5 and < 6 => "Aprobado",
        >= 6 and < 7 => "Bien",
        >= 7 and < 9 => "Notable",
        >= 9 and <= 10 => "Sobresaliente",
        _ => "Nota fuera de rango"
    };
    Console.WriteLine($"NOTA:{resultado}");
}

//Ejercicio1();
//Ejercicio2();
//Ejercicio2b();
//Ejercicio3();
//Ejercicio3b();
//Ejercicio3c();
Ejercicio4();
//Ejercicio4b();