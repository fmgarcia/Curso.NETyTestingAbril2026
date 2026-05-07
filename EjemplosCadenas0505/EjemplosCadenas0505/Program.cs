using System.Text;
using System.Text.RegularExpressions;


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
    string texto = "Hola, bienvenido al curso de C#";

    // Longitud
    Console.WriteLine($"Longitud: {texto.Length}");  // 31

    // Contiene
    Console.WriteLine(texto.Contains("curso"));     // True
    Console.WriteLine(texto.Contains("Python"));    // False

    // Empieza con / Termina con
    Console.WriteLine(texto.StartsWith("Hola"));    // True
    Console.WriteLine(texto.EndsWith("C#"));        // True

    // Posición de un substring
    int pos = texto.IndexOf("curso");
    Console.WriteLine($"'curso' está en posición {pos}");  // 20

    int noExiste = texto.IndexOf("Java");
    Console.WriteLine($"'Java' está en posición {noExiste}");  // -1 (no encontrado)

    // Está vacío o nulo
    string vacio = "";
    string? nulo = null;
    Console.WriteLine(string.IsNullOrEmpty(vacio));      // True
    Console.WriteLine(string.IsNullOrEmpty(nulo));       // True
    Console.WriteLine(string.IsNullOrWhiteSpace("  ")); // True (solo espacios)

}

static void MetodosTransformacionCadenas()
{
    string texto = "  Hola, Mundo  ";

    // Mayúsculas y minúsculas
    Console.WriteLine(texto.ToUpper());    // "  HOLA, MUNDO  "
    Console.WriteLine(texto.ToLower());    // "  hola, mundo  "

    // Eliminar espacios
    Console.WriteLine($"[{texto.Trim()}]");       // "[Hola, Mundo]"
    Console.WriteLine($"[{texto.TrimStart()}]");  // "[Hola, Mundo  ]"
    Console.WriteLine($"[{texto.TrimEnd()}]");    // "[  Hola, Mundo]"

    // Reemplazar
    string nuevo = texto.Trim().Replace("Mundo", "C#").ToLower().ToUpper().Replace(" ", "_").Insert(0, "Adiós, ").ToUpper();
    Console.WriteLine(nuevo);  // "ADIOS, HOLA,_C#"

    // Insertar y eliminar
    string base1 = "Hola Mundo";
    Console.WriteLine(base1.Insert(5, "Buen "));  // "Hola Buen Mundo"
    Console.WriteLine(base1.Remove(5));            // "Hola " (elimina desde índice 5)
    Console.WriteLine(base1.Remove(5, 3));         // "Hola do" (elimina 3 chars desde índice 5)

}

static void ObtencionSubcadenas()
{
    string email = "usuario@correo.com";

    // Substring(inicio): desde la posición hasta el final
    string dominio = email.Substring(email.IndexOf('@') + 1);
    Console.WriteLine(dominio);  // "correo.com"

    // Substring(inicio, longitud)
    string usuario = email.Substring(0, email.IndexOf('@'));
    Console.WriteLine(usuario);  // "usuario"

    // Forma moderna con rangos. Disponible en C# 8.0 y posteriores
    string dominio2 = email[(email.IndexOf('@') + 1)..];
    string usuario2 = email[..email.IndexOf('@')];
    Console.WriteLine(dominio2);  // "correo.com"
    Console.WriteLine(usuario2);

}

static void ParticionesUniones()
{
    // Split: dividir un string en un array
    string csv = "Ana,Luis,María,Pedro,Carmen";
    string[] nombres = csv.Split(',');

    foreach (string nombre in nombres)
    {
        Console.WriteLine(nombre);
    }
    // Ana
    // Luis
    // María
    // Pedro
    // Carmen

    // Join: unir un array en un string
    string unido = string.Join(" - ", nombres);
    Console.WriteLine(unido);  // "Ana - Luis - María - Pedro - Carmen"

    // Split con múltiples separadores
    string datos = "nombre=Ana; edad=25; ciudad=Madrid";
    string[] pares = datos.Split(new[] { ';', '=' }, StringSplitOptions.TrimEntries); // { "nombre", "Ana", "edad", "25", "ciudad", "Madrid" }

    // Split por líneas
    string multilinea = "línea 1\nlínea 2\nlínea 3";
    string[] lineas = multilinea.Split('\n');
    foreach (string linea in lineas)
    {
        Console.WriteLine(linea);  // Imprime cada línea por separado
    }

}

static void Rellenos()
{
    // PadLeft: rellenar por la izquierda
    string numero = "42";
    Console.WriteLine(numero.PadLeft(5, '0'));   // "00042"
    Console.WriteLine(numero.PadLeft(8));        // "      42" (rellena con espacios)

    // PadRight: rellenar por la derecha
    string nombre = "Ana";
    Console.WriteLine($"|{nombre.PadRight(10)}|");  // "|Ana       |"

    // Útil para tablas alineadas
    string[] items = { "Manzana", "Pan", "Leche" };
    double[] precios = { 1.50, 0.80, 1.20 };


    Console.OutputEncoding = System.Text.Encoding.UTF8; // Para mostrar el símbolo de euro correctamente
    for (int i = 0; i < items.Length; i++)
    {
        //Console.WriteLine($"{items[i].PadRight(12)} {precios[i],6:N2} €");  // Cuadra la coma decimal a la derecha con un ancho total de 6 caracteres, incluyendo el símbolo de euro
        Console.WriteLine($"{items[i].PadRight(12)} {precios[i],6:C2}"); // Usa el formato de moneda local, que incluye el símbolo de euro y formatea con dos decimales
    }
    // Manzana       1,50 €
    // Pan           0,80 €
    // Leche         1,20 €

}


static void InterpolacionCadenas()
{
    string nombre = "Ana";
    int edad = 25;

    // Concatenación clásica (NO recomendada)
    string msg1 = "Hola, " + nombre + ". Tienes " + edad + " años.";

    // Interpolación (RECOMENDADA)
    string msg2 = $"Hola, {nombre}. Tienes {edad} años.";

    // Puedes poner expresiones dentro de { }
    string msg3 = $"El doble de tu edad es {edad * 2}";
    string msg4 = $"En mayúsculas: {nombre.ToUpper()}";

    // Formato numérico dentro de interpolación
    double precio = 1234.5;
    Console.WriteLine($"Precio: {precio:C2}");     // Moneda: 1.234,50 €
    Console.WriteLine($"Precio: {precio:N2}");     // Número: 1.234,50
    Console.WriteLine($"Precio: {precio:F2}");     // Fixed: 1234,50
    Console.WriteLine($"Porcentaje: {0.256:P1}");  // 25,6 %
    Console.WriteLine(255.ToString("B"));          // 11111111

    // Alineación
    Console.WriteLine($"|{"Izquierda",-15}|{"Derecha",15}|");
    // |Izquierda      |       Derecha|

}

//Formatos numéricos
//Formato	Descripción	Ejemplo (1234.5)
//C / C2	Moneda	1.234,50 €
//N / N2	Número con separadores	1.234,50
//F / F2	Decimal fijo	1234,50
//P / P1	Porcentaje	123.450,0 %
//E	Notación científica	1,234500E+003
//D5	Entero con ceros a la izquierda	01234
//X	Hexadecimal	4D2

static void TrabajoFechas()
{
    DateTime ahora = DateTime.Now;

    Console.WriteLine($"Completa: {ahora}");
    Console.WriteLine($"Solo fecha: {ahora:d}");          // 30/03/2026
    Console.WriteLine($"Fecha larga: {ahora:D}");         // lunes, 30 de marzo de 2026
    Console.WriteLine($"Solo hora: {ahora:t}");           // 14:30
    Console.WriteLine($"Personalizado: {ahora:dd/MM/yyyy HH:mm}"); // 30/03/2026 14:30
    Console.WriteLine($"Estándar formato 1123: {ahora:R}"); // Formato estándar 1123
    Console.WriteLine($"Estándar formato 1123: {ahora:O}"); // Formato estándar 1123 con zona horaria (ISO 8601)

}

static void VerbatimRawStrings()
{
    // Sin @: necesitas escapar las barras
    string ruta1 = "C:\\Users\\Ana\\Documentos\\archivo.txt";

    // Con @: las barras se escriben directamente (cadenas verbatim)
    string ruta2 = @"C:\Users\Ana\Documentos\archivo.txt";

    // También permite multilínea
    string multilinea = @"Esta es la primera línea.
Esta es la segunda línea.
Esta es la tercera línea.";

    // Raw string literal
    string json = """
    {
        "nombre": "Ana",
        "edad": 25,
        "ciudad": "Madrid"
    }
    """;

    Console.WriteLine(json);

    // Raw string con interpolación
    string nombre = "Ana";
    int edad = 25;
    string jsonDinamico = $$"""
    {
    
        "name": "{{nombre.PadRight(10)}}",
        "age": {{edad}}
    }
    """;
}

static void CompararCadenas()
{
    string a = "hola";
    string b = "Hola";

    string pais = "España";
    string palabra = "Espar";

    // Comparación sensible a mayúsculas (por defecto)
    Console.WriteLine(a == b);  // False

    // Comparación ignorando mayúsculas
    Console.WriteLine(a.Equals(b, StringComparison.OrdinalIgnoreCase));  // True
    Console.WriteLine(string.Equals(a, b, StringComparison.OrdinalIgnoreCase));  // True

    // Comparar para ordenar
    int resultado = string.Compare(a, b, StringComparison.OrdinalIgnoreCase);
    // 0 = iguales, < 0 = a va antes, > 0 = a va después

    Console.WriteLine(resultado);  // 0 (son iguales ignorando mayúsculas)

    // Comparar con cultura específica
    Console.WriteLine(string.Compare(pais, palabra, StringComparison.CurrentCulture) < 0 ? "España va antes" : "Espar va antes");  // Comparación con cultura específica
    Console.WriteLine(string.Compare(pais, palabra, StringComparison.Ordinal) < 0 ? "España va antes" : "Espar va antes");  // Comparación con cultura específica

}

// StringBuilder



static void ManejandoMemoria()
{


    // MAL: concatenación en bucle (crea 1000 strings intermedios)
    string resultado = "";
    for (int i = 0; i < 1000; i++)
    {
        resultado += i + ", ";  // Cada += crea un nuevo string
    }

    // BIEN: StringBuilder (modifica el mismo objeto)
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < 1000; i++)
    {
        sb.Append(i);
        sb.Append(", ");
    }
    string resultadoFinal = sb.ToString();

}

static void MetodosStringBuilder()
{
    StringBuilder sb = new StringBuilder();

    sb.Append("Hola");           // Añadir al final
    sb.Append(" mundo");
    sb.AppendLine("!");          // Añadir + salto de línea
    sb.AppendLine("¿Qué tal?");

    sb.Insert(5, ", buen");      // Insertar en posición
    sb.Replace("mundo", "mundo maravilloso");  // Reemplazar


    Console.WriteLine(sb.ToString());
    Console.WriteLine($"Longitud: {sb.Length}");

    sb.Clear();  // Vaciar todo

}

static void ExpresionesRegularesBasicas()
{

    string texto = "Mi email es ana@correo.com y mi teléfono es 612345678";

    // Buscar un patrón de email
    bool tieneEmail = Regex.IsMatch(texto, @"[\w.]+@[\w.]+\.\w+");
    Console.WriteLine($"¿Tiene email? {tieneEmail}");  // True

    // Extraer el email
    Match match = Regex.Match(texto, @"[\w.]+@[\w.]+\.\w+");
    Console.WriteLine($"Email encontrado: {match.Value}");  // ana@correo.com

    // Buscar números de teléfono (9 dígitos)
    Match telefono = Regex.Match(texto, @"\d{9}");
    Console.WriteLine($"Teléfono: {telefono.Value}");  // 612345678

    // Validar formato
    string email = "usuario@ejemplo.com";
    bool emailValido = Regex.IsMatch(email, @"^[\w.]+@[\w.]+\.\w{2,}$");
    Console.WriteLine($"¿Email válido? {emailValido}");  // True

    // Reemplazar con regex
    string censurado = Regex.Replace(texto, @"\d{9}", "***-***-***");
    Console.WriteLine(censurado);

}

//CadenasInmutables();
//MetodosCadenasComunes();
//MetodosTransformacionCadenas();
//ObtencionSubcadenas();
//ParticionesUniones();
//Rellenos();
//InterpolacionCadenas();
//TrabajoFechas();
//CompararCadenas();
ExpresionesRegularesBasicas();