// ============================================================
// Clase: Calculadora
// Descripción: Contiene las operaciones matemáticas básicas.
// Esta clase es el "núcleo" de la calculadora. Separar la
// lógica de negocio de la interfaz de usuario es una buena
// práctica conocida como Separación de Responsabilidades (SoC).
// ============================================================

namespace CalculadoraBasica;

/// <summary>
/// Proporciona las operaciones aritméticas básicas:
/// suma, resta, multiplicación y división.
/// </summary>
public class Calculadora
{
    // ----------------------------------------------------------
    // SUMA
    // Recibe dos números de tipo double y devuelve su suma.
    // El tipo double permite trabajar con decimales.
    // ----------------------------------------------------------

    /// <summary>
    /// Suma dos números y devuelve el resultado.
    /// </summary>
    /// <param name="a">Primer operando.</param>
    /// <param name="b">Segundo operando.</param>
    /// <returns>La suma de a y b.</returns>
    public double Sumar(double a, double b)
    {
        // Operación aritmética de adición
        return a + b;
    }

    // ----------------------------------------------------------
    // RESTA
    // Recibe dos números y devuelve la diferencia entre ellos.
    // ----------------------------------------------------------

    /// <summary>
    /// Resta el segundo número al primero y devuelve el resultado.
    /// </summary>
    /// <param name="a">Minuendo (número al que se resta).</param>
    /// <param name="b">Sustraendo (número que se resta).</param>
    /// <returns>La diferencia de a menos b.</returns>
    public double Restar(double a, double b)
    {
        // Operación aritmética de sustracción
        return a - b;
    }

    // ----------------------------------------------------------
    // MULTIPLICACIÓN
    // Devuelve el producto de dos números.
    // ----------------------------------------------------------

    /// <summary>
    /// Multiplica dos números y devuelve el resultado.
    /// </summary>
    /// <param name="a">Primer factor.</param>
    /// <param name="b">Segundo factor.</param>
    /// <returns>El producto de a por b.</returns>
    public double Multiplicar(double a, double b)
    {
        // Operación aritmética de multiplicación
        return a * b;
    }

    // ----------------------------------------------------------
    // DIVISIÓN
    // La división requiere una validación especial: no se puede
    // dividir entre cero. Si el divisor es 0, lanzamos una
    // excepción de tipo DivideByZeroException para avisar al
    // código que llamó a este método del error.
    // ----------------------------------------------------------

    /// <summary>
    /// Divide el primer número entre el segundo y devuelve el resultado.
    /// </summary>
    /// <param name="a">Dividendo.</param>
    /// <param name="b">Divisor (no puede ser cero).</param>
    /// <returns>El cociente de a entre b.</returns>
    /// <exception cref="DivideByZeroException">
    /// Se lanza cuando el divisor b es igual a cero.
    /// </exception>
    public double Dividir(double a, double b)
    {
        // Comprobamos si el divisor es cero antes de operar
        if (b == 0)
        {
            // Lanzamos una excepción con un mensaje descriptivo
            throw new DivideByZeroException("Error: no se puede dividir entre cero.");
        }

        // Si el divisor es válido, realizamos la división
        return a / b;
    }
}
