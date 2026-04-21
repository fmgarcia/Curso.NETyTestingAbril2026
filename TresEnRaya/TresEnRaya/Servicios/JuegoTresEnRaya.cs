using TresEnRaya.Modelos;
using TresEnRaya.UI;

namespace TresEnRaya.Servicios;

/// <summary>
/// Orquesta el flujo completo de una partida de tres en raya.
/// </summary>
/// <remarks>
/// Esta clase actúa como coordinadora: utiliza el tablero para aplicar reglas,
/// el lector para obtener datos y el renderizador para mostrar resultados.
/// </remarks>
public sealed class JuegoTresEnRaya
{
    private readonly Tablero tablero = new();
    private readonly ConsolaRenderer renderer = new();
    private readonly LectorConsola lector = new();

    private Jugador jugadorX = null!;
    private Jugador jugadorO = null!;

    /// <summary>
    /// Ejecuta el ciclo principal del programa.
    /// </summary>
    public void Ejecutar()
    {
        renderer.MostrarBienvenida();
        ConfigurarJugadores();

        while (true)
        {
            bool partidaReiniciada = JugarPartida();

            if (partidaReiniciada)
            {
                continue;
            }

            if (!lector.SolicitarNuevaPartida())
            {
                break;
            }
        }

        renderer.MostrarDespedida();
    }

    private void ConfigurarJugadores()
    {
        string nombreJugadorX = lector.SolicitarNombreJugador("X");
        string nombreJugadorO = lector.SolicitarNombreJugador("O");

        jugadorX = new Jugador(nombreJugadorX, MarcaCasilla.X);
        jugadorO = new Jugador(nombreJugadorO, MarcaCasilla.O);
    }

    private bool JugarPartida()
    {
        tablero.Reiniciar();
        Jugador jugadorActual = jugadorX;

        while (true)
        {
            renderer.MostrarTablero(tablero);
            renderer.MostrarTurnoActual(jugadorActual);

            if (!lector.IntentarSolicitarPosicion(tablero, jugadorActual, out Posicion posicionElegida))
            {
                renderer.MostrarReinicioPartida();
                return true;
            }

            bool jugadaAplicada = tablero.IntentarColocarMarca(posicionElegida, jugadorActual.Marca);

            // Esta comprobación es redundante en condiciones normales porque la entrada ya se valida,
            // pero se mantiene para reforzar la robustez y mostrar una capa extra de seguridad.
            if (!jugadaAplicada)
            {
                renderer.MostrarAviso("No se ha podido aplicar la jugada. Inténtalo de nuevo.");
                continue;
            }

            EstadoPartida estadoActual = tablero.ObtenerEstadoPartida();

            if (estadoActual == EstadoPartida.Victoria)
            {
                renderer.MostrarTablero(tablero);
                renderer.MostrarVictoria(jugadorActual);
                return false;
            }

            if (estadoActual == EstadoPartida.Empate)
            {
                renderer.MostrarTablero(tablero);
                renderer.MostrarEmpate();
                return false;
            }

            jugadorActual = ObtenerSiguienteJugador(jugadorActual);
        }
    }

    private Jugador ObtenerSiguienteJugador(Jugador jugadorActual)
    {
        return ReferenceEquals(jugadorActual, jugadorX) ? jugadorO : jugadorX;
    }
}
