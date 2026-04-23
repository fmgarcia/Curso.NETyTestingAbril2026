using CalculoFigurasGeometricas.Abstractions;
using CalculoFigurasGeometricas.Models;

namespace CalculoFigurasGeometricas.Domain.Figures;

/// <summary>
/// Representa un rectángulo y calcula su área y su perímetro a partir de la base y la altura.
/// </summary>
public sealed class Rectangle : IGeometricFigure
{
    /// <summary>
    /// Inicializa un rectángulo validando la base y la altura recibidas.
    /// </summary>
    /// <param name="width">Base del rectángulo.</param>
    /// <param name="height">Altura del rectángulo.</param>
    public Rectangle(double width, double height)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(width);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(height);

        Width = width;
        Height = height;
    }

    /// <summary>
    /// Obtiene el nombre legible de la figura.
    /// </summary>
    public string Name => "Rectángulo";

    /// <summary>
    /// Obtiene la base del rectángulo.
    /// </summary>
    public double Width { get; }

    /// <summary>
    /// Obtiene la altura del rectángulo.
    /// </summary>
    public double Height { get; }

    /// <summary>
    /// Calcula el área y el perímetro del rectángulo.
    /// </summary>
    /// <returns>Devuelve las magnitudes aplicables al rectángulo.</returns>
    public IReadOnlyList<FigureMeasurement> GetMeasurements() =>
    [
        new(MeasurementType.Area, "Área", Width * Height),
        new(MeasurementType.Perimeter, "Perímetro", 2 * (Width + Height))
    ];
}
