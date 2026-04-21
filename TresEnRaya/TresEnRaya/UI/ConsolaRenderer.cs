using TresEnRaya.Modelos;

namespace TresEnRaya.UI;

/// <summary>
/// Centraliza toda la salida visual del programa por consola.
/// </summary>
/// <remarks>
/// Separar la presentación de la lógica del juego facilita la comprensión del código,
/// la reutilización y futuras mejoras, como cambiar la consola por una interfaz gráfica.
/// </remarks>
public sealed class ConsolaRenderer
{
    /// <summary>
    /// Muestra el mensaje inicial del programa y unas instrucciones generales.
    /// </summary>
    public void MostrarBienvenida()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("        JUEGO DE TRES EN RAYA");
        Console.WriteLine("========================================");
        Console.WriteLine("Dos jugadores se turnan para colocar X y O.");
        Console.WriteLine("Gana quien complete una fila, columna o diagonal.");
        Console.WriteLine("Durante un turno puedes escribir R para interrumpir la partida y empezar otra nueva.");
        Console.WriteLine();
    }

    /// <summary>
    /// Dibuja el tablero actual en pantalla.
    /// </summary>
    /// <param name="tablero">Tablero que se desea representar.</param>
    public void MostrarTablero(Tablero tablero)
    {
        Console.WriteLine();
        Console.WriteLine("Tablero actual:");

        for (int fila = 0; fila < Tablero.Dimension; fila++)
        {
            Console.Write(" ");

            for (int columna = 0; columna < Tablero.Dimension; columna++)
            {
                var posicion = new Posicion(fila, columna);
                string contenido = ObtenerTextoDeCasilla(tablero, posicion);
                Console.Write($" {contenido} ");

                if (columna < Tablero.Dimension - 1)
                {
                    Console.Write("|");
                }
            }

            Console.WriteLine();

            if (fila < Tablero.Dimension - 1)
            {
                Console.WriteLine("---+---+---");
            }
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Informa de quién debe jugar el siguiente turno.
    /// </summary>
    /// <param name="jugador">Jugador que tiene el turno.</param>
    public void MostrarTurnoActual(Jugador jugador)
    {
        Console.WriteLine($"Turno de {jugador.Nombre} ({jugador.Marca}).");
    }

    /// <summary>
    /// Muestra un mensaje de error o aviso al usuario.
    /// </summary>
    /// <param name="mensaje">Texto que se desea enseñar.</param>
    public void MostrarAviso(string mensaje)
    {
        Console.WriteLine($"Aviso: {mensaje}");
    }

    /// <summary>
    /// Anuncia el ganador de la partida.
    /// </summary>
    /// <param name="jugadorGanador">Jugador que ha conseguido la victoria.</param>
    public void MostrarVictoria(Jugador jugadorGanador)
    {
        Console.WriteLine($"¡Enhorabuena, {jugadorGanador.Nombre}! Has ganado la partida.");
    }

    /// <summary>
    /// Informa de que la partida termina en empate.
    /// </summary>
    public void MostrarEmpate()
    {
        Console.WriteLine("La partida ha terminado en empate.");
    }

    /// <summary>
    /// Informa de que la partida en curso se ha cancelado y se va a iniciar otra desde cero.
    /// </summary>
    public void MostrarReinicioPartida()
    {
        Console.WriteLine("La partida actual se ha interrumpido. Se va a comenzar una nueva.");
    }

    /// <summary>
    /// Muestra un mensaje final al salir del programa.
    /// </summary>
    public void MostrarDespedida()
    {
        Console.WriteLine();
        Console.WriteLine("Gracias por jugar. Fin del programa.");
    }

    private static string ObtenerTextoDeCasilla(Tablero tablero, Posicion posicion)
    {
        MarcaCasilla marca = tablero.ObtenerMarca(posicion);

        // Las casillas vacías muestran su número para que el jugador sepa qué debe escribir.
        return marca switch
        {
            MarcaCasilla.X => "X",
            MarcaCasilla.O => "O",
            _ => tablero.ObtenerNumeroDeCasilla(posicion).ToString()
        };
    }
}
