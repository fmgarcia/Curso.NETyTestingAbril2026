namespace CalculoFigurasGeometricas.Models;

/// <summary>
/// Agrupa el nombre, el tipo y el valor de una magnitud calculada para una figura.
/// </summary>
/// <param name="Type">Indica la categoría de la magnitud calculada.</param>
/// <param name="Label">Describe de forma legible la magnitud que se mostrará al usuario.</param>
/// <param name="Value">Contiene el resultado numérico de la magnitud calculada.</param>
public readonly record struct FigureMeasurement(MeasurementType Type, string Label, double Value);
