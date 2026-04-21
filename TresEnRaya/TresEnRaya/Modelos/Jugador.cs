namespace TresEnRaya.Modelos;

/// <summary>
/// Almacena la información básica de un participante de la partida.
/// </summary>
public sealed class Jugador
{
    /// <summary>
    /// Inicializa un nuevo jugador con su nombre visible y la marca que utilizará en el tablero.
    /// </summary>
    /// <param name="nombre">Nombre que se mostrará por consola.</param>
    /// <param name="marca">Ficha asignada al jugador.</param>
    public Jugador(string nombre, MarcaCasilla marca)
    {
        Nombre = nombre;
        Marca = marca;
    }

    /// <summary>
    /// Obtiene el nombre del jugador.
    /// </summary>
    public string Nombre { get; }

    /// <summary>
    /// Obtiene la marca que el jugador colocará en el tablero.
    /// </summary>
    public MarcaCasilla Marca { get; }
}
