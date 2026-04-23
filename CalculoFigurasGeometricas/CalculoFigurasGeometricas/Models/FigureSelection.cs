namespace CalculoFigurasGeometricas.Models;

/// <summary>
/// Enumera las opciones de figuras que el usuario puede seleccionar en el menú principal.
/// </summary>
public enum FigureSelection
{
    /// <summary>
    /// Finaliza la ejecución de la aplicación.
    /// </summary>
    Exit = 0,

    /// <summary>
    /// Selecciona el cálculo para un círculo.
    /// </summary>
    Circle = 1,

    /// <summary>
    /// Selecciona el cálculo para un rectángulo.
    /// </summary>
    Rectangle = 2,

    /// <summary>
    /// Selecciona el cálculo para un cuadrado.
    /// </summary>
    Square = 3,

    /// <summary>
    /// Selecciona el cálculo para un triángulo.
    /// </summary>
    Triangle = 4,

    /// <summary>
    /// Selecciona el cálculo para una esfera.
    /// </summary>
    Sphere = 5,

    /// <summary>
    /// Selecciona el cálculo para un cubo.
    /// </summary>
    Cube = 6,

    /// <summary>
    /// Selecciona el cálculo para un cilindro.
    /// </summary>
    Cylinder = 7
}
