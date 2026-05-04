using System.ComponentModel;

static void DeclaracionArrays1()
{
    int[] numeros = new int[5]; // Declaración de un array de enteros con capacidad para 5 elementos (inicialmente todos los elementos son 0)
    // Asignación de valores a los elementos del array
    numeros[0] = 10;
    numeros[1] = -8;
    numeros[2] = 25;
    numeros[3] = 40;
    numeros[4] = -22;
    // Acceso al tercer elemento del array (índice 2)
    Console.WriteLine($"El tercer elemento es: {numeros[2]}");

    // Recorrer el array utilizando un bucle for
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Elemento en el índice {i}: {numeros[i]}");
    }
}

static void DeclaracionArrays2()
{
    // Declaración e inicialización de un array de enteros con valores específicos utilizando diferentes formas de sintaxis.
    int[] numeros = new int[] { 10, -8, 25, 40, -22 }; // Declaración e inicialización de un array de enteros con valores específicos. Forma larga.
    int[] numeros2 = { 10, -8, 25, 40, -22 }; // Declaración e inicialización de un array de enteros con valores específicos. Forma corta (inferencia de tipo).
    var numeros3 = new[] { 10, -8, 25, 40, -22 }; // Declaración e inicialización de un array de enteros con valores específicos. Forma con var (inferencia de tipo).

    // Otros tipos de arrays
    string[] nombres = { "Alice", "Bob", "Charlie" }; // Declaración e inicialización de un array de cadenas de texto.
    double[] precios = { 19.99, 5.49, 3.75 }; // Declaración e inicialización de un array de números decimales.
    bool[] respuestas = { true, false, true }; // Declaración e inicialización de un array de valores booleanos.

}

static void AccederModificar()
{
    string[] nombres = { "Alice", "Bob", "Charlie" };
    // Acceso a elementos del array
    Console.WriteLine($"El primer nombre es: {nombres[0]}");
    // Modificación de un elemento del array
    nombres[0] = "Fran"; // Cambia el primer elemento del array a "Fran"
    Console.WriteLine($"El primer nombre es: {nombres[0]}"); // Ahora el primer nombre es "Fran"
    Console.WriteLine($"El array tiene {nombres.Length} elementos."); // Imprime la cantidad de elementos en el array utilizando la propiedad Length que es 3
    Console.WriteLine($"El último nombre es: {nombres[nombres.Length - 1]}"); // Accede al último elemento del array
    Console.WriteLine($"El último nombre es: {nombres[^1]}"); // Accede al último elemento del array. Desde la versión 8.0 de C#, se puede usar la sintaxis de índice desde el final del array utilizando el operador ^. ^1 representa el último elemento, ^2 el penúltimo, y así sucesivamente.
    Console.WriteLine($"El penúltimo nombre es: {nombres[^2]}"); // Accede al penúltimo elemento del array
}


//DeclaracionArrays1();
//AccederModificar();
