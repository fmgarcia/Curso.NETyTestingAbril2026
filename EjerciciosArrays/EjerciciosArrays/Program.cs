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

static void Ejercicio2()
{
    string[] nombres = { "Nombre 1", "Nombre 2", "Nombre 3", "Nombre 4", "Nombre 5", "Nombre 6", "Nombre 7", "Nombre 8", "Nombre 9", "Nombre 10" };
    string nombreBuscar = "";

    //for (int i = 0; i < nombres.Length; i++) { nombres[i] = $"Nombre {i + 1}"; }
    Console.WriteLine("introduzca el nombre a buscar");
    nombreBuscar = Console.ReadLine()!;
    for (int i = 0; i < nombres.Length; i++)
    {
        if (nombres[i] == nombreBuscar)
        {
            Console.WriteLine($"El nombre {nombreBuscar} se encuentra en la posición {i + 1}");
            return;
        }
    }
    Console.WriteLine($"El nombre {nombreBuscar} no se encuentra en la lista");
}

static void Ejercicio2b()
{
    string[] nombres = { "Nombre 1", "Nombre 2", "Nombre 3", "Nombre 4", "Nombre 5", "Nombre 6", "Nombre 7", "Nombre 8", "Nombre 9", "Nombre 10" };
    string nombreBuscar = "Nombre 5";

    int posicion = Array.IndexOf(nombres, nombreBuscar);
    Console.WriteLine($"{(posicion != -1 ? $"El nombre {nombreBuscar} se encuentra en la posición {posicion + 1}" : $"El nombre {nombreBuscar} no se encuentra en la lista")}");

}

static void Ejercicio3()
{
    int[] primer = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    int[] segundo = new int[primer.Length];

    for (int i = 0; i < primer.Length; i++)  // Crea la copia del array primer en el array segundo, pero en orden inverso. El índice ^(i + 1) se utiliza para acceder a los elementos de primer desde el final hacia el principio, lo que permite llenar segundo con los mismos valores pero en orden inverso.
    {
        segundo[i] = primer[^(i + 1)];
    }

    for (int i = 0; i < segundo.Length; i++) // Muestra el array segundo, que contiene los mismos valores que primer pero en orden inverso. El bucle recorre cada elemento de segundo y lo imprime en la consola.
    {
        Console.WriteLine($"hola {segundo[i]}");
    }
}

static void Ejercicio4()
{
    int[] numeros = { 1, 2, 3, 2, 4, 3, 5, 1, 6 };
    int[] sinDuplicados = numeros.Distinct().ToArray();

    Console.WriteLine("Array sin duplicados: " + string.Join(", ", sinDuplicados));

}

static void Ejercicio4b()
{
    int[] numeros = { 1, 2, 3, 2, 4, 3, 5, 1, 6 };
    int[] sinDuplicados = new int[numeros.Length];  // [1, 2, 3, 0, 4, 0, 5, 0, 6]

    for (int i = 0; i < numeros.Length; i++)
    {
        if (Array.IndexOf(sinDuplicados, numeros[i]) == -1)
        {
            sinDuplicados[i] = numeros[i];
        }
    }
    Console.WriteLine("Array sin duplicados: " + string.Join(", ", sinDuplicados));
}

static void Ejercicio4c()
{
    int[] numeros = { 1, 2, 3, 2, 4, 3, 5, 1, 6 };
    int[] sinDuplicados = new int[numeros.Length];  // [0,0,0,0,0,0,0,0,0]
    int indice = 0; // me indica en que posición del array sinDuplicados voy a insertar el siguiente número que no se ha repetido

    for (int i = 0; i < numeros.Length; i++)
    {
        if (Array.IndexOf(sinDuplicados, numeros[i]) == -1)
        {
            sinDuplicados[indice] = numeros[i];
            indice++;
        }
    }
    Array.Resize(ref sinDuplicados, indice);
    Console.WriteLine("Array sin duplicados: " + string.Join(", ", sinDuplicados));
}

static void Ejercicio5()
{

    Console.OutputEncoding = System.Text.Encoding.UTF8;  // Configura la codificación de salida de la consola para permitir la visualización de caracteres especiales, como emojis. Esto es útil para mostrar el emoji de corazón en el resultado final.

    char[,] tablero = new char[8, 8];  // variable para almacenar el estado del tablero de ajedrez, donde cada posición puede contener un carácter que representa una pieza o un espacio vacío.
    char[] piezasNegras = { '♜', '♞', '♝', '♛', '♚', '♝', '♞', '♜' };  // Array que representa las piezas negras en su posición inicial en el tablero de ajedrez. Cada carácter corresponde a una pieza específica, como torre, caballo, alfil, reina y rey.
    char[] piezasBlancas = { '♖', '♘', '♗', '♕', '♔', '♗', '♘', '♖' }; // Array que representa las piezas blancas en su posición inicial en el tablero de ajedrez. Similar al array de piezasNegras, cada carácter corresponde a una pieza específica.

    // Pintaré el tablero de ajedrez colocando las piezas en sus posiciones iniciales. Las filas 0 y 1 se llenarán con las piezas negras, mientras que las filas 6 y 7 se llenarán con las piezas blancas. Las filas intermedias (2 a 5) se llenarán con '.' para representar el área del tablero sin piezas.
    for (int columna = 0; columna < 8; columna++)
    {
        tablero[0, columna] = piezasNegras[columna];  // Coloca las piezas negras en la primera fila del tablero.
        tablero[1, columna] = '♟';  // Coloca los peones negros en la segunda fila del tablero.
        tablero[6, columna] = '♙';  // Coloca los peones blancos en la séptima fila del tablero.
        tablero[7, columna] = piezasBlancas[columna];  // Coloca las piezas blancas en la octava fila del tablero.
        for (int fila = 2; fila <= 5; fila++)
        {
            tablero[fila, columna] = '.';  // Rellena las filas intermedias con '.' para representar el área del tablero sin piezas.
        }
    }

    // Pintar el tablero por consola
    Console.WriteLine("---SIMULADOR DE AJEDREZ---");
    Console.WriteLine("  A B C D E F G H");
    for (int fila = 0; fila < 8; fila++)
    {
        Console.Write($"{8 - fila} "); // Pinta números del 8 al 1
        for (int columna = 0; columna < 8; columna++)
        {
            Console.Write($"{tablero[fila, columna]} ");
        }
        Console.WriteLine();
    }

}


static void Tamagochi()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    string[] mensajes =
    {
        "Tengo hambre ¿Me das de comer?",
        "Estoy aburrido, ¿quieres jugar conmigo?",
        "Quiero salir a pasear, ¿me acompañas?"
    };

    Random random = new Random();
    while (true)
    {
        string mensajeAleatorio = mensajes[random.Next(mensajes.Length)];
        Console.WriteLine(mensajeAleatorio);
        String respuesta = Console.ReadLine()!.ToLower();
        if (respuesta == "sí" || respuesta == "si")
        {
            Console.WriteLine("¡Gracias! Me siento feliz 😊");
        }
        else
        {
            Console.WriteLine("Oh no, me siento triste 😢");
        }
        System.Threading.Thread.Sleep(random.Next(1000, 10000)); // Espera un tiempo aleatorio antes de mostrar el siguiente mensaje
    }
}




// Ejercicio1();
// Ejercicio1b();
//Ejercicio2();
//Ejercicio2b();
//Ejercicio3();
//Ejercicio4();
//Ejercicio4b();
//Ejercicio4c();
//Ejercicio5();
//Tamagochi();

