namespace Ejercicios2104;

public static class Program
{

    public static void Main(string[] args)
    {
        //Ejercicio1();  // Llamamos a la función para ejecutar el ejercicio1
        //Ejercicio2();
        //Ejercicio3();
        Ejercicio4();
    }

    static void Ejercicio1()
    {
        Console.WriteLine("Introduce tu nombre: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Introduce tu edad: ");
        int edad = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Introduce tu altura (m): ");
        double altura = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Introduce tu ciudad: ");
        string ciudad = Console.ReadLine();

        string cadenaImprimir = $"""
                ══════════════════════════════
                  FICHA PERSONAL
                ══════════════════════════════
                  Nombre:  {nombre}
                  Edad:    {edad} años
                  Altura:  {altura} m
                  Ciudad:  {ciudad}
                ══════════════════════════════
                """;
        Console.WriteLine(cadenaImprimir);

    }

    static void Ejercicio2()
    {
        Console.WriteLine("Importe de la comida:");
        decimal importeComida = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Porcentaje de propina (%):");
        int porcentajePropina = Convert.ToInt32(Console.ReadLine());
        decimal propina = importeComida * porcentajePropina / 100;

        Console.WriteLine("Importe: " + importeComida);
        Console.WriteLine($"Propina ({porcentajePropina}%): {propina}");
        Console.WriteLine("TOTAL: " + (importeComida + propina));
    }

    static void Ejercicio3()
    {
        Console.WriteLine("Introduce los grados: ");
        double grados = double.Parse(Console.ReadLine());
        double fahrenheit = (grados * (9.0 / 5.0)) + 32;
        Console.WriteLine($"El resultado de la conversión Celsius a Farenheit es {fahrenheit} ºF ");
        double celsius = (fahrenheit - 32) * (5.0 / 9.0);
        Console.WriteLine($"El resultado de la conversión Farenheit a Celsius es {celsius} ºC ");
    }

    static void Ejercicio4()
    {
        int a = 5;
        int b = 10;

        (a, b) = (b, a);  // ¡Intercambio con tuplas en una línea!
        Console.WriteLine($"a = {a}, b = {b}");
    }

    static void Ejercicio5()
    {
        Console.WriteLine("Introduce tu nombre: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Introduce tu edad: ");
        int edad = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Introduce tu altura (m): ");
        double altura = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Introduce tu ciudad: ");
        string ciudad = Console.ReadLine();

        string cadenaImprimir = $"""
                ══════════════════════════════
                  FICHA PERSONAL
                ══════════════════════════════
                  Nombre:  {nombre}
                  Edad:    {edad} años
                  Altura:  {altura} m
                  Ciudad:  {ciudad}
                ══════════════════════════════
                """;
        Console.WriteLine(cadenaImprimir);

    }

}
