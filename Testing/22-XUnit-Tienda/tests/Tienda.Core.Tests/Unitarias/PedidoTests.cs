namespace Tienda.Core.Tests.Unitarias;

public class PedidoTests
{
    private readonly ITestOutputHelper _output;

    public PedidoTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void CrearPedido_MuestraDiagnostico()
    {
        _output.WriteLine("Creando pedido de prueba...");

        Assert.True(true);
    }
}
