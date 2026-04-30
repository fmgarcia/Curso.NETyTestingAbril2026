
//El programa “piensa” un número aleatorio entre 1 y 100. 
//El usuario tiene que adivinarlo. El programa dice “Más alto” o “Más bajo” tras cada intento
static void EjercicioAdivinarNumero()
{
    Random random = new Random();  // Crear una instancia de la clase Random para generar números aleatorios

    int secreto = random.Next(1, 101);  // Generar un número aleatorio entre 1 y 100
    int intento = 0;  // Variable para almacenar el número de intentos del usuario
    int contadorIntentos = 0;  // Contador para el número de intentos realizados por el usuario

    Console.WriteLine("Adivina el número entre 1 y 100:");

    do
    {
        Console.Write("Introduce tu intento: ");
        intento = int.Parse(Console.ReadLine()!);  // Leer el intento del usuario y convertirlo a entero
        contadorIntentos++; // Incrementar el contador de intentos
        if (intento < secreto)
        {
            Console.WriteLine("El número es más alto. Intenta de nuevo.");
        }
        else if (intento > secreto)
        {
            Console.WriteLine("El número es más bajo. Intenta de nuevo.");
        }
        else
        {
            Console.WriteLine($"¡Has adivinado el número en {contadorIntentos} {(contadorIntentos > 1 ? "intentos" : "intento")}!");
        }
    } while (intento != secreto);

}

static void EjercicioAdivinarNumeroConMejoras()
{
    Random random = new Random();  // Crear una instancia de la clase Random para generar números aleatorios

    int secreto = random.Next(1, 101);  // Generar un número aleatorio entre 1 y 100
    int intento = 0;  // Variable para almacenar el número de intentos del usuario
    int contadorIntentos = 0;  // Contador para el número de intentos realizados por el usuario
    int intentoAnterior = 1000; // Variable para almacenar el intento anterior del usuario
    bool masAlto = false; // Variable para indicar si el número es más alto o más bajo

    Console.WriteLine("Adivina el número entre 1 y 100:");

    do
    {
        Console.Write("Introduce tu intento: ");
        intento = int.Parse(Console.ReadLine()!);  // Leer el intento del usuario y convertirlo a entero           
        contadorIntentos++; // Incrementar el contador de intentos

        if (masAlto && intento <= intentoAnterior)
        {
            Console.WriteLine("Te dije que el número es más alto y no me has hecho caso.");
        }
        else if (!masAlto && intento >= intentoAnterior)
        {
            Console.WriteLine("Te dije que el número es más bajo y no me has hecho caso.");
        }
        else
        {
            if (intento < secreto)
            {
                Console.WriteLine("El número es más alto. Intenta de nuevo.");
                masAlto = true;
            }
            else if (intento > secreto)
            {
                Console.WriteLine("El número es más bajo. Intenta de nuevo.");
                masAlto = false;
            }
            else
            {
                Console.WriteLine($"¡Has adivinado el número en {contadorIntentos} {(contadorIntentos > 1 ? "intentos" : "intento")}!");
            }
            intentoAnterior = intento; // Actualizar el intento anterior con el intento actual
        }

    } while (intento != secreto);

}


//EjercicioAdivinarNumero();
EjercicioAdivinarNumeroConMejoras();

