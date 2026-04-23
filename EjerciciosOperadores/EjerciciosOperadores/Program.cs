//Introduce el primer número: 15
//Introduce el segundo número: 4

//  15 + 4 = 19
//  15 - 4 = 11
//  15 * 4 = 60
//  15 / 4 = 3.75
//  15 % 4 = 3

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


//Ejercicio1();
Ejercicio2();
//Ejercicio2b();