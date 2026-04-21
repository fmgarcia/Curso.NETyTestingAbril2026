namespace TresEnRaya.Modelos;

/// <summary>
/// Representa una coordenada del tablero mediante fila y columna.
/// </summary>
/// <param name="Fila">Índice de la fila, empezando en 0.</param>
/// <param name="Columna">Índice de la columna, empezando en 0.</param>
/// <remarks>
/// Se utiliza un <see langword="record struct"/> para tener un tipo ligero, inmutable y
/// expresivo, adecuado para transportar datos simples.
/// </remarks>
public readonly record struct Posicion(int Fila, int Columna);
