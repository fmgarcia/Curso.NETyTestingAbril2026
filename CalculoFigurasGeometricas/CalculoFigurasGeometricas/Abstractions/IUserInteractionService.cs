using CalculoFigurasGeometricas.Models;

namespace CalculoFigurasGeometricas.Abstractions;

/// <summary>
/// Define las operaciones de entrada y salida necesarias para interactuar con el usuario.
/// </summary>
public interface IUserInteractionService
{
    /// <summary>
    /// Muestra el encabezado inicial de la aplicación.
    /// </summary>
    void ShowWelcome();

    /// <summary>
    /// Solicita al usuario la figura con la que desea trabajar.
    /// </summary>
    /// <returns>Devuelve la opción de figura seleccionada en el menú.</returns>
    FigureSelection ReadSelection();

    /// <summary>
    /// Solicita al usuario un número positivo para un dato geométrico.
    /// </summary>
    /// <param name="prompt">Texto que explica el dato que se debe introducir.</param>
    /// <returns>Devuelve el valor numérico validado.</returns>
    double ReadPositiveNumber(string prompt);

    /// <summary>
    /// Muestra un mensaje informativo o de validación al usuario.
    /// </summary>
    /// <param name="message">Texto que se imprimirá por pantalla.</param>
    void ShowMessage(string message);

    /// <summary>
    /// Presenta por pantalla los resultados calculados para una figura.
    /// </summary>
    /// <param name="figure">Figura de la que se mostrarán sus magnitudes calculadas.</param>
    void ShowResults(IGeometricFigure figure);

    /// <summary>
    /// Pregunta al usuario si quiere realizar otro cálculo adicional.
    /// </summary>
    /// <returns>Devuelve <see langword="true"/> si se desea continuar; en caso contrario, <see langword="false"/>.</returns>
    bool AskToContinue();

    /// <summary>
    /// Muestra el mensaje final de despedida antes de cerrar la aplicación.
    /// </summary>
    void ShowFarewell();
}
