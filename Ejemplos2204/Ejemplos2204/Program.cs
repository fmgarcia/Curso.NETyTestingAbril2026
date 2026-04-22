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