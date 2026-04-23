using System.Globalization;
using CalculoFigurasGeometricas.Abstractions;
using CalculoFigurasGeometricas.Models;

namespace CalculoFigurasGeometricas.Services;

/// <summary>
/// Gestiona toda la interacción de consola, incluyendo la lectura de datos y la presentación de resultados.
/// </summary>
public sealed class ConsoleInteractionService : IUserInteractionService
{
    private const string Menu = """
        Selecciona una figura geométrica:
          1. Círculo
          2. Rectángulo
          3. Cuadrado
          4. Triángulo
          5. Esfera
          6. Cubo
          7. Cilindro
          0. Salir
        """;

    /// <summary>
    /// Muestra el encabezado inicial con una breve explicación de la aplicación.
    /// </summary>
    public void ShowWelcome()
    {
        Console.WriteLine("Calculadora de figuras geométricas");
        Console.WriteLine(new string('=', 36));
        Console.WriteLine("El programa calcula únicamente las magnitudes que tienen sentido para cada figura.");
        Console.WriteLine();
    }

    /// <summary>
    /// Solicita al usuario una opción válida del menú principal y la devuelve tipada.
    /// </summary>
    /// <returns>Devuelve la figura seleccionada o la opción de salida.</returns>
    public FigureSelection ReadSelection()
    {
        while (true)
        {
            Console.WriteLine(Menu);
            Console.Write("Elige una opción: ");

            var rawValue = Console.ReadLine()?.Trim() ?? string.Empty;

            if (int.TryParse(rawValue, out var numericOption) && numericOption is >= 0 and <= 7)
            {
                Console.WriteLine();
                return (FigureSelection)numericOption;
            }

            ShowMessage("La opción introducida no es válida.");
        }
    }

    /// <summary>
    /// Solicita un número positivo repitiendo la petición hasta que el dato sea correcto.
    /// </summary>
    /// <param name="prompt">Texto que indica el dato que se debe introducir.</param>
    /// <returns>Devuelve el valor positivo validado.</returns>
    public double ReadPositiveNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            var rawValue = Console.ReadLine()?.Trim() ?? string.Empty;

            if (double.TryParse(rawValue, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out var value)
                && value is > 0)
            {
                return value;
            }

            ShowMessage("Debes introducir un número mayor que cero usando el formato de tu configuración regional.");
        }
    }

    /// <summary>
    /// Muestra un mensaje informativo dejando una línea en blanco para mejorar la lectura.
    /// </summary>
    /// <param name="message">Texto que se mostrará al usuario.</param>
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine();
    }

    /// <summary>
    /// Presenta los cálculos obtenidos para la figura actual con un formato uniforme.
    /// </summary>
    /// <param name="figure">Figura de la que se van a mostrar sus magnitudes.</param>
    public void ShowResults(IGeometricFigure figure)
    {
        Console.WriteLine($"Resultados para {figure.Name}:");

        foreach (var measurement in figure.GetMeasurements())
        {
            Console.WriteLine($"- {measurement.Label}: {measurement.Value:N2} {GetUnitSuffix(measurement.Type)}");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Pregunta si se desea continuar utilizando la aplicación y devuelve la decisión del usuario.
    /// </summary>
    /// <returns>Devuelve <see langword="true"/> si se quiere seguir calculando; en caso contrario, <see langword="false"/>.</returns>
    public bool AskToContinue()
    {
        while (true)
        {
            Console.Write("¿Quieres realizar otro cálculo? (s/n): ");
            var answer = Console.ReadLine()?.Trim().ToLowerInvariant() ?? string.Empty;

            if (answer is "s" or "si" or "sí")
            {
                Console.WriteLine();
                return true;
            }

            if (answer is "n" or "no")
            {
                Console.WriteLine();
                return false;
            }

            ShowMessage("Responde con 's' o 'n'.");
        }
    }

    /// <summary>
    /// Muestra el mensaje final de despedida.
    /// </summary>
    public void ShowFarewell()
    {
        Console.WriteLine("Gracias por utilizar la calculadora geométrica.");
    }

    /// <summary>
    /// Devuelve la unidad simbólica más adecuada para cada tipo de magnitud.
    /// </summary>
    /// <param name="measurementType">Tipo de magnitud cuyo sufijo se quiere obtener.</param>
    /// <returns>Devuelve el sufijo de unidad que se mostrará junto al valor numérico.</returns>
    private static string GetUnitSuffix(MeasurementType measurementType) =>
        measurementType switch
        {
            MeasurementType.Area => "u²",
            MeasurementType.Volume => "u³",
            _ => "u"
        };
}
