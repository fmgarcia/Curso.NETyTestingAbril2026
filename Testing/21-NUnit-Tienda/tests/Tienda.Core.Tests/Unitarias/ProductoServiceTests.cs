using Tienda.Core;

namespace Tienda.Core.Tests.Unitarias;

[TestFixture]
[Category("Unitarias")]
public class ProductoServiceTests
{
    [Test]
    public async Task ObtenerPrecioAsync_ProductoExistente_DevuelvePrecio()
    {
        ProductoService service = new();

        decimal precio = await service.ObtenerPrecioAsync(1);

        Assert.That(precio, Is.EqualTo(89.99m));
    }

    [Test]
    public void ObtenerAsync_IdInvalido_LanzaExcepcion()
    {
        ProductoService service = new();

        Assert.That(
            async () => await service.ObtenerPrecioAsync(-1),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }
}
