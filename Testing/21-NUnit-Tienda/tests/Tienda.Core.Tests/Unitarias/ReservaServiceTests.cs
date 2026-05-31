using Tienda.Core;
using Tienda.Core.Tests.TestData;

namespace Tienda.Core.Tests.Unitarias;

[TestFixture]
[Category("Unitarias")]
public class ReservaServiceTests
{
    [Test]
    public void Reservar_ProductoSinStock_LanzaExcepcion()
    {
        Producto producto = new ProductoBuilder().SinStock().Build();
        ReservaService service = new();

        Assert.That(
            () => service.Reservar(producto),
            Throws.TypeOf<InvalidOperationException>());
    }
}
