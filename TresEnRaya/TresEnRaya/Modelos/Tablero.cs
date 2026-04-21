namespace TresEnRaya.Modelos;

/// <summary>
/// Representa el tablero del tres en raya y concentra todas las reglas relacionadas con sus casillas.
/// </summary>
/// <remarks>
/// Esta clase no sabe nada de la consola ni de cómo se muestran los datos al usuario.
/// Su única responsabilidad es gestionar el estado del tablero y responder preguntas sobre él.
/// </remarks>
public sealed class Tablero
{
    /// <summary>
    /// Dimensión fija del tablero. En tres en raya clásico siempre es 3x3.
    /// </summary>
    public const int Dimension = 3;

    private readonly MarcaCasilla[,] casillas = new MarcaCasilla[Dimension, Dimension];

    /// <summary>
    /// Crea un tablero nuevo y lo deja vacío.
    /// </summary>
    public Tablero()
    {
        Reiniciar();
    }

    /// <summary>
    /// Limpia todas las casillas para iniciar una nueva partida.
    /// </summary>
    public void Reiniciar()
    {
        for (int fila = 0; fila < Dimension; fila++)
        {
            for (int columna = 0; columna < Dimension; columna++)
            {
                casillas[fila, columna] = MarcaCasilla.Vacia;
            }
        }
    }

    /// <summary>
    /// Devuelve la marca almacenada en una posición concreta.
    /// </summary>
    /// <param name="posicion">Coordenada que se quiere consultar.</param>
    /// <returns>Contenido actual de la casilla.</returns>
    public MarcaCasilla ObtenerMarca(Posicion posicion)
    {
        return casillas[posicion.Fila, posicion.Columna];
    }

    /// <summary>
    /// Comprueba si una posición pertenece al tablero.
    /// </summary>
    /// <param name="posicion">Posición a validar.</param>
    /// <returns><see langword="true"/> si la fila y la columna están dentro de rango; en caso contrario, <see langword="false"/>.</returns>
    public bool PosicionEsValida(Posicion posicion)
    {
        return posicion.Fila >= 0
            && posicion.Fila < Dimension
            && posicion.Columna >= 0
            && posicion.Columna < Dimension;
    }

    /// <summary>
    /// Indica si una casilla concreta sigue disponible para jugar.
    /// </summary>
    /// <param name="posicion">Casilla que se desea comprobar.</param>
    /// <returns><see langword="true"/> si la casilla está vacía; en caso contrario, <see langword="false"/>.</returns>
    public bool CasillaEstaLibre(Posicion posicion)
    {
        return PosicionEsValida(posicion) && ObtenerMarca(posicion) == MarcaCasilla.Vacia;
    }

    /// <summary>
    /// Intenta colocar una marca sobre el tablero respetando las reglas básicas.
    /// </summary>
    /// <param name="posicion">Lugar donde se desea jugar.</param>
    /// <param name="marca">Ficha que se quiere colocar.</param>
    /// <returns>
    /// <see langword="true"/> si la jugada se ha aplicado correctamente;
    /// <see langword="false"/> si la posición no es válida o la casilla ya estaba ocupada.
    /// </returns>
    public bool IntentarColocarMarca(Posicion posicion, MarcaCasilla marca)
    {
        if (!CasillaEstaLibre(posicion))
        {
            return false;
        }

        casillas[posicion.Fila, posicion.Columna] = marca;
        return true;
    }

    /// <summary>
    /// Indica si todas las casillas del tablero están ocupadas.
    /// </summary>
    public bool EstaCompleto
    {
        get
        {
            for (int fila = 0; fila < Dimension; fila++)
            {
                for (int columna = 0; columna < Dimension; columna++)
                {
                    if (casillas[fila, columna] == MarcaCasilla.Vacia)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    /// <summary>
    /// Evalúa el tablero y devuelve el estado actual de la partida.
    /// </summary>
    public EstadoPartida ObtenerEstadoPartida()
    {
        if (HayGanador(out _))
        {
            return EstadoPartida.Victoria;
        }

        return EstaCompleto ? EstadoPartida.Empate : EstadoPartida.EnCurso;
    }

    /// <summary>
    /// Comprueba si existe una línea ganadora en el tablero.
    /// </summary>
    /// <param name="marcaGanadora">Devuelve la marca que ha ganado, si existe.</param>
    /// <returns><see langword="true"/> si alguna fila, columna o diagonal contiene tres marcas iguales y no vacías.</returns>
    public bool HayGanador(out MarcaCasilla marcaGanadora)
    {
        for (int fila = 0; fila < Dimension; fila++)
        {
            if (LasTresCasillasCoinciden(casillas[fila, 0], casillas[fila, 1], casillas[fila, 2], out marcaGanadora))
            {
                return true;
            }
        }

        for (int columna = 0; columna < Dimension; columna++)
        {
            if (LasTresCasillasCoinciden(casillas[0, columna], casillas[1, columna], casillas[2, columna], out marcaGanadora))
            {
                return true;
            }
        }

        if (LasTresCasillasCoinciden(casillas[0, 0], casillas[1, 1], casillas[2, 2], out marcaGanadora))
        {
            return true;
        }

        if (LasTresCasillasCoinciden(casillas[0, 2], casillas[1, 1], casillas[2, 0], out marcaGanadora))
        {
            return true;
        }

        marcaGanadora = MarcaCasilla.Vacia;
        return false;
    }

    /// <summary>
    /// Convierte un número de casilla visible para el usuario en coordenadas internas de matriz.
    /// </summary>
    /// <param name="numeroCasilla">Número entre 1 y 9.</param>
    /// <param name="posicion">Posición equivalente dentro del tablero.</param>
    /// <returns><see langword="true"/> si el número está en el rango correcto.</returns>
    public bool IntentarObtenerPosicionDesdeNumero(int numeroCasilla, out Posicion posicion)
    {
        if (numeroCasilla < 1 || numeroCasilla > Dimension * Dimension)
        {
            posicion = default;
            return false;
        }

        int indiceBaseCero = numeroCasilla - 1;
        int fila = indiceBaseCero / Dimension;
        int columna = indiceBaseCero % Dimension;

        posicion = new Posicion(fila, columna);
        return true;
    }

    /// <summary>
    /// Traduce una posición interna a un número de casilla más amigable para mostrar por consola.
    /// </summary>
    /// <param name="posicion">Coordenada del tablero.</param>
    /// <returns>Número entre 1 y 9.</returns>
    public int ObtenerNumeroDeCasilla(Posicion posicion)
    {
        return (posicion.Fila * Dimension) + posicion.Columna + 1;
    }

    private static bool LasTresCasillasCoinciden(
        MarcaCasilla primera,
        MarcaCasilla segunda,
        MarcaCasilla tercera,
        out MarcaCasilla marcaGanadora)
    {
        // Para que exista victoria, las tres casillas deben estar ocupadas y contener la misma marca.
        if (primera != MarcaCasilla.Vacia && primera == segunda && segunda == tercera)
        {
            marcaGanadora = primera;
            return true;
        }

        marcaGanadora = MarcaCasilla.Vacia;
        return false;
    }
}
