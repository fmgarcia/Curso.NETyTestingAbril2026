using CalculoFigurasGeometricas.Abstractions;
using CalculoFigurasGeometricas.Models;

namespace CalculoFigurasGeometricas.Domain.Figures;

/// <summary>
/// Representa un cilindro y calcula su área superficial, la circunferencia de su base y su volumen.
/// </summary>
public sealed class Cylinder : IGeometricFigure
{
    /// <summary>
    /// Inicializa un cilindro validando el radio y la altura recibidos.
    /// </summary>
    /// <param name="radius">Radio de la base del cilindro.</param>
    /// <param name="height">Altura del cilindro.</param>
    public Cylinder(double radius, double height)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(radius);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(height);

        Radius = radius;
        Height = height;
    }

    /// <summary>
    /// Obtiene el nombre legible de la figura.
    /// </summary>
    public string Name => "Cilindro";

    /// <summary>
    /// Obtiene el radio de la base del cilindro.
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Obtiene la altura del cilindro.
    /// </summary>
    public double Height { get; }

    /// <summary>
    /// Calcula el área superficial, la circunferencia de la base y el volumen del cilindro.
    /// </summary>
    /// <returns>Devuelve las magnitudes aplicables al cilindro.</returns>
    public IReadOnlyList<FigureMeasurement> GetMeasurements() =>
    [
        new(MeasurementType.Area, "Área superficial", 2 * Math.PI * Radius * (Radius + Height)),
        new(MeasurementType.Circumference, "Circunferencia de la base", 2 * Math.PI * Radius),
        new(MeasurementType.Volume, "Volumen", Math.PI * Radius * Radius * Height)
    ];
}
