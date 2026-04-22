// Operadores

// Operadores aritméticos

int a = 10;
int b = 3;
int c = 0;

c = a + b; // Suma
Console.WriteLine("La suma de a y b es: " + c);
c = a - b; // Resta
Console.WriteLine($"La resta de a y b es: {c}");
c = a * b; // Multiplicación
Console.WriteLine($"La multiplicación de a y b es: {c}");
c = a / b; // División (ten cuidado con la división entre cero y con la división de enteros que trunca el resultado)
Console.WriteLine($"La división de a y b es: {c}");
c = a % b; // Módulo (resto de la división)
Console.WriteLine($"El módulo de a y b es: {c}");

// Para obtener una división real, al menos uno de los operandos debe ser de tipo flotante (float, double, decimal)
var divisionReal = (double)a / b; // División real
Console.WriteLine($"La división real de a y b es: {divisionReal}");
var division1 = 10 / 4; // División de enteros, resultado es 2
Console.WriteLine($"La división de 10 entre 4 es: {division1}");
var division2 = 10.0 / 4; // División real, resultado es 2.5
Console.WriteLine($"La división de 10.0 entre 4 es: {division2}");

// Usos comunes del módulo (pares e impares, múltiplos, etc.)
int numero = 5;
int resto = numero % 2; // Si el resto es 0, el número es par; si es 1, es impar
Console.WriteLine($"El número {numero} es {(resto == 0 ? "par" : "impar")}");
numero = 10;
int multiplo = 3;
Console.WriteLine($"El número {numero} es {(numero % multiplo == 0 ? "múltiplo de " + multiplo : "no es múltiplo de " + multiplo)}");

// Operadores de incremento y decremento
int contador = 0;
contador++; // Incremento en 1 (contator = contador + 1). Post-incremento
Console.WriteLine($"El valor del contador después del incremento es: {contador}");
contador--; // Decremento en 1 (contador = contador - 1). Post-decremento
Console.WriteLine($"El valor del contador después del decremento es: {contador}");
// Ahora mismo contador vale 0
Console.WriteLine(contador++); // Imprime 0, luego incrementa a 1 (post-incremento)
Console.WriteLine(contador); // Imprime 1
Console.WriteLine(++contador); // Imprime 2 (pre-incremento)
Console.WriteLine(contador--); // Imprime 2, luego decrementa a 1 (post-decremento)
Console.WriteLine(--contador); // Imprime 0 (pre-decremento)

// Operadores de asignación simple y asignación compuesta
int x = 5;  // Asignación simple. x ahora vale 5.
x += 3; // Equivale a x = x + 3. x ahora vale 8. Ejemplo de asignación compuesta con suma. 
x -= 2; // Equivale a x = x - 2. x ahora vale 6. Ejemplo de asignación compuesta con resta.
x *= 4; // Equivale a x = x * 4. x ahora vale 24. Ejemplo de asignación compuesta con multiplicación.
x /= 2; // Equivale a x = x / 2. x ahora vale 12. Ejemplo de asignación compuesta con división.
x %= 5; // Equivale a x = x % 5. x ahora vale 2. Ejemplo de asignación compuesta con módulo.

// Operadores de comparación (relacionales)
int edad = 25;
int edadMinima = 18;
Console.WriteLine($"edad es igual a 20? {edad == 20}"); // El operador == compara si dos valores son iguales. En este caso, edad es 25, por lo que la comparación con 20 es falsa.
Console.WriteLine($"edad es distinta a 20? {edad != 20}"); // El operador != compara si dos valores son distintos. En este caso, edad es 25, por lo que la comparación con 20 es verdadera.
Console.WriteLine($"edad es mayor o igual a la edad mínima? {edad >= edadMinima}"); // El operador >= compara si un valor es mayor o igual a otro. En este caso, edad es 25 y edadMinima es 18, por lo que la comparación es verdadera.
Console.WriteLine($"edad es menor o igual a la edad mínima? {edad <= edadMinima}"); // El operador <= compara si un valor es menor o igual a otro. En este caso, edad es 25 y edadMinima es 18, por lo que la comparación es falsa.
Console.WriteLine($"edad es mayor que la edad mínima? {edad > edadMinima}"); // El operador > compara si un valor es mayor que otro. En este caso, edad es 25 y edadMinima es 18, por lo que la comparación es verdadera.
Console.WriteLine($"edad es menor que la edad mínima? {edad < edadMinima}"); // El operador < compara si un valor es menor que otro. En este caso, edad es 25 y edadMinima es 18, por lo que la comparación es falsa.
string nombre = "Francisco";
Console.WriteLine($"El nombre es Fran? {nombre == "Fran"}"); // El operador == compara si dos valores son iguales. En este caso, nombre es "Fran", por lo que la comparación es verdadera.

// Operadores lógicos (AND, OR, NOT) (&&, ||, !)
Console.WriteLine($"La edad es 25 y se llama Fran? {edad == 25 && nombre == "Fran"}"); // El operador && (AND lógico) devuelve true solo si ambas condiciones son verdaderas. En este caso, edad es 25, pero el nombre es "Francisco", por lo que la comparación es falsa.
Console.WriteLine($"La edad es 25 o se llama Fran? {edad == 25 || nombre == "Fran"}"); // El operador || (OR lógico) devuelve true si al menos una de las condiciones es verdadera. En este caso, edad es 25, por lo que la comparación es verdadera.
Console.WriteLine($"No se llama Fran? {!(nombre == "Fran")}"); // El operador ! (NOT lógico) invierte el valor de la condición. En este caso, nombre es "Francisco", por lo que la comparación es verdadera.

// Operador ternario (condicional)
// sintaxis: condicion ? valor_si_verdadero : valor_si_falso

edad = 20;
string mensaje = edad >= 18 ? "Eres mayor de edad" : "Eres menor de edad"; // El operador ternario evalúa la condición edad >= 18. Si es verdadera, asigna "Eres mayor de edad" a mensaje; si es falsa, asigna "Eres menor de edad".
Console.WriteLine(mensaje); // Imprime el mensaje correspondiente según la edad.

//if (edad >= 18)
//    mensaje = "Eres mayor de edad";
//else
//    mensaje = "Eres menor de edad";
int dinero = 1;
Console.WriteLine($"Tengo {dinero} euro{(dinero == 1 ? "" : "s")}");
Console.WriteLine($"Tengo {dinero} {(dinero == 1 ? "euro" : "euros")}");

// Operadores nulos

string? nombrePersona = null; // El operador ? después del tipo indica que la variable puede ser nula (nullable).
string saludo = nombrePersona ?? "Desconocido"; // El operador ?? (null-coalescing) devuelve el valor de textoNulo si no es nulo; de lo contrario, devuelve "Desconocido".
Console.WriteLine($"Hola {saludo}");

int? numeroAlumnos = null;
int numeroAlumnosFinal = numeroAlumnos ?? 30; // Si numeroAlumnos es nulo, se asigna el valor 30 a numeroAlumnosFinal.
Console.WriteLine($"Número de alumnos: {numeroAlumnosFinal}");

string? nombreCompleto = null;
nombreCompleto ??= "Sin nombre"; // El operador ??= (null-coalescing assignment) asigna "Sin nombre" a nombreCompleto solo si nombreCompleto es nulo.
Console.WriteLine($"Nombre completo: {nombreCompleto}");

string cadena1 = null;
//int longitudCadena1 = cadena1.Length; // Esto lanzará una excepción NullReferenceException porque cadena1 es nula.
int longitudCadena1 = cadena1?.Length ?? 0;  // (cadena1==null) ? 0 : cadena1.Length. El operador ?. (null-conditional) devuelve null si cadena1 es nulo; de lo contrario, devuelve la longitud de la cadena. Luego, el operador ?? asigna 0 si el resultado es null.
Console.WriteLine($"Hola la variable cadena tiene {longitudCadena1} caracteres.");

// Precedencia de operadores
int resultado = 10 + 5 * 2; // La multiplicación tiene mayor precedencia que la suma, por lo que se evalúa primero 5 * 2, dando 10, y luego se suma 10 + 10, resultando en 20.
Console.WriteLine($"El resultado de la operación es: {resultado}"); // Si quieres cambiar el orden de evaluación, puedes usar paréntesis

// operador is y pattern matching básico
object valor = 10;
valor = 20;
valor = "hola";
if (valor is int numeroValor) // El operador is verifica si valor es de tipo int. Si es así, asigna el valor a la variable numeroValor.
{
    Console.WriteLine($"El valor es un número entero: {numeroValor + 5}");
}
else
{
    Console.WriteLine("El valor no es un número entero.");
}

// Ejemplo de pattern matching con switch
edad = 19;
string categoria = edad switch
{
    < 13 => "Niño",
    >= 13 and < 20 => "Adolescente",
    >= 20 and < 65 => "Adulto",
    _ => "Persona mayor"
};
Console.WriteLine(categoria);

//string categoria2 = null;
//switch (edad)
//{
//    case < 13:
//        categoria2 = "Niño";
//        break;
//    case >= 13 and < 20:
//        categoria2 = "Adolescente";
//        break;
//    case >= 20 and < 65:
//        categoria2 = "Adulto";
//        break;
//    default:
//        categoria2 = "Persona mayor";
//        break;
//}

//string categoria3 = edad < 13 ? "Niño" :
//                    edad >= 13 && edad < 20 ? "Adolescente" :
//                    edad >= 20 && edad < 65 ? "Adulto" : "Persona mayor";

//string categoria4 = null;
//if (edad < 13)
//    categoria4 = "Niño";
//else if (edad >= 13 && edad < 20)
//    categoria4 = "Adolescente";
//else if (edad >= 20 && edad < 65)
//    categoria4 = "Adulto";
//else
//    categoria4 = "Persona mayor";