using CalculoFigurasGeometricas.Models;

namespace CalculoFigurasGeometricas.Abstractions;

/// <summary>
/// Define el contrato común que debe cumplir cualquier figura geométrica del sistema.
/// </summary>
public interface IGeometricFigure
{
    /// <summary>
    /// Obtiene el nombre legible de la figura para mostrarlo en la interfaz.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Calcula todas las magnitudes aplicables a la figura actual.
    /// </summary>
    /// <returns>Devuelve la colección de magnitudes que la figura puede ofrecer.</returns>
    IReadOnlyList<FigureMeasurement> GetMeasurements();
}
