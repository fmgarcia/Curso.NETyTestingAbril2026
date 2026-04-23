using CalculoFigurasGeometricas.Abstractions;
using CalculoFigurasGeometricas.Models;

namespace CalculoFigurasGeometricas.Domain.Figures;

/// <summary>
/// Representa una esfera y calcula su área superficial y su volumen a partir del radio.
/// </summary>
public sealed class Sphere : IGeometricFigure
{
    /// <summary>
    /// Inicializa una esfera validando el radio recibido.
    /// </summary>
    /// <param name="radius">Radio de la esfera.</param>
    public Sphere(double radius)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(radius);
        Radius = radius;
    }

    /// <summary>
    /// Obtiene el nombre legible de la figura.
    /// </summary>
    public string Name => "Esfera";

    /// <summary>
    /// Obtiene el radio de la esfera.
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Calcula el área superficial y el volumen de la esfera.
    /// </summary>
    /// <returns>Devuelve las magnitudes aplicables a la esfera.</returns>
    public IReadOnlyList<FigureMeasurement> GetMeasurements() =>
    [
        new(MeasurementType.Area, "Área superficial", 4 * Math.PI * Radius * Radius),
        new(MeasurementType.Volume, "Volumen", 4d / 3d * Math.PI * Radius * Radius * Radius)
    ];
}
