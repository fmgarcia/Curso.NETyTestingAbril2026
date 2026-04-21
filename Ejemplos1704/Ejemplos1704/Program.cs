
string nombreCandidato = "Desarrollador Junior";
string teconologiaPrincipal = ".NET 11";
int anyosExperiencia = 0;
long numeroLargo = 1_000_000_000_000L;  // Esto es un billón europeo, o un trillion en inglés
float valorDecimalFloat = 3.14f;  // El sufijo 'f' indica que es un float
double valorDecimalDouble = 3.14;  // Por defecto, los números decimales son de tipo double
double pi = 3.141592653589793;
double radio = 5.5;
// decimal: alta precisión para dinero (necesita la "m" al final)
decimal precio = 29.99m;
decimal salario = 2500.50m;
decimal iva = 0.21m;



Console.WriteLine($"Hola {nombreCandidato}! ¡Bienvenido al mundo de {teconologiaPrincipal}!");
Console.WriteLine($"Tu experiencia actual es de {anyosExperiencia} años, ¡pero no te preocupes! Todos empezamos en algún lugar. Lo importante es tu entusiasmo por aprender y crecer en el campo de {teconologiaPrincipal}.");
Console.WriteLine("Tengo un número largo: " + numeroLargo + " que es un número largo.");


double circunferencia = 2 * pi * radio;
Console.WriteLine($"La circunferencia de un círculo con radio {radio} es: {circunferencia}");
Console.WriteLine($"El precio del producto es: {precio} euros, con un IVA de {iva * 100}% el precio total sería: {(precio * (1 + iva)):F2} euros.");

double suma = 0.1 + 0.2;
Console.WriteLine($"La suma de 0.1 + 0.2 es: {suma}"); // Esto puede no ser exactamente 0.3 debido a la representación de números decimales en binario

decimal sumaDecimal = 0.1m + 0.2m;
Console.WriteLine($"La suma de 0.1 + 0.2 es: {sumaDecimal}"); // Esto puede no ser exactamente 0.3 debido a la representación de números decimales en binario

// Tipos de datos booleanos
bool esCandidatoValido = true;
bool tieneExperiencia = false;

Console.WriteLine($"¿El candidato es válido? {esCandidatoValido}");
Console.WriteLine($"¿El candidato tiene experiencia? {tieneExperiencia}");

// Las variables booleanas también pueden ser el resultado de una comparación
int edad = 17;
bool puedeVotar = edad >= 18;  // 17 >= 18 es false, por lo que puedeVotar será false 
Console.WriteLine($"¿El candidato puede votar? {puedeVotar}");

// Tipos de datos de tipo carácter (char)
char letraInicial = 'A';
char numero = '7';          // Es el carácter '7', no el número 7
char simbolo = '@';
char emoji = '♥';
char letraEspanola = 'ñ';

Console.WriteLine($"La letra inicial del candidato es: {letraInicial} y su valor ASCII es: {(int)letraInicial}");
Console.WriteLine($"El número como carácter es: {numero}");
Console.WriteLine($"El símbolo es: {simbolo}");
Console.WriteLine($"El emoji es: {emoji}");
Console.WriteLine($"La letra española es: {letraEspanola}");
Console.WriteLine("" + numero + numero); // Esto concatenará los caracteres '7' + '7' dando como resultado "77"
Console.WriteLine(numero + numero); // Esto concatenará los caracteres '7' + '7' dando como resultado "77"


// Tipos de datos de tipo cadena (string)
string saludo = "¡Hola, mundo!";
saludo = "Hola Fran";
string menu = """
    ╔══════════════════════════╗
    ║    MENÚ PRINCIPAL        ║
    ╠══════════════════════════╣
    ║  1. Nuevo juego          ║
    ║  2. Cargar partida       ║
    ║  3. Opciones             ║
    ║  4. Salir                ║
    ╚══════════════════════════╝
    """;
string textoLargo = "Este es un texto largo que se extiende a lo largo de varias líneas para demostrar el uso de cadenas literales de texto en C# 14.0. " +
    "Puedes escribir todo lo que quieras aquí, y el formato se mantendrá tal como lo has escrito, incluyendo saltos de línea y espacios.";
string textoMultilinea = """
    Manténgase al día.
    Programe con más eficacia usando características integradas y descargadas.
    Colabore sin problemas sin salir del editor.
    """;
Console.WriteLine(menu);
Console.WriteLine(textoLargo);
Console.WriteLine(textoMultilinea);
string cadenaMultilinea = "Linea1\nLinea2\n\tLinea3";
Console.WriteLine(cadenaMultilinea);

// Constantes. Son variables cuyo valor no puede cambiar después de ser asignado. Se declaran con la palabra clave "const".
const double PI = 3.141592653589793;
const int DIAS_EN_UNA_SEMANA = 7;
const string MONEDA = "Euro";
const int MAYORIA_EDAD = 18;

//MAYORIA_EDAD = 21; // Esto generará un error de compilación porque las constantes no pueden ser modificadas después de su declaración
Console.WriteLine($"Cinco semanas tienen {5 * DIAS_EN_UNA_SEMANA} días.");