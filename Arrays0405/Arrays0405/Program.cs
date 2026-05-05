using System.Linq;

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
    Console.WriteLine($"Números: {string.Join(", ", numeros)}");
    Console.WriteLine($"Parte 1: {string.Join(", ", parte1)}");
    Console.WriteLine($"Números (slicing): {string.Join(", ", parte1slicing)}");
    Console.WriteLine($"Números (parte02): {string.Join(", ", parte02)}");
    Console.WriteLine($"Números (parte2f): {string.Join(", ", parte2f)}");
    Console.WriteLine($"Números (partetresultimos): {string.Join(", ", partetresultimos)}");

}

static void EjemplosClaseArray()
{
    int[] numeros = { 10, -8, 25, 40, -22 };
    // Ordenar el array utilizando el método Sort de la clase Array
    Array.Sort(numeros); // Ordena el array quedando [-22, -8, 10, 25, 40]. Ordena de menor a mayor.
    Console.WriteLine($"Ordenado: {string.Join(", ", numeros)}");
    // Invertir el array utilizando el método Reverse de la clase Array
    Array.Reverse(numeros); // Invierte el orden del array quedando [40, 25, 10, -8, -22]
    Console.WriteLine($"Invertido: {string.Join(", ", numeros)}");
    // Buscar un elemento en el array utilizando el método IndexOf de la clase Array
    int indice = Array.IndexOf(numeros, 25); // Busca el índice del número 25 en el array. Si el número no se encuentra, devuelve -1.
    Console.WriteLine(indice != -1 ? $"Número encontrado en la posición {indice}" : "Número no encontrado");
    // Verificar si un elemento existe en el array utilizando el método Exists de la clase Array
    bool existe = Array.Exists(numeros, elemento => elemento == 25);
    Console.WriteLine(existe ? "Número encontrado" : "Número no encontrado");
    // Verificar si un elemento existe en el array utilizando el método Contains de la clase Array
    Console.WriteLine(numeros.Contains(25) ? "Número encontrado" : "Número no encontrado");
    // Encontrar un elemento que cumpla una condición utilizando el método Find de la clase Array
    int[] numeros2 = { 10, -8, 25, 40, -22 };
    int numeroEncontrado = Array.Find(numeros2, elemento => elemento > 20); // Busca el primer número en el array que sea mayor que 20. Si no se encuentra ningún número que cumpla la condición, devuelve el valor predeterminado del tipo (en este caso, 0).
    Console.WriteLine($"El número encontrado que cumple la condición es: {numeroEncontrado}");  // 25 es el primer número en el array que es mayor que 20, por lo que se imprime ese número. Si no hubiera ningún número mayor que 20, se imprimiría 0.
    string[] nombres = { "Alice", "Bob", "Charlie" };
    string nombreMas5letras = Array.Find(nombres, nombre => nombre.Length > 5)!; // Busca el primer nombre en el array que tenga más de 5 letras. Si no se encuentra ningún nombre que cumpla la condición, devuelve null.
    Console.WriteLine(nombreMas5letras != null ? $"Nombre encontrado: {nombreMas5letras}" : "Nombre no encontrado");
    string primerNombreComienzaA = Array.Find(nombres, nombre => nombre.StartsWith("A"))!; // Busca el primer nombre en el array que comience con la letra "A". Si no se encuentra ningún nombre que cumpla la condición, devuelve null.
    Console.WriteLine(primerNombreComienzaA != null ? $"Nombre encontrado: {primerNombreComienzaA}" : "Nombre no encontrado");
    string primerNombreContengaA = Array.Find(nombres, nombre => nombre.Contains("a"))!; // Busca el primer nombre en el array que contenga la letra "a". Si no se encuentra ningún nombre que cumpla la condición, devuelve null.
    Console.WriteLine(primerNombreContengaA != null ? $"Nombre encontrado: {primerNombreContengaA}" : "Nombre no encontrado");
    // Encontrar todos los elementos que cumplan una condición utilizando el método FindAll de la clase Array
    int[] numeros3 = { 10, -8, 25, 40, -22 };
    int[] numerosMayores20 = Array.FindAll(numeros3, elemento => elemento > 20); // Busca todos los números en el array que sean mayores que 20.
    Console.WriteLine($"Números mayores que 20: {string.Join(", ", numerosMayores20)}");
    // Rellenar un array con un valor específico utilizando el método Fill de la clase Array
    int[] ceros = new int[5];
    Array.Fill(ceros, 100); // Rellena el array con 100 en cada posición. El array ceros quedará con los valores [100, 100, 100, 100, 100].
    Console.WriteLine($"Array rellenado con ceros: {string.Join(", ", ceros)}");
    // Copiar un array utilizando el método Copy de la clase Array
    int[] numerosOriginal = { 10, -8, 25, 40, -22 };
    int[] numerosCopia = new int[numerosOriginal.Length];
    Array.Copy(numerosOriginal, numerosCopia, numerosOriginal.Length); // Copia todos los elementos del array numerosOriginal al array numerosCopia.
    Console.WriteLine($"Array copiado: {string.Join(", ", numerosCopia)}");
    // Copiar un rango de un array utilizando el método CopyTo de la clase Array
    int[] numeros4 = { 10, -8, 25, 40, -22 };
    int[] rango = new int[3];
    Array.Copy(numeros4, 1, rango, 0, 3); // Copia un rango de elementos del array numeros4 al array rango.
    Console.WriteLine($"Rango copiado: {string.Join(", ", rango)}");
    // Limpiar un array utilizando el método Clear de la clase Array
    int[] numeros5 = { 10, -8, 25, 40, -22 };
    Array.Clear(numeros5); // Limpia todos los elementos del array numeros5, estableciéndolos en el valor predeterminado (0 para int).
    Console.WriteLine($"Array limpiado: {string.Join(", ", numeros5)}");
}

static void EncontrarElementoArrayEstructura()
{
    int[] numeros = { 10, -8, 25, 40, -22 };
    int numeroBuscado = 25;
    bool encontrado = false;
    for (int i = 0; i < numeros.Length; i++)
    {
        if (numeros[i] == numeroBuscado)
        {
            encontrado = true;
            break; // Sale del bucle una vez que se encuentra el número
        }
    }
    if (encontrado)
    {
        Console.WriteLine("Número encontrado.");
    }
    else
    {
        Console.WriteLine("Número no encontrado.");
    }

}


static void ArraysMultidimensionales()
{
    int[,] matriz = new int[3, 3]; // Declaración de un array bidimensional (matriz) de enteros con 3 filas y 3 columnas
    // Asignación de valores a la matriz
    matriz[0, 0] = 1;
    matriz[0, 1] = 2;
    matriz[0, 2] = 3;
    matriz[1, 0] = 4;
    matriz[1, 1] = 5;
    matriz[1, 2] = 6;
    matriz[2, 0] = 7;
    matriz[2, 1] = 8;
    matriz[2, 2] = 9;

    int[,] matriz2 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }; // Declaración e inicialización de un array bidimensional (matriz) de enteros con valores específicos utilizando la sintaxis de inicialización de arrays.
    // Recorrer la matriz utilizando bucles anidados
    int filas = matriz.GetLength(0); // Obtiene el número de filas de la matriz
    int columnas = matriz.GetLength(1); // Obtiene el número de columnas de la matriz
    for (int i = 0; i < filas; i++) // GetLength(0) devuelve el número de filas
    {
        for (int j = 0; j < columnas; j++) // GetLength(1) devuelve el número de columnas
        {
            Console.Write($"{matriz[i, j]} ");
        }
        Console.WriteLine(); // Salto de línea después de cada fila
    }

}

// Quiero almacenar los datos de las notas de varios estudiantes en un array multidimensional,
// donde cada fila representa a un estudiante y cada columna representa una nota.
// Luego, quiero calcular la media de cada estudiante y la media general de todas las notas.

static void CalculoNotas()
{
    string[] estudiantes = { "Alice", "Alice", "Charlie" };
    //string[,] notas = new string[estudiantes.Length, asignaturas.Length]; // Declaración de un array bidimensional para almacenar las notas de los estudiantes en diferentes asignaturas
    double[][] notasAlumnos = {
        new double[] { 8.5, 7, 9, 6 },
        new double[] { 1, 1, 7, 9.2 },
        new double[] { 9, 6.5, 1, 2 }
    }; // Declaración e inicialización de un array bidimensional para almacenar las notas de los estudiantes en diferentes asignaturas utilizando la sintaxis de inicialización de arrays.

    for (int i = 0; i < estudiantes.Length; i++)
        Console.WriteLine($"{estudiantes[i]} tiene de media {notasAlumnos[i].Average():F2}");
    Console.WriteLine($"La media general de todas las notas es: {notasAlumnos.SelectMany(notas => notas).Average():F2}"); // Calcula la media general de todas las notas utilizando LINQ. SelectMany se utiliza para aplanar el array bidimensional en una secuencia de notas individuales, y luego se calcula la media de esa secuencia utilizando Average().
}

static void CalculoNotas2()
{
    // 3 alumnos, 4 asignaturas
    double[,] notas = {
        { 7.5, 8.0, 6.5, 9.0 },   // Alumno 0
        { 5.0, 6.5, 7.0, 8.5 },   // Alumno 1
        { 9.0, 9.5, 8.0, 10.0 }   // Alumno 2
    };
    string[] alumnos = { "Ana", "Luis", "María" };
    string[] asignaturas = { "Mates", "Lengua", "Inglés", "Ciencias" };

    double sumaTotal = 0;

    for (int i = 0; i < alumnos.Length; i++)
    {
        double suma = 0;
        for (int j = 0; j < asignaturas.Length; j++)
        {
            suma += notas[i, j];
            sumaTotal += notas[i, j];
        }
        double media = suma / asignaturas.Length;
        Console.WriteLine($"{alumnos[i],-8} | Media: {media:F2}");
    }
    double mediaGeneral = sumaTotal / (alumnos.Length * asignaturas.Length);
    Console.WriteLine($"La media general de todas las notas es: {mediaGeneral:F2}");
}

static void EjemploArraysDentados()
{
    // Cada fila puede tener distinto número de elementos
    int[][] jagged = new int[3][];
    jagged[0] = new int[] { 1, 2 };
    jagged[1] = new int[] { 3, 4, 5, 6 };
    jagged[2] = new int[] { 7 };

    // Forma directa
    int[][] jagged2 = {
    new[] { 1, 2 },
    new[] { 3, 4, 5, 6 },
    new[] { 7 }
    };

    // Recorrer
    for (int i = 0; i < jagged2.Length; i++)
    {
        Console.Write($"Fila {i}: ");
        for (int j = 0; j < jagged2[i].Length; j++)
        {
            Console.Write($"{jagged2[i][j]} ");
        }
        Console.WriteLine();
    }
}





//DeclaracionArrays1();
//AccederModificar();
//RecorrerArrays();
//RangosSlices();
//Ejercicio1();
//Ejercicio1b();
//EjemplosClaseArray();
//ArraysMultidimensionales();
CalculoNotas();

