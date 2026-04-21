using TresEnRaya.Modelos;

namespace TresEnRaya.UI;

/// <summary>
/// Encapsula toda la lectura de datos introducidos por el usuario desde la consola.
/// </summary>
public sealed class LectorConsola
{
    /// <summary>
    /// Solicita un nombre para uno de los jugadores y no permite devolver una cadena vacía.
    /// </summary>
    /// <param name="textoMarca">Texto informativo sobre la ficha asignada.</param>
    /// <returns>Nombre ya validado.</returns>
    public string SolicitarNombreJugador(string textoMarca)
    {
        while (true)
        {
            Console.Write($"Introduce el nombre del jugador con ficha {textoMarca}: ");
            string? nombre = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                return nombre.Trim();
            }

            Console.WriteLine("El nombre no puede estar vacío.");
        }
    }

    /// <summary>
    /// Pide al jugador una jugada válida sobre una casilla libre del tablero o una orden de reinicio.
    /// </summary>
    /// <param name="tablero">Tablero actual, necesario para validar la entrada.</param>
    /// <param name="jugador">Jugador que va a realizar la jugada.</param>
    /// <param name="posicion">
    /// Devuelve la posición elegida cuando el usuario introduce una jugada normal.
    /// Si el jugador solicita reiniciar la partida, este valor se devuelve sin uso.
    /// </param>
    /// <returns>
    /// <see langword="true"/> si el jugador ha elegido una casilla válida.
    /// <see langword="false"/> si ha pedido reiniciar la partida actual.
    /// </returns>
    public bool IntentarSolicitarPosicion(Tablero tablero, Jugador jugador, out Posicion posicion)
    {
        posicion = default;

        while (true)
        {
            Console.Write($"{jugador.Nombre}, elige una casilla libre (1-9) o escribe R para reiniciar: ");
            string? entrada = Console.ReadLine();

            if (string.Equals(entrada, "r", StringComparison.OrdinalIgnoreCase)
                || string.Equals(entrada, "reiniciar", StringComparison.OrdinalIgnoreCase))
            {
                posicion = default;
                return false;
            }

            if (!int.TryParse(entrada, out int numeroCasilla))
            {
                Console.WriteLine("Debes escribir un número entero o la letra 'R'.");
                continue;
            }

            if (!tablero.IntentarObtenerPosicionDesdeNumero(numeroCasilla, out Posicion posicionSeleccionada))
            {
                Console.WriteLine("La casilla debe estar entre 1 y 9.");
                continue;
            }

            if (!tablero.CasillaEstaLibre(posicionSeleccionada))
            {
                Console.WriteLine("Esa casilla ya está ocupada. Elige otra.");
                continue;
            }

            posicion = posicionSeleccionada;
            return true;
        }
    }

    /// <summary>
    /// Pregunta al usuario si quiere comenzar otra partida.
    /// </summary>
    /// <returns><see langword="true"/> si la respuesta es sí; en caso contrario, <see langword="false"/>.</returns>
    public bool SolicitarNuevaPartida()
    {
        while (true)
        {
            Console.Write("¿Quieres jugar otra partida? (s/n): ");
            string? respuesta = Console.ReadLine();

            if (string.Equals(respuesta, "s", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (string.Equals(respuesta, "n", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            Console.WriteLine("Respuesta no válida. Escribe 's' para sí o 'n' para no.");
        }
    }
}
