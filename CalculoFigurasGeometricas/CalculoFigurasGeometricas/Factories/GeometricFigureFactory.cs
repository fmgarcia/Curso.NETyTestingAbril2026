using CalculoFigurasGeometricas.Abstractions;
using CalculoFigurasGeometricas.Domain.Figures;
using CalculoFigurasGeometricas.Models;

namespace CalculoFigurasGeometricas.Factories;

/// <summary>
/// Construye instancias de figuras geométricas a partir de la selección del usuario y de los datos solicitados.
/// </summary>
public sealed class GeometricFigureFactory
{
    /// <summary>
    /// Crea la figura seleccionada pidiendo únicamente los datos necesarios para su cálculo.
    /// </summary>
    /// <param name="selection">Opción de figura escogida por el usuario.</param>
    /// <param name="interactionService">Servicio utilizado para solicitar datos adicionales por pantalla.</param>
    /// <returns>Devuelve la figura completamente inicializada.</returns>
    public IGeometricFigure Create(FigureSelection selection, IUserInteractionService interactionService) =>
        selection switch
        {
            FigureSelection.Circle => CreateCircle(interactionService),
            FigureSelection.Rectangle => CreateRectangle(interactionService),
            FigureSelection.Square => CreateSquare(interactionService),
            FigureSelection.Triangle => CreateTriangle(interactionService),
            FigureSelection.Sphere => CreateSphere(interactionService),
            FigureSelection.Cube => CreateCube(interactionService),
            FigureSelection.Cylinder => CreateCylinder(interactionService),
            FigureSelection.Exit => throw new InvalidOperationException("No se puede crear una figura cuando la opción es salir."),
            _ => throw new ArgumentOutOfRangeException(nameof(selection), selection, "La figura seleccionada no está soportada.")
        };

    /// <summary>
    /// Solicita el radio y crea un círculo.
    /// </summary>
    /// <param name="interactionService">Servicio de interacción con el usuario.</param>
    /// <returns>Devuelve un círculo con los datos introducidos.</returns>
    private static Circle CreateCircle(IUserInteractionService interactionService)
    {
        var radius = interactionService.ReadPositiveNumber("Introduce el radio del círculo: ");
        return new Circle(radius);
    }

    /// <summary>
    /// Solicita la base y la altura y crea un rectángulo.
    /// </summary>
    /// <param name="interactionService">Servicio de interacción con el usuario.</param>
    /// <returns>Devuelve un rectángulo con los datos introducidos.</returns>
    private static Rectangle CreateRectangle(IUserInteractionService interactionService)
    {
        var width = interactionService.ReadPositiveNumber("Introduce la base del rectángulo: ");
        var height = interactionService.ReadPositiveNumber("Introduce la altura del rectángulo: ");
        return new Rectangle(width, height);
    }

    /// <summary>
    /// Solicita el lado y crea un cuadrado.
    /// </summary>
    /// <param name="interactionService">Servicio de interacción con el usuario.</param>
    /// <returns>Devuelve un cuadrado con los datos introducidos.</returns>
    private static Square CreateSquare(IUserInteractionService interactionService)
    {
        var side = interactionService.ReadPositiveNumber("Introduce el lado del cuadrado: ");
        return new Square(side);
    }

    /// <summary>
    /// Solicita los datos del triángulo y lo crea validando que sea geométricamente correcto.
    /// </summary>
    /// <param name="interactionService">Servicio de interacción con el usuario.</param>
    /// <returns>Devuelve un triángulo válido con los datos introducidos.</returns>
    private static Triangle CreateTriangle(IUserInteractionService interactionService)
    {
        while (true)
        {
            var baseLength = interactionService.ReadPositiveNumber("Introduce la base del triángulo: ");
            var sideB = interactionService.ReadPositiveNumber("Introduce el segundo lado del triángulo: ");
            var sideC = interactionService.ReadPositiveNumber("Introduce el tercer lado del triángulo: ");
            var height = interactionService.ReadPositiveNumber("Introduce la altura asociada a la base: ");

            try
            {
                return new Triangle(baseLength, sideB, sideC, height);
            }
            catch (ArgumentException exception) when (exception.ParamName is null)
            {
                interactionService.ShowMessage($"{exception.Message} Vuelve a introducir los datos.");
            }
        }
    }

    /// <summary>
    /// Solicita el radio y crea una esfera.
    /// </summary>
    /// <param name="interactionService">Servicio de interacción con el usuario.</param>
    /// <returns>Devuelve una esfera con los datos introducidos.</returns>
    private static Sphere CreateSphere(IUserInteractionService interactionService)
    {
        var radius = interactionService.ReadPositiveNumber("Introduce el radio de la esfera: ");
        return new Sphere(radius);
    }

    /// <summary>
    /// Solicita el lado y crea un cubo.
    /// </summary>
    /// <param name="interactionService">Servicio de interacción con el usuario.</param>
    /// <returns>Devuelve un cubo con los datos introducidos.</returns>
    private static Cube CreateCube(IUserInteractionService interactionService)
    {
        var side = interactionService.ReadPositiveNumber("Introduce el lado del cubo: ");
        return new Cube(side);
    }

    /// <summary>
    /// Solicita el radio y la altura y crea un cilindro.
    /// </summary>
    /// <param name="interactionService">Servicio de interacción con el usuario.</param>
    /// <returns>Devuelve un cilindro con los datos introducidos.</returns>
    private static Cylinder CreateCylinder(IUserInteractionService interactionService)
    {
        var radius = interactionService.ReadPositiveNumber("Introduce el radio del cilindro: ");
        var height = interactionService.ReadPositiveNumber("Introduce la altura del cilindro: ");
        return new Cylinder(radius, height);
    }
}
