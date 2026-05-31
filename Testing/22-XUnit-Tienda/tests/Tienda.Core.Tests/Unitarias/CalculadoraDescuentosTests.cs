using Tienda.Core;

namespace Tienda.Core.Tests.Unitarias;

public class CalculadoraDescuentosTests
{
    public static IEnumerable<object[]> CasosDescuento()
    {
        yield return new object[] { 100m, 10m, 90m };
        yield return new object[] { 200m, 25m, 150m };
        yield return new object[] { 80m, 0m, 80m };
    }

    [Theory]
    [MemberData(nameof(CasosDescuento))]
    public void AplicarDescuento_CasosValidos(decimal precio, decimal descuento, decimal esperado)
    {
        CalculadoraDescuentos calculadora = new();

        decimal resultado = calculadora.Aplicar(precio, descuento);

        Assert.Equal(esperado, resultado);
    }

    public record CasoDescuento(decimal Precio, decimal Descuento, decimal Esperado);

    public static IEnumerable<object[]> Casos()
    {
        yield return new object[] { new CasoDescuento(100m, 10m, 90m) };
    }

    [Theory]
    [MemberData(nameof(Casos))]
    public void AplicarDescuento_ConRecord(CasoDescuento caso)
    {
        CalculadoraDescuentos calculadora = new();

        Assert.Equal(caso.Esperado, calculadora.Aplicar(caso.Precio, caso.Descuento));
    }

    [Fact]
    public void AplicarDescuento_PrecioNegativo_LanzaExcepcionConNombreParametro()
    {
        CalculadoraDescuentos calculadora = new();

        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            calculadora.Aplicar(-1m, 10m);
        });

        Assert.Equal("precio", ex.ParamName);
    }
}
