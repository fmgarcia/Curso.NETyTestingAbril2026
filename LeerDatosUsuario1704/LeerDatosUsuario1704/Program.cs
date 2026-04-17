Console.WriteLine("Cuál es tu nombre? ");
string nombreUsuario = Console.ReadLine(); // Lee la entrada del usuario y la almacena en la variable nombreUsuario

Console.WriteLine("Cuántos años tienes? ");
int edad = int.Parse(Console.ReadLine()); // Lee la entrada del usuario, la convierte a un entero y la almacena en la variable edad

Console.WriteLine($"Hola {nombreUsuario}, tienes {edad} años. Hace diez años tenías {edad - 10} años."); // Imprime un mensaje personalizado utilizando las variables nombreUsuario y edad

Console.WriteLine("Cuánto dinero ganas? ");
double salario = double.Parse(Console.ReadLine()); // Lee la entrada del usuario, la convierte a un número decimal y la almacena en la variable salario

Console.WriteLine($"Tu sueldo es de {salario} dólares."); // Imprime el salario del usuario utilizando interpolación de cadenas