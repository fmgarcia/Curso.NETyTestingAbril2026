using CalculoFigurasGeometricas.Abstractions;
using CalculoFigurasGeometricas.Models;

namespace CalculoFigurasGeometricas.Domain.Figures;

/// <summary>
/// Representa un cubo y calcula su área superficial y su volumen a partir del lado.
/// </summary>
public sealed class Cube : IGeometricFigure
{
    /// <summary>
    /// Inicializa un cubo validando el valor del lado recibido.
    /// </summary>
    /// <param name="side">Longitud del lado del cubo.</param>
    public Cube(double side)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(side);
        Side = side;
    }

    /// <summary>
    /// Obtiene el nombre legible de la figura.
    /// </summary>
    public string Name => "Cubo";

    /// <summary>
    /// Obtiene la longitud del lado del cubo.
    /// </summary>
    public double Side { get; }

    /// <summary>
    /// Calcula el área superficial y el volumen del cubo.
    /// </summary>
    /// <returns>Devuelve las magnitudes aplicables al cubo.</returns>
    public IReadOnlyList<FigureMeasurement> GetMeasurements() =>
    [
        new(MeasurementType.Area, "Área superficial", 6 * Side * Side),
        new(MeasurementType.Volume, "Volumen", Side * Side * Side)
    ];
}
