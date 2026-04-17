// ============================================================
// Clase: InterfazUsuario
// Descripción: Gestiona toda la interacción con el usuario
// por consola: muestra menús, lee datos y presenta resultados.
// Separar la UI de la lógica de negocio facilita el
// mantenimiento y las pruebas del código.
// ============================================================

namespace CalculadoraBasica;

/// <summary>
/// Gestiona la interfaz de usuario por consola de la calculadora.
/// </summary>
public class InterfazUsuario
{
    // ----------------------------------------------------------
    // Campo privado: instancia de la calculadora.
    // Al declararlo aquí, toda la clase puede usarlo.
    // El modificador 'private' significa que solo es accesible
    // desde dentro de esta misma clase.
    // ----------------------------------------------------------

    // Instancia de la calculadora que realizará los cálculos
    private readonly Calculadora _calculadora;

    // ----------------------------------------------------------
    // CONSTRUCTOR
    // El constructor se ejecuta cuando se crea un objeto de
    // esta clase con 'new InterfazUsuario()'.
    // Aquí inicializamos la calculadora que vamos a usar.
    // ----------------------------------------------------------

    /// <summary>
    /// Inicializa la interfaz de usuario creando una instancia
    /// de la calculadora interna.
    /// </summary>
    public InterfazUsuario()
    {
        // Creamos el objeto Calculadora que usaremos para operar
        _calculadora = new Calculadora();
    }

    // ----------------------------------------------------------
    // MÉTODO PRINCIPAL: Ejecutar
    // Es el punto de entrada de la interfaz. Contiene el bucle
    // principal de la aplicación que se repite hasta que el
    // usuario decida salir.
    // ----------------------------------------------------------

    /// <summary>
    /// Inicia el bucle principal de la calculadora.
    /// </summary>
    public void Ejecutar()
    {
        // Mensaje de bienvenida al iniciar la aplicación
        Console.WriteLine("========================================");
        Console.WriteLine("       CALCULADORA BÁSICA EN C#         ");
        Console.WriteLine("========================================");

        // Variable de control del bucle principal.
        // Mientras sea 'true', el programa sigue en ejecución.
        bool continuar = true;

        // Bucle principal: se repite mientras el usuario no elija salir
        while (continuar)
        {
            // Mostramos el menú de operaciones disponibles
            MostrarMenu();

            // Leemos la opción elegida por el usuario
            string opcion = LeerTexto("Selecciona una opción: ");

            // Usamos switch para ejecutar la acción según la opción
            switch (opcion)
            {
                case "1":
                    // El usuario eligió sumar
                    EjecutarOperacion("suma");
                    break;

                case "2":
                    // El usuario eligió restar
                    EjecutarOperacion("resta");
                    break;

                case "3":
                    // El usuario eligió multiplicar
                    EjecutarOperacion("multiplicación");
                    break;

                case "4":
                    // El usuario eligió dividir
                    EjecutarOperacion("división");
                    break;

                case "5":
                    // El usuario quiere salir: cambiamos el control del bucle
                    continuar = false;
                    Console.WriteLine("\n¡Hasta luego! Gracias por usar la calculadora.");
                    break;

                default:
                    // El usuario introdujo una opción no válida
                    Console.WriteLine("\nOpción no válida. Por favor, elige entre 1 y 5.\n");
                    break;
            }
        }
    }

    // ----------------------------------------------------------
    // MÉTODO PRIVADO: MostrarMenu
    // Imprime en pantalla las opciones disponibles.
    // Es privado porque solo lo usa esta clase internamente.
    // ----------------------------------------------------------

    /// <summary>
    /// Muestra el menú principal de operaciones en consola.
    /// </summary>
    private void MostrarMenu()
    {
        // Línea en blanco para separar visualmente las iteraciones
        Console.WriteLine();
        Console.WriteLine("--- MENÚ DE OPERACIONES ---");
        Console.WriteLine("  1. Suma");
        Console.WriteLine("  2. Resta");
        Console.WriteLine("  3. Multiplicación");
        Console.WriteLine("  4. División");
        Console.WriteLine("  5. Salir");
        Console.WriteLine("---------------------------");
    }

    // ----------------------------------------------------------
    // MÉTODO PRIVADO: EjecutarOperacion
    // Centraliza la lógica de pedir números, llamar al método
    // correspondiente de Calculadora y mostrar el resultado.
    // Recibe el nombre de la operación como parámetro de texto.
    // ----------------------------------------------------------

    /// <summary>
    /// Pide los dos operandos, ejecuta la operación indicada
    /// y muestra el resultado por consola.
    /// </summary>
    /// <param name="nombreOperacion">
    /// Nombre de la operación a realizar (ej: "suma").
    /// </param>
    private void EjecutarOperacion(string nombreOperacion)
    {
        Console.WriteLine($"\n--- {nombreOperacion.ToUpper()} ---");

        // Pedimos el primer número al usuario
        double a = LeerNumero("Introduce el primer número:  ");

        // Pedimos el segundo número al usuario
        double b = LeerNumero("Introduce el segundo número: ");

        // Variable donde guardaremos el resultado de la operación
        double resultado;

        // Usamos try-catch para capturar posibles errores en tiempo
        // de ejecución, como la división entre cero.
        try
        {
            // Seleccionamos la operación según el nombre recibido
            resultado = nombreOperacion switch
            {
                "suma"           => _calculadora.Sumar(a, b),
                "resta"          => _calculadora.Restar(a, b),
                "multiplicación" => _calculadora.Multiplicar(a, b),
                "división"       => _calculadora.Dividir(a, b),

                // Si llegase un nombre desconocido, lanzamos excepción
                _ => throw new ArgumentException($"Operación desconocida: {nombreOperacion}")
            };

            // Mostramos el resultado con formato legible
            // {a} y {b} se sustituyen por los valores reales (interpolación de cadenas)
            Console.WriteLine($"\nResultado: {a} {ObtenerSimbolo(nombreOperacion)} {b} = {resultado}");
        }
        catch (DivideByZeroException ex)
        {
            // Capturamos el error de división entre cero y avisamos al usuario
            // 'ex.Message' contiene el texto del error definido en Calculadora.cs
            Console.WriteLine($"\n⚠  {ex.Message}");
        }
        catch (Exception ex)
        {
            // Capturamos cualquier otro error inesperado
            Console.WriteLine($"\n⚠  Error inesperado: {ex.Message}");
        }
    }

    // ----------------------------------------------------------
    // MÉTODO PRIVADO: LeerNumero
    // Lee un número introducido por el usuario y valida que
    // sea un número real (double). Si no lo es, vuelve a pedirlo.
    // Esto evita que el programa se rompa con entradas inválidas.
    // ----------------------------------------------------------

    /// <summary>
    /// Solicita un número por consola y lo valida.
    /// Si la entrada no es numérica, vuelve a pedirla.
    /// </summary>
    /// <param name="mensaje">Texto a mostrar al usuario.</param>
    /// <returns>El número introducido como tipo double.</returns>
    private double LeerNumero(string mensaje)
    {
        // Bucle que se repite hasta que el usuario introduzca un número válido
        while (true)
        {
            // Mostramos el mensaje e intentamos convertir la entrada a double
            string entrada = LeerTexto(mensaje);

            // double.TryParse intenta convertir el texto a número.
            // Si lo consigue, guarda el valor en 'numero' y devuelve true.
            // Si falla, devuelve false sin lanzar excepción.
            if (double.TryParse(entrada, out double numero))
            {
                // La conversión fue exitosa: devolvemos el número
                return numero;
            }

            // La entrada no era un número: informamos y repetimos el bucle
            Console.WriteLine("  Entrada no válida. Por favor, introduce un número (ej: 3,14).");
        }
    }

    // ----------------------------------------------------------
    // MÉTODO PRIVADO: LeerTexto
    // Muestra un mensaje y devuelve el texto que escribe el
    // usuario. Garantiza que nunca devuelva null (usa ?? "").
    // ----------------------------------------------------------

    /// <summary>
    /// Muestra un mensaje y devuelve la línea escrita por el usuario.
    /// </summary>
    /// <param name="mensaje">Texto a mostrar antes de leer.</param>
    /// <returns>La cadena introducida por el usuario.</returns>
    private string LeerTexto(string mensaje)
    {
        // Escribimos el mensaje sin salto de línea para que el cursor
        // quede al lado del texto (Write en lugar de WriteLine)
        Console.Write(mensaje);

        // ReadLine lee todo lo que escribe el usuario hasta que pulsa Enter.
        // El operador '?? ""' evita que devuelva null: si ReadLine falla,
        // devuelve una cadena vacía.
        return Console.ReadLine() ?? "";
    }

    // ----------------------------------------------------------
    // MÉTODO PRIVADO: ObtenerSimbolo
    // Pequeño método auxiliar que devuelve el símbolo matemático
    // de cada operación para mostrar el resultado con mejor formato.
    // ----------------------------------------------------------

    /// <summary>
    /// Devuelve el símbolo matemático asociado a una operación.
    /// </summary>
    /// <param name="operacion">Nombre de la operación.</param>
    /// <returns>El símbolo correspondiente (ej: "+", "-", etc.).</returns>
    private string ObtenerSimbolo(string operacion)
    {
        // Usamos una expresión switch para asociar nombre → símbolo
        return operacion switch
        {
            "suma"           => "+",
            "resta"          => "-",
            "multiplicación" => "×",
            "división"       => "÷",
            _                => "?"  // Caso por defecto si no se reconoce
        };
    }
}
