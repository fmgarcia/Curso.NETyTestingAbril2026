using Tienda.Core;
using Tienda.Core.Tests.Fixtures;

namespace Tienda.Core.Tests.Integracion;

[Collection("BaseDatos")]
public class ProductosRepositoryCollectionTests
{
    private readonly DatabaseFixture _fixture;

    public ProductosRepositoryCollectionTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task CrearAsync_GuardaProducto()
    {
        int id = await _fixture.Repository.CrearAsync(new Producto("Teclado", 89.99m));

        Assert.True(id > 0);
    }
}
