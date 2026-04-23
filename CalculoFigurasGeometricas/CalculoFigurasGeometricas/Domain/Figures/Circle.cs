using CalculoFigurasGeometricas.Abstractions;
using CalculoFigurasGeometricas.Models;

namespace CalculoFigurasGeometricas.Domain.Figures;

/// <summary>
/// Representa un círculo y calcula su área y su circunferencia a partir del radio.
/// </summary>
public sealed class Circle : IGeometricFigure
{
    /// <summary>
    /// Inicializa un círculo validando el radio recibido.
    /// </summary>
    /// <param name="radius">Radio del círculo.</param>
    public Circle(double radius)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(radius);
        Radius = radius;
    }

    /// <summary>
    /// Obtiene el nombre legible de la figura.
    /// </summary>
    public string Name => "Círculo";

    /// <summary>
    /// Obtiene el radio del círculo.
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Calcula el área y la circunferencia del círculo.
    /// </summary>
    /// <returns>Devuelve las magnitudes aplicables al círculo.</returns>
    public IReadOnlyList<FigureMeasurement> GetMeasurements() =>
    [
        new(MeasurementType.Area, "Área", Math.PI * Radius * Radius),
        new(MeasurementType.Circumference, "Circunferencia", 2 * Math.PI * Radius)
    ];
}
