Console.WriteLine("Cuál es tu nombre? ");
string nombreUsuario = Console.ReadLine(); // Lee la entrada del usuario y la almacena en la variable nombreUsuario
nombreUsuario = string.IsNullOrWhiteSpace(nombreUsuario) ? "Fran" : nombreUsuario; // Si el usuario no ingresa un nombre, se asigna "Fran" como valor predeterminado

Console.WriteLine("Cuántos años tienes? ");
//int edad = int.Parse(Console.ReadLine()); // Lee la entrada del usuario, la convierte a un entero y la almacena en la variable edad
int edad = Convert.ToInt32(Console.ReadLine()); // Lee la entrada del usuario, la convierte a un entero utilizando Convert y la almacena en la variable edadConvert


Console.WriteLine($"Hola {nombreUsuario}, tienes {edad} años. Hace diez años tenías {edad - 10} años."); // Imprime un mensaje personalizado utilizando las variables nombreUsuario y edad

Console.WriteLine("Cuánto dinero ganas? ");
//int salario = (int)double.Parse(Console.ReadLine()); // Lee la entrada del usuario, la convierte a un número decimal y la almacena en la variable salario
double salario = Convert.ToDouble(Console.ReadLine());

Console.WriteLine($"Tu sueldo es de {salario} dólares."); // Imprime el salario del usuario utilizando interpolación de cadenas

int numero = 20;
//string numeroCadena = numero.ToString(); // Convierte el número entero a una cadena de texto "20"
string numeroCadena = Convert.ToString(numero); // Convierte el número entero a una cadena de texto "20"
Console.WriteLine(numeroCadena + "5"); // Imprime la cadena resultante