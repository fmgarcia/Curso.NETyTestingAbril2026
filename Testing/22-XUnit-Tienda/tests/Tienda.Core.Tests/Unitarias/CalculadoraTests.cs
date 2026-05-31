using Tienda.Core;

namespace Tienda.Core.Tests.Unitarias;

public class CalculadoraTests
{
    [Fact]
    public void Sumar_DosNumeros_DevuelveSuma()
    {
        Calculadora calculadora = new();

        int resultado = calculadora.Sumar(2, 3);

        Assert.Equal(5, resultado);
    }

    [Fact]
    public void Dividir_EntreCero_LanzaExcepcion()
    {
        Calculadora calculadora = new();

        Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(10, 0));
    }

    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(-2, 2, 0)]
    [InlineData(10, 15, 25)]
    public void Sumar_VariosCasos_DevuelveSuma(int a, int b, int esperado)
    {
        Calculadora calculadora = new();

        int resultado = calculadora.Sumar(a, b);

        Assert.Equal(esperado, resultado);
    }
}
