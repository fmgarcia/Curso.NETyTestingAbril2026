namespace TresEnRaya.Modelos;

/// <summary>
/// Describe la situación global de una partida en un momento dado.
/// </summary>
public enum EstadoPartida
{
    /// <summary>
    /// La partida todavía no ha terminado y pueden seguir jugándose turnos.
    /// </summary>
    EnCurso,

    /// <summary>
    /// Uno de los jugadores ha completado una línea ganadora.
    /// </summary>
    Victoria,

    /// <summary>
    /// El tablero está lleno y nadie ha ganado.
    /// </summary>
    Empate
}
