using Tienda.Core;

namespace Tienda.Core.Tests.Fixtures;

public class DatabaseFixture : IAsyncLifetime
{
    public ProductoRepository Repository { get; private set; } = null!;

    public async ValueTask InitializeAsync()
    {
        Repository = await ProductoRepository.CrearParaTestsAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await Repository.DisposeAsync();
    }
}
