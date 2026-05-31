using Tienda.Core;

namespace Tienda.Core.Tests.Unitarias;

[TestFixture]
[Category("Unitarias")]
public class PedidoServiceTests
{
    [Test]
    public async Task ConfirmarPedidoAsync_EnviaEmailAlCliente()
    {
        FakeEmailSender fake = new();
        PedidoService service = new(fake);

        await service.ConfirmarPedidoAsync("ana@ejemplo.com");

        Assert.That(fake.Destinatarios, Contains.Item("ana@ejemplo.com"));
    }

    private sealed class FakeEmailSender : IEmailSender
    {
        public List<string> Destinatarios { get; } = [];

        public Task EnviarAsync(string destino, string asunto, string cuerpo)
        {
            Destinatarios.Add(destino);
            return Task.CompletedTask;
        }
    }
}
