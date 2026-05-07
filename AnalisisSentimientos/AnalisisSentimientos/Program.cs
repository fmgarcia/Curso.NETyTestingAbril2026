using System;
using System.Text.RegularExpressions;
using VaderSharp2;

class Program
{
    // 1. Usamos Arrays en lugar de List<> para alojar los datos en memoria estática/contigua
    private static readonly string[] TextosEspanol = new string[]
    {
        "¡La nueva interfaz es una absoluta maravilla! Me encanta muchísimo ❤️",
        "El software falla siempre que guardo. Es totalmente inútil y pésimo.",
        "El producto está bien, no es el mejor pero hace su trabajo.",
        "ME ENCANTÓ la pantalla, pero la batería es TERRIBLE."
    };

    // 2. Diccionario estático para adaptar el léxico español al motor inglés de VADER
    // Solo necesitamos traducir las palabras que expresan sentimiento, negación o amplificación.
    private static readonly string[,] DiccionarioAdaptacion = new string[,]
    {
        // Amplificadores y modificadores
        { "muy", "very" }, { "muchísimo", "extremely" }, { "absoluta", "absolute" },
        { "pero", "but" }, { "no", "not" }, { "totalmente", "completely" },
        
        // Sentimientos Positivos
        { "maravilla", "marvelous" }, { "encanta", "love" }, { "encantó", "loved" },
        { "bien", "good" }, { "mejor", "best" },
        
        // Sentimientos Negativos
        { "falla", "crashes" }, { "inútil", "useless" }, { "pésimo", "terrible" },
        { "terrible", "terrible" }, { "malo", "bad" }
    };

    static void Main()
    {
        // Adaptamos la consola para mostrar emojis y acentos correctamente
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Inicializamos el analizador VADER
        var analyzer = new SentimentIntensityAnalyzer();

        Console.WriteLine("=== ANÁLISIS DE SENTIMIENTOS LOCAL EN ESPAÑOL ===\n");

        // Iteramos sobre nuestro Array estático
        for (int i = 0; i < TextosEspanol.Length; i++)
        {
            string textoOriginal = TextosEspanol[i];

            // Adaptamos el texto para que VADER lo entienda
            string textoAdaptado = TraducirLexicoParaVader(textoOriginal);

            // Ejecutamos el análisis sobre el texto adaptado
            var resultados = analyzer.PolarityScores(textoAdaptado);

            Console.WriteLine($"Texto Original : \"{textoOriginal}\"");
            Console.WriteLine($"Texto VADER    : \"{textoAdaptado}\"");
            Console.WriteLine($"Puntuación Compuesta: {resultados.Compound}");

            // Lógica de clasificación
            Console.Write("Clasificación  : ");
            if (resultados.Compound >= 0.10)
                Console.WriteLine("🟢 POSITIVO");
            else if (resultados.Compound <= -0.10)
                Console.WriteLine("🔴 NEGATIVO");
            else
                Console.WriteLine("⚪ NEUTRAL");

            Console.WriteLine(new string('-', 50));
        }
    }

    /// <summary>
    /// Reemplaza las palabras en español por sus equivalentes en inglés usando expresiones regulares
    /// para asegurar que solo reemplaza palabras completas (no fragmentos).
    /// </summary>
    private static string TraducirLexicoParaVader(string texto)
    {
        string resultado = texto;

        // Recorremos el array bidimensional
        for (int i = 0; i < DiccionarioAdaptacion.GetLength(0); i++)
        {
            string palabraEsp = DiccionarioAdaptacion[i, 0];
            string palabraIng = DiccionarioAdaptacion[i, 1];

            // Usamos \b para indicar "límite de palabra". Así evitamos que al buscar "no" reemplace "noche".
            // IgnoreCase respeta si el usuario escribió "TERRIBLE" en mayúsculas (VADER usa las mayúsculas para amplificar).
            string patron = $@"\b{palabraEsp}\b";

            resultado = Regex.Replace(resultado, patron, match =>
            {
                // Si la palabra original estaba en mayúsculas, mantenemos la traducción en mayúsculas
                if (match.Value == match.Value.ToUpper())
                    return palabraIng.ToUpper();

                return palabraIng;
            }, RegexOptions.IgnoreCase);
        }

        return resultado;
    }
}



