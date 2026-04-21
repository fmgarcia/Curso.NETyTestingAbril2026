namespace TresEnRaya.Modelos;

/// <summary>
/// Representa el contenido posible de una casilla del tablero.
/// </summary>
/// <remarks>
/// Se usa un <see langword="enum"/> porque el conjunto de valores válidos es pequeño,
/// conocido de antemano y no debe cambiar durante la ejecución.
/// </remarks>
public enum MarcaCasilla
{
    /// <summary>
    /// La casilla todavía no tiene ninguna ficha.
    /// </summary>
    Vacia,

    /// <summary>
    /// La casilla está ocupada por el jugador que usa la marca X.
    /// </summary>
    X,

    /// <summary>
    /// La casilla está ocupada por el jugador que usa la marca O.
    /// </summary>
    O
}
