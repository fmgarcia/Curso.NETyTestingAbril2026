

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

static void RecorrerArrays()
{
    int[] numeros = { 10, -8, 25, 40, -22 };
    // Recorrer el array utilizando un bucle for
    for (int i = 0; i < numeros.Length; i++)
    {
        Console.WriteLine($"Número en el índice {i}: {numeros[i]}");
    }
    // Recorrer el array utilizando un bucle foreach
    foreach (int numero in numeros)
    {
        Console.WriteLine($"Número: {numero}");
    }

    // Recorrer el array utilizando un bucle foreach con índice
    int indice = 0;
    foreach (int numero in numeros)
    {
        numeros[indice] = numero * 2;
        Console.WriteLine($"Número en el índice {indice}: {numeros[indice]}");
        indice++;
    }
}

// Rangos y slices
static void RangosSlices()
{
    int[] numeros = { 10, -8, 25, 40, -22 };

    int[] parte1 = { numeros[1], numeros[2], numeros[3] }; // Crea un nuevo array con los primeros dos elementos del array original
    int[] parte1slicing = numeros[1..4]; // Crea un nuevo array con los elementos desde el índice 1 hasta el índice 3 (excluyendo el índice 4) utilizando la sintaxis de rango (desde la versión 8.0 de C#)
    int[] parte02 = numeros[..3]; // Crea un nuevo array con los primeros tres elementos del array original utilizando la sintaxis de rango (desde la versión 8.0 de C#)
    int[] parte2f = numeros[2..]; // Crea un nuevo array con los elementos desde el índice 2 hasta el final del array original utilizando la sintaxis de rango (desde la versión 8.0 de C#)
    int[] partetresultimos = numeros[^3..]; // Crea un nuevo array con los elementos desde el tercer elemento desde el final hasta el último elemento del array original utilizando la sintaxis de rango (desde la versión 8.0 de C#)

    // Mostrar los nuevos arrays
    Console.WriteLine("Parte 1:");


}


//Ejercicio 1: Media de notas
//Pide al usuario cuántas notas quiere introducir, lee las notas y calcula la media, la nota más alta y la más baja.
static void Ejercicio1()
{
    Console.Write("¿Cuántas notas quieres introducir? ");
    int cantidadNotas = int.Parse(Console.ReadLine()!);
    double[] notas = new double[cantidadNotas];
    for (int i = 0; i < cantidadNotas; i++)  // En este for se itera desde 0 hasta cantidadNotas - 1, lo que permite al usuario introducir la cantidad de notas especificada. En cada iteración, se solicita al usuario que introduzca una nota, que se almacena en el array notas en la posición correspondiente al índice i.
    {
        Console.Write($"Introduce la nota {i + 1}: ");
        notas[i] = double.Parse(Console.ReadLine()!);
    }
    // Calcular la media, la nota más alta y la más baja
    double suma = 0;
    double notaMaxima = notas[0];
    double notaMinima = notas[0];
    foreach (double nota in notas)  // En este foreach se recorre cada nota en el array notas para calcular la suma total de las notas, así como para determinar la nota más alta y la más baja. La variable suma se incrementa con cada nota, mientras que notaMaxima y notaMinima se actualizan si se encuentra una nota mayor o menor respectivamente.
    {
        suma += nota;
        if (nota > notaMaxima) notaMaxima = nota;
        if (nota < notaMinima) notaMinima = nota;
    }
    double media = suma / cantidadNotas;
    Console.WriteLine($"La media de las notas es: {media}");
    Console.WriteLine($"La nota más alta es: {notaMaxima}");
    Console.WriteLine($"La nota más baja es: {notaMinima}");
}

static void Ejercicio1b()
{
    Console.Write("¿Cuántas notas quieres introducir? ");
    int cantidadNotas = int.Parse(Console.ReadLine()!);
    double[] notas = new double[cantidadNotas];
    for (int i = 0; i < cantidadNotas; i++)  // En este for se itera desde 0 hasta cantidadNotas - 1, lo que permite al usuario introducir la cantidad de notas especificada. En cada iteración, se solicita al usuario que introduzca una nota, que se almacena en el array notas en la posición correspondiente al índice i.
    {
        Console.Write($"Introduce la nota {i + 1}: ");
        notas[i] = double.Parse(Console.ReadLine()!);
    }
    double notaMaxima = notas.Max();
    double notaMinima = notas.Min();
    double media = notas.Average();
    Console.WriteLine($"La media de las notas es: {media}");
    Console.WriteLine($"La nota más alta es: {notaMaxima}");
    Console.WriteLine($"La nota más baja es: {notaMinima}");
}


//DeclaracionArrays1();
//AccederModificar();
//RecorrerArrays();
Ejercicio1();
Ejercicio1b();

