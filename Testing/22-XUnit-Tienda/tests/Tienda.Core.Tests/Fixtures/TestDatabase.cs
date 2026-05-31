using Tienda.Core;

namespace Tienda.Core.Tests.Fixtures;

public sealed class TestDatabase : IAsyncDisposable
{
    public ProductoRepository Repository { get; private set; } = null!;

    public async Task InicializarAsync()
    {
        Repository = await ProductoRepository.CrearParaTestsAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await Repository.DisposeAsync();
    }
}
