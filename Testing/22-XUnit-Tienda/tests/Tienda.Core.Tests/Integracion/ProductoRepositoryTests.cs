using Tienda.Core;
using Tienda.Core.Tests.Fixtures;

namespace Tienda.Core.Tests.Integracion;

public class ProductoRepositoryTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;

    public ProductoRepositoryTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ObtenerTodosAsync_DevuelveProductos()
    {
        List<Producto> productos = await _fixture.Repository.ObtenerTodosAsync();

        Assert.NotNull(productos);
        Assert.NotEmpty(productos);
    }
}
