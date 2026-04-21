// Uso de TryParse para convertir una cadena a un número entero

Console.WriteLine("Introduce un número"); // Pedimos al usuario que introduzca un número
string cadena = Console.ReadLine(); // Leemos la entrada del usuario y la almacenamos en una variable de tipo string

if (int.TryParse(cadena, out int numero)) // Intentamos convertir la cadena a un número entero
{
    Console.WriteLine($"El número introducido es: {numero}"); // Si la conversión es exitosa, mostramos el número
}
else
{
    Console.WriteLine("No has introducido un número válido."); // Si la conversión falla, mostramos un mensaje de error
}

// Uso de Nullable para manejar valores que pueden ser nulos

//int numero = null; // Esto no es válido, ya que int no puede ser nulo
int? edad = null;


if (edad.HasValue) // Verificamos si la variable nullable tiene un valor
{
    Console.WriteLine($"La edad es: {edad.Value}"); // Si tiene un valor, lo mostramos
}
else
{
    Console.WriteLine("La edad no ha sido asignada."); // Si no tiene un valor, mostramos un mensaje indicando que no ha sido asignada
}

