//Ejercicio 3: Cifrado César
//Implementa un cifrado César simple: desplaza cada letra 3 posiciones en el alfabeto.

// 'a' se convierte en 'd', 'b' en 'e', ..., 'x' en 'a', 'y' en 'b', 'z' en 'c'.
// "abcdefghijklmnopqrstuvwxyz" → "defghijklmnopqrstuvwxyzabc"

//“abc” → “def”
//“xyz” → “abc” (vuelve al inicio)

using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

static void CifradoCesar(string texto, int desplazamiento = 3)
{
    char[] caracteres = texto.ToLower().ToCharArray();  // "abc" → ['a', 'b', 'c']

    for (int i = 0; i < caracteres.Length; i++)
    {
        if (caracteres[i] >= 'a' && caracteres[i] <= 'z')
        {
            int indiceOriginal = caracteres[i] - 'a'; // 'a' → 0, 'b' → 1, ..., 'z' → 25
            int nuevoIndice = (indiceOriginal + desplazamiento) % 26; // Desplazamiento con wrap-around
            caracteres[i] = (char)(nuevoIndice + 'a'); // Convertir de nuevo a carácter
            //caracteres[i] = (char)((caracteres[i] - 'a' + 3) % 26 + 'a');
        }
    } // ['a', 'b', 'c'] → ['d', 'e', 'f']

    string resultado = new string(caracteres);  // Convertir el array de caracteres de nuevo a string ['d', 'e', 'f'] → "def"
    Console.WriteLine(resultado);
}

static void CifradoCesar2(string texto)
{
    string letras = "abcdefghijklmnopqrstuvwxyz";
    string traducciones = "defghijklmnopqrstuvwxyzabc";
    char[] caracteres = texto.ToLower().ToCharArray();  // "abc" → ['a', 'b', 'c']

    for (int i = 0; i < caracteres.Length; i++)
    {
        int indice = letras.IndexOf(caracteres[i]);
        if (indice != -1)
        {
            caracteres[i] = traducciones[indice];  // Reemplazar el carácter por su traducción
        }
    }

    string resultado = new string(caracteres);
    Console.WriteLine(resultado);

}

static void CifradoFran(string texto)
{
    string letras = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZáéíóúüñÁÉÍÓÚÜÑ0123456789 !#$%&'()*+,-./:;<=>?@[\\]^_{|}~";
    string traducciones = @"ÜíL}m!M8Ú(p#%9u6é*hS7_ÑG3?EÓ@ñdÜ:V$á=bH.íFÁfÁ'2ZÍ&r0Pj+qz/w-O4yv\\1sT,U;{tÁóJc5X| )KeúüB~iÉgWR]YI[óoQl^únxZC";
    char[] caracteres = texto.ToLower().ToCharArray();

    for (int i = 0; i < caracteres.Length; i++)
    {
        int indice = letras.IndexOf(caracteres[i]);
        if (indice != -1)
        {
            caracteres[i] = traducciones[indice];  // Reemplazar el carácter por su traducción
        }
    }

    string resultado = new string(caracteres);
    Console.WriteLine(resultado);

}
static void DescifradoFran(string texto)
{
    string traducciones = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZáéíóúüñÁÉÍÓÚÜÑ0123456789 !#$%&'()*+,-./:;<=>?@[\\]^_{|}~";
    string letras = @"ÜíL}m!M8Ú(p#%9u6é*hS7_ÑG3?EÓ@ñdÜ:V$á=bH.íFÁfÁ'2ZÍ&r0Pj+qz/w-O4yv\\1sT,U;{tÁóJc5X| )KeúüB~iÉgWR]YI[óoQl^únxZC";
    char[] caracteres = texto.ToLower().ToCharArray();

    for (int i = 0; i < caracteres.Length; i++)
    {
        int indice = letras.IndexOf(caracteres[i]);
        if (indice != -1)
        {
            caracteres[i] = traducciones[indice];  // Reemplazar el carácter por su traducción
        }
    }

    string resultado = new string(caracteres);
    Console.WriteLine(resultado);

}

//Ejercicio 1: Contador de vocales
//Pide una frase al usuario y cuenta cuántas vocales tiene (sin distinguir mayúsculas/minúsculas).
static void ContadorVocales()
{
    Console.WriteLine("Escribe una frase para saber cuantas vocales tiene: ");
    string frase = Console.ReadLine()!.ToLower();
    int contador = 0;
    for (int i = 0; i < frase.Length; i++)
    {
        if ("aeiou".Contains(frase[i]))
        {
            contador++;
        }
    }
    Console.WriteLine($"Numero de vocales: {contador} ");
}

//Ejercicio 2: Palíndromo
//Comprueba si una palabra es un palíndromo (se lee igual al derecho y al revés): “ana”, “radar”, “reconocer”.
static void Palindromo()
{
    Console.WriteLine("Escribe una palabra para saber si es un palíndromo:");
    string palabra = Console.ReadLine()!.ToLower();
    string palabraInvertida = new string(palabra.Reverse().ToArray());
    Console.WriteLine(palabra == palabraInvertida ? "La palabra es un palíndromo." : "La palabra no es un palíndromo.");
}

static void Palindromo2()
{
    Console.WriteLine("Escribe una palabra para saber si es un palíndromo:");
    string palabra = Console.ReadLine()!.ToLower();
    bool esPalindromo = true;
    for (int i = 0; i < palabra.Length / 2; i++)
    {
        if (palabra[i] != palabra[palabra.Length - 1 - i])
        {
            esPalindromo = false;
            break;
        }
    }
    Console.WriteLine(esPalindromo ? "La palabra es un palíndromo." : "La palabra no es un palíndromo.");
}

//Ejercicio 4: Validador de contraseñas
//Crea un programa que valide si una contraseña cumple:

//Al menos 8 caracteres
//Al menos una mayúscula
//Al menos una minúscula
//Al menos un número
//Al menos un carácter especial (!@#$%^&*)
static void ValidadorContraseñasEstructuras()
{

    Console.WriteLine("introduce la nueva contraseña");
    string contrasena = Console.ReadLine()!;
    //bool valida = false;
    bool minuscula = false;
    bool mayuscula = false;
    bool numero = false;
    bool caracterRaro = false;
    string caracteresEspeciales = "!@#$%^";

    if (contrasena.Length < 8)
    {
        Console.WriteLine("La contraseña debe tener al menos 8 caracteres.");
        return;
    }

    for (int i = 0; i < contrasena.Length; i++)
    {
        if (char.IsLower(contrasena[i]))
            minuscula = true;
        if (char.IsUpper(contrasena[i]))
            mayuscula = true;
        if (char.IsDigit(contrasena[i]))
            numero = true;
        if (caracteresEspeciales.Contains(contrasena[i]))
            caracterRaro = true;

        // Optimización: Si ya se han encontrado todos los requisitos, no es necesario seguir comprobando el resto de la contraseña
        if (minuscula && mayuscula && numero && caracterRaro)
            break;
    }
    Console.WriteLine((minuscula && mayuscula && numero && caracterRaro) ? "Contraseña válida." : "Contraseña no válida. Asegúrate de que cumple con todos los requisitos.");
}


static void ValidadorContraseñasLINQ()
{
    Console.WriteLine("introduce la nueva contraseña");
    string contrasena = Console.ReadLine()!;
    string caracteresEspeciales = "!@#$%^";
    bool esValida = contrasena.Length >= 8 &&
                    contrasena.Any(char.IsLower) &&
                    contrasena.Any(char.IsUpper) &&
                    contrasena.Any(char.IsDigit) &&
                    contrasena.Any(c => caracteresEspeciales.Contains(c));
    Console.WriteLine(esValida ? "Contraseña válida." : "Contraseña no válida. Asegúrate de que cumple con todos los requisitos.");
}

static void NoContiene()
{
    string caracteresProhibidos = "aeiou";
    Console.WriteLine("introduce la nueva contraseña");
    string contrasena = Console.ReadLine()!;
    Console.WriteLine(!contrasena.Contains(caracteresProhibidos) ? "Contraseña válida." : "Contraseña no válida. No debe contener caracteres prohibidos.");
}




//CifradoCesar("abc"); // Salida: "def"
//CifradoCesar("xyz"); // Salida: "abc"
//CifradoCesar("Hola Mundo!"); // Salida: "krod pxqgr!" (solo las letras se cifran, los espacios y signos de puntuación permanecen igual)");
//CifradoCesar("Hola Mundo!", 5); // Salida: "mtqf rzsit!" (desplazamiento de 5 posiciones)
//CifradoFran("Esto es un ejemplo. Este texto incluye mayúsculas, minúsculas, números y símbolos: @#&*()!");
//DescifradoFran("mhSuJmhJ79Jm(m%6#uiJmhSmJSmGSuJÚ9L#73mJ%Ü3zhL7#ÜhBJ%Ú9zhL7#ÜhBJ9z%m*uhJ3Jh+%íu#uhgJ[5 úKec");
//ContadorVocales();
//Palindromo();
//Palindromo2();
//ValidadorContraseñasEstructuras();
//ValidadorContraseñasLINQ();