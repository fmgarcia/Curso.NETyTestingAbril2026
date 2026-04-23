namespace CalculoFigurasGeometricas.Models;

/// <summary>
/// Representa los tipos de magnitudes geométricas que el programa puede calcular.
/// </summary>
public enum MeasurementType
{
    /// <summary>
    /// Representa un área plana o un área superficial.
    /// </summary>
    Area,

    /// <summary>
    /// Representa el perímetro de una figura plana.
    /// </summary>
    Perimeter,

    /// <summary>
    /// Representa la longitud de una circunferencia.
    /// </summary>
    Circumference,

    /// <summary>
    /// Representa el volumen de una figura tridimensional.
    /// </summary>
    Volume
}
