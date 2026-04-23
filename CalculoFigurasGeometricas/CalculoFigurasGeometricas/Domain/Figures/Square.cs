using CalculoFigurasGeometricas.Abstractions;
using CalculoFigurasGeometricas.Models;

namespace CalculoFigurasGeometricas.Domain.Figures;

/// <summary>
/// Representa un cuadrado y calcula su área y su perímetro a partir del lado.
/// </summary>
public sealed class Square : IGeometricFigure
{
    /// <summary>
    /// Inicializa un cuadrado validando el valor del lado recibido.
    /// </summary>
    /// <param name="side">Longitud del lado del cuadrado.</param>
    public Square(double side)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(side);
        Side = side;
    }

    /// <summary>
    /// Obtiene el nombre legible de la figura.
    /// </summary>
    public string Name => "Cuadrado";

    /// <summary>
    /// Obtiene la longitud del lado del cuadrado.
    /// </summary>
    public double Side { get; }

    /// <summary>
    /// Calcula el área y el perímetro del cuadrado.
    /// </summary>
    /// <returns>Devuelve las magnitudes aplicables al cuadrado.</returns>
    public IReadOnlyList<FigureMeasurement> GetMeasurements() =>
    [
        new(MeasurementType.Area, "Área", Side * Side),
        new(MeasurementType.Perimeter, "Perímetro", 4 * Side)
    ];
}
