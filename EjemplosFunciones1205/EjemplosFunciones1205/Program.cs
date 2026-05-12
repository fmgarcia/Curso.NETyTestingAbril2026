static void FuncionTipoVoid()
{
    Console.WriteLine("Esta función no devuelve ningún valor.");
}

static int FuncionTipoInt()
{
    return 42;
}

static int FuncionTipoIntConParametros(int a, int b)
{
    return a + b;
}

static void ParametrosPorValor(int x)
{
    x += 10;
    Console.WriteLine($"Valor dentro de la función (por valor): {x}");
}

static void ParametrosPorReferencia(ref int x)
{
    x += 10;

}

static bool DividirSeguro(int a, int b, out double resultado)
{
    if (b == 0)
    {
        resultado = 0;  // out exige asignar un valor siempre
        return false;
    }

    resultado = (double)a / b;
    return true;
}

static int Sumar(params int[] numeros)
{
    int total = 0;
    foreach (int n in numeros)
    {
        total += n;
    }
    return total;
}

static void Saludar(string nombre, string saludo = "Hola")
{
    Console.WriteLine($"{saludo}, {nombre}!");
}

static void SaludarConVariosParametrosOpcionales(string nombre, string saludo = "Hola", string despedida = "Adiós")
{
    Console.WriteLine($"{saludo}, {nombre}! {despedida}!");
}

static void CrearUsuario(string nombre, int edad, string ciudad = "Madrid")
{
    Console.WriteLine($"{nombre}, {edad} años, {ciudad}");
}

// Sobrecarga de métodos
static double CalcularArea(double radio)
{
    return Math.PI * radio * radio;  // Área del círculo
}

//static double CalcularArea(double ancho, double alto)
//{
//    return ancho * alto;  // Área del rectángulo
//}

//static double CalcularArea(double baseTriang, double altura, bool esTriangulo)
//{
//    return baseTriang * altura / 2;  // Área del triángulo
//}

// Scope de las funciones. Ámbito de las variables dentro de las funciones
static void FuncionA(int a, int b)
{
    int x = 10;  // x solo existe dentro de FuncionA
    a = 15;  // a solo existe dentro de FuncionA
    Console.WriteLine(x);
    for (int i = 0; i < 3; i++)
    {
        //int x = 100;  // ERROR: ya existe una variable x en este ámbito (FuncionA)
        int y = i * 2;  // y solo existe dentro del bloque del for
        Console.WriteLine(y);
    }
    // Console.WriteLine(i);  // ERROR: i no existe aquí
    // Console.WriteLine(y);  // ERROR: y no existe aquí

    //int x = 30;  // ERROR: ya existe una variable x en este ámbito

    for (int i = 0; i < 2; i++)
    {
        int x2 = 100;  // Esto es válido porque es un nuevo ámbito dentro del for
        Console.WriteLine(x2);
    }
}

static void FuncionB()
{
    //Console.WriteLine(x);  // ERROR: x no existe aquí
    int x = 20;  // Esta es OTRA variable x, diferente
    Console.WriteLine(x);
}

// Recursividad: una función que se llama a sí misma
static long Factorial(int n)
{
    // Caso base: condición de parada
    if (n <= 1)
    {
        return 1;
    }

    // Caso recursivo: la función se llama a sí misma
    return n * Factorial(n - 1);
}

static long FactorialIncorrecto(long n)
{
    // Caso base: condición de parada
    if (n <= 1)
    {
        return 1;
    }

    // Caso recursivo: la función se llama a sí misma
    return n * FactorialIncorrecto(n + 1);
}

static long FactorialIterativo(int n)
{
    long resultado = 1;
    for (int i = 2; i <= n; i++)
    {
        resultado *= i;
    }
    return resultado;
}

// Devolución de tuplas
static (double min, double max, double media) Estadisticas(int[] numeros)
{
    double min = numeros.Min();
    double max = numeros.Max();
    double media = numeros.Average();

    return (min, max, media);
}

// Funciones dentro de funciones (local functions)
static bool EsNumeroPrimo(int n)
{
    if (n < 2) return false;

    // Función local: solo existe dentro de EsNumeroPrimo. No es accesible desde fuera.
    bool TieneDivisor(int limite)
    {
        for (int i = 2; i <= limite; i++)
        {
            if (n % i == 0) return true;
        }
        return false;
    }

    return !TieneDivisor((int)Math.Sqrt(n));
}

// expression-bodied members (funciones de una sola línea)
static int SumarClasica(int a, int b)
{
    return a + b;
}
static int SumarExpressionBodied(int a, int b) => a + b;
static double AreaCirculo(double r) => Math.PI * r * r;
static bool EsPar(int n) => n % 2 == 0;
static string Saludar1Linea(string nombre) => $"Hola, {nombre}!";
static void Despedir() => Console.WriteLine("¡Adiós!");


// Principio de responsabilidad única: cada función debe hacer una sola cosa. Esto hace que el código sea más fácil de entender, mantener y reutilizar.
static void MultiplicarYMostrar(int a, int b)
{
    int resultado = a * b;
    Console.WriteLine($"El resultado de multiplicar {a} y {b} es: {resultado}");
}

static int Multiplicar(int a, int b)
{
    return a * b;
}

static bool MostrarResultado(int resultado)
{
    Console.WriteLine($"El resultado es: {resultado}");
    return true;
}


FuncionTipoVoid();
int resultado = FuncionTipoInt();
Console.WriteLine($"El resultado de la función es: {resultado}");
int resultadoConParametros = FuncionTipoIntConParametros(5, 7);
Console.WriteLine($"El resultado de la función con parámetros es: {resultadoConParametros}");
int valor = 20;
ParametrosPorValor(valor); // Muestra el valor dentro de la función, pero no afecta el valor original
ParametrosPorReferencia(ref valor); // Muestra el valor dentro de la función y afecta el valor original
Console.WriteLine(valor); // Muestra el valor original después de la función por referencia, que ha sido modificado
// Uso
if (DividirSeguro(10, 3, out double res))
{
    Console.WriteLine($"Resultado: {res:F2}");  // 3.33
}
else
{
    Console.WriteLine("No se puede dividir entre cero");
}

// Puedes pasar cualquier cantidad de argumentos
Console.WriteLine(Sumar(1, 2));            // 3
Console.WriteLine(Sumar(1, 2, 3, 4, 5));  // 15
Console.WriteLine(Sumar());                // 0

// También puedes pasar un array directamente
int[] nums = { 10, 20, 30 };
Console.WriteLine(Sumar(nums));  // 60

Saludar("Ana");                 // Hola, Ana!
Saludar("Ana", "Buenos días");  // Buenos días, Ana!

SaludarConVariosParametrosOpcionales("Carlos"); // Hola, Carlos! Adiós!
SaludarConVariosParametrosOpcionales("Carlos", "Buenas tardes"); // Buenas tardes, Carlos! Adiós!
SaludarConVariosParametrosOpcionales("Carlos", "Buenas tardes", "Hasta luego"); // Buenas tardes, Carlos! Hasta luego!

// Argumentos por posición (normal)
CrearUsuario("Ana", 25, "Barcelona");

// Argumentos con nombre (puedes cambiar el orden)
CrearUsuario(edad: 30, nombre: "Luis", ciudad: "Sevilla");

// Saltar opcionales con argumentos con nombre
CrearUsuario("María", 22);  // ciudad = "Madrid" (valor por defecto)

CrearUsuario("Fran", 49, "Alicante");

// C# elige automáticamente cuál usar según los argumentos
Console.WriteLine($"Círculo: {CalcularArea(5.0):F2}");           // 78.54
//Console.WriteLine($"Rectángulo: {CalcularArea(4.0, 6.0):F2}");  // 24.00
//Console.WriteLine($"Triángulo: {CalcularArea(3.0, 8.0, true):F2}");  // 12.00

int a = 5, b = 10;
FuncionA(a, b);

Console.WriteLine(Factorial(10));  // 3628800
//Console.WriteLine(FactorialIncorrecto(10));  // Esto causará un desbordamiento de pila (StackOverflow)

int[] datos = { 4, 8, 15, 16, 23, 42 };
var stats = Estadisticas(datos);

Console.WriteLine(stats);  // (4, 42, 18). Probablemente no será muy legible, por eso es mejor usar los nombres de los campos
Console.WriteLine($"Mínimo: {stats.min}");    // 4
Console.WriteLine($"Máximo: {stats.max}");     // 42
Console.WriteLine($"Media: {stats.media:F2}"); // 18.00

if (EsNumeroPrimo(17))
{
    Console.WriteLine("17 es un número primo");
}
else
{
    Console.WriteLine("17 no es un número primo");
}

int resultadoMultiplicacion = Multiplicar(6, 7);
MostrarResultado(resultadoMultiplicacion);
