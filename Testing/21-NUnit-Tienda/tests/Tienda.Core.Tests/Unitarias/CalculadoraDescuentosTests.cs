using Tienda.Core;

namespace Tienda.Core.Tests.Unitarias;

[TestFixture]
[Category("Unitarias")]
public class CalculadoraDescuentosTests
{
    [Test]
    public void AplicarDescuento_ConPrecio100YDescuento10_Devuelve90()
    {
        CalculadoraDescuentos calculadora = new();

        decimal resultado = calculadora.AplicarDescuento(100m, 10m);

        Assert.That(resultado, Is.EqualTo(90m));
    }

    [Test]
    public void AplicarDescuento_ConPrecioNegativo_LanzaExcepcion()
    {
        CalculadoraDescuentos calculadora = new();

        Assert.That(
            () => calculadora.AplicarDescuento(-1m, 10m),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(100, 0, 100)]
    [TestCase(100, 10, 90)]
    [TestCase(200, 25, 150)]
    [TestCase(50, 50, 25)]
    public void AplicarDescuento_CasosValidos_DevuelveResultado(
        decimal precio,
        decimal descuento,
        decimal esperado)
    {
        CalculadoraDescuentos calculadora = new();

        decimal resultado = calculadora.AplicarDescuento(precio, descuento);

        Assert.That(resultado, Is.EqualTo(esperado));
    }

    public static IEnumerable<TestCaseData> CasosDeDescuento()
    {
        yield return new TestCaseData(100m, 15m, 85m).SetName("Descuento del 15%");
        yield return new TestCaseData(80m, 25m, 60m).SetName("Descuento del 25%");
    }

    [TestCaseSource(nameof(CasosDeDescuento))]
    public void AplicarDescuento_ConFuenteDeDatos(decimal precio, decimal descuento, decimal esperado)
    {
        CalculadoraDescuentos calculadora = new();

        Assert.That(calculadora.AplicarDescuento(precio, descuento), Is.EqualTo(esperado));
    }
}
