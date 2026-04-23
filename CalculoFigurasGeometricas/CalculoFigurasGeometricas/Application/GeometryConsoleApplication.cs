using CalculoFigurasGeometricas.Abstractions;
using CalculoFigurasGeometricas.Factories;
using CalculoFigurasGeometricas.Models;

namespace CalculoFigurasGeometricas.Application;

/// <summary>
/// Orquesta el flujo principal de la aplicación conectando la interfaz de usuario con la creación y el cálculo de figuras.
/// </summary>
public sealed class GeometryConsoleApplication(
    IUserInteractionService interactionService,
    GeometricFigureFactory figureFactory)
{
    private readonly IUserInteractionService _interactionService = interactionService ?? throw new ArgumentNullException(nameof(interactionService));
    private readonly GeometricFigureFactory _figureFactory = figureFactory ?? throw new ArgumentNullException(nameof(figureFactory));

    /// <summary>
    /// Ejecuta el menú principal y repite el proceso hasta que el usuario decida salir.
    /// </summary>
    public void Run()
    {
        _interactionService.ShowWelcome();

        while (true)
        {
            var selection = _interactionService.ReadSelection();

            if (selection is FigureSelection.Exit)
            {
                _interactionService.ShowFarewell();
                return;
            }

            var figure = _figureFactory.Create(selection, _interactionService);
            _interactionService.ShowResults(figure);

            if (_interactionService.AskToContinue())
            {
                continue;
            }

            _interactionService.ShowFarewell();
            return;
        }
    }
}
