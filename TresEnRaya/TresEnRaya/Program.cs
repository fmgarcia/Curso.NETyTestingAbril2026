using TresEnRaya.Servicios;

namespace TresEnRaya;

/// <summary>
/// Contiene el punto de entrada de la aplicación de consola.
/// </summary>
public static class Program
{
    /// <summary>
    /// Crea la instancia principal del juego y lanza su ejecución.
    /// </summary>
    public static void Main()
    {
        var juego = new JuegoTresEnRaya();
        juego.Ejecutar();
    }
}
