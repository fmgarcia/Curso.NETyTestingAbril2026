using CalculoFigurasGeometricas.Application;
using CalculoFigurasGeometricas.Factories;
using CalculoFigurasGeometricas.Services;

namespace CalculoFigurasGeometricas;

/// <summary>
/// Contiene el punto de entrada de la aplicación de consola.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Crea las dependencias principales y ejecuta el flujo de la aplicación.
    /// </summary>
    private static void Main()
    {
        var interactionService = new ConsoleInteractionService();
        var figureFactory = new GeometricFigureFactory();
        var application = new GeometryConsoleApplication(interactionService, figureFactory);

        application.Run();
    }
}
