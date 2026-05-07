//Ejercicio 3: Cifrado César
//Implementa un cifrado César simple: desplaza cada letra 3 posiciones en el alfabeto.

// 'a' se convierte en 'd', 'b' en 'e', ..., 'x' en 'a', 'y' en 'b', 'z' en 'c'.
// "abcdefghijklmnopqrstuvwxyz" → "defghijklmnopqrstuvwxyzabc"

//“abc” → “def”
//“xyz” → “abc” (vuelve al inicio)

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


CifradoCesar("abc"); // Salida: "def"
CifradoCesar("xyz"); // Salida: "abc"
CifradoCesar("Hola Mundo!"); // Salida: "krod pxqgr!" (solo las letras se cifran, los espacios y signos de puntuación permanecen igual)");
CifradoCesar("Hola Mundo!", 5); // Salida: "mtqf rzsit!" (desplazamiento de 5 posiciones)
CifradoFran("Esto es un ejemplo. Este texto incluye mayúsculas, minúsculas, números y símbolos: @#&*()!");
DescifradoFran("mhSuJmhJ79Jm(m%6#uiJmhSmJSmGSuJÚ9L#73mJ%Ü3zhL7#ÜhBJ%Ú9zhL7#ÜhBJ9z%m*uhJ3Jh+%íu#uhgJ[5 úKec");