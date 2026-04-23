using CalculoFigurasGeometricas.Abstractions;
using CalculoFigurasGeometricas.Models;

namespace CalculoFigurasGeometricas.Domain.Figures;

/// <summary>
/// Representa un triángulo y calcula su área y su perímetro a partir de sus lados y su altura.
/// </summary>
public sealed class Triangle : IGeometricFigure
{
    /// <summary>
    /// Inicializa un triángulo validando sus dimensiones y la desigualdad triangular.
    /// </summary>
    /// <param name="baseLength">Longitud de la base del triángulo.</param>
    /// <param name="sideB">Longitud del segundo lado del triángulo.</param>
    /// <param name="sideC">Longitud del tercer lado del triángulo.</param>
    /// <param name="height">Altura asociada a la base del triángulo.</param>
    public Triangle(double baseLength, double sideB, double sideC, double height)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(baseLength);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sideB);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sideC);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(height);

        if (baseLength + sideB <= sideC || baseLength + sideC <= sideB || sideB + sideC <= baseLength)
        {
            throw new ArgumentException("Los lados introducidos no pueden formar un triángulo válido.");
        }

        BaseLength = baseLength;
        SideB = sideB;
        SideC = sideC;
        Height = height;
    }

    /// <summary>
    /// Obtiene el nombre legible de la figura.
    /// </summary>
    public string Name => "Triángulo";

    /// <summary>
    /// Obtiene la base del triángulo.
    /// </summary>
    public double BaseLength { get; }

    /// <summary>
    /// Obtiene la longitud del segundo lado del triángulo.
    /// </summary>
    public double SideB { get; }

    /// <summary>
    /// Obtiene la longitud del tercer lado del triángulo.
    /// </summary>
    public double SideC { get; }

    /// <summary>
    /// Obtiene la altura asociada a la base del triángulo.
    /// </summary>
    public double Height { get; }

    /// <summary>
    /// Calcula el área y el perímetro del triángulo.
    /// </summary>
    /// <returns>Devuelve las magnitudes aplicables al triángulo.</returns>
    public IReadOnlyList<FigureMeasurement> GetMeasurements() =>
    [
        new(MeasurementType.Area, "Área", BaseLength * Height / 2),
        new(MeasurementType.Perimeter, "Perímetro", BaseLength + SideB + SideC)
    ];
}
