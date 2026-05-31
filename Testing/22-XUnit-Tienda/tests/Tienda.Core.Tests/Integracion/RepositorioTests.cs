using Tienda.Core;
using Tienda.Core.Tests.Fixtures;

namespace Tienda.Core.Tests.Integracion;

public class RepositorioTests : IAsyncLifetime
{
    private TestDatabase _database = null!;

    public async ValueTask InitializeAsync()
    {
        _database = new TestDatabase();
        await _database.InicializarAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await _database.DisposeAsync();
    }

    [Fact]
    public async Task CrearAsync_GuardaProducto()
    {
        int id = await _database.Repository.CrearAsync(new Producto("Teclado", 89.99m));

        Assert.True(id > 0);
    }
}
