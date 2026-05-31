using Tienda.Core;

namespace Tienda.Core.Tests.Unitarias;

public class PromocionServiceTests
{
    [Fact]
    public void EstaActiva_CuandoEsViernes_DevuelveTrue()
    {
        FakeClock clock = new()
        {
            UtcNow = new DateTime(2026, 5, 29)
        };

        PromocionService service = new(clock);

        Assert.True(service.EstaActiva());
    }

    [Fact]
    public async Task ProcesarAsync_IdInvalido_LanzaExcepcion()
    {
        PedidoProcessor service = new();

        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            await service.ProcesarAsync(-1);
        });
    }
}
