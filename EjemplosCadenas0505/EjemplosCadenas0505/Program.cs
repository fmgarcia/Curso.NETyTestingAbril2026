static void CadenasInmutables()
{
    string nombre = "Ana";
    nombre.ToUpper();  // No se asigna el resultado a ninguna variable, por lo que se pierde la referencia al nuevo string creado
    string nombreMayus = nombre.ToUpper();  // Se crea un NUEVO string


    Console.WriteLine(nombre);       // "Ana"   (el original no cambia)
    Console.WriteLine(nombreMayus);  // "ANA"   (es una copia nueva)

    Console.WriteLine(nombre.ToUpper()); // "ANA"   (se muestra el resultado, pero no se guarda en ninguna variable)
    Console.WriteLine(nombre); // "Ana"   (el original sigue sin cambiar, ya que no se asignó el resultado de ToUpper() a ninguna variable)

}

static void MetodosCadenasComunes()
{
    string texto = "Hola Mundo";
    int longitudCadena = texto.Length; // 10
    string cadenaMayusculas = texto.ToUpper(); // "HOLA MUNDO"

    Console.WriteLine(texto.Length); // 10
    Console.WriteLine(texto.ToUpper()); // "HOLA MUNDO"
    Console.WriteLine(texto.ToLower()); // "hola mundo"
    Console.WriteLine(texto.Contains("Mundo")); // true
    Console.WriteLine(texto.StartsWith("Hola")); // true
    Console.WriteLine(texto.EndsWith("Mundo")); // true
}

CadenasInmutables();
