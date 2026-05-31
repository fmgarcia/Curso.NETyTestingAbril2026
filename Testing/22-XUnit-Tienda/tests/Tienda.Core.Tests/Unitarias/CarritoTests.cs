using Tienda.Core;

namespace Tienda.Core.Tests.Unitarias;

public class CarritoTests : IDisposable
{
    private readonly Carrito _carrito;

    public CarritoTests()
    {
        _carrito = new Carrito();
    }

    [Fact]
    public void Carrito_Nuevo_EstaVacio()
    {
        Assert.Equal(0, _carrito.TotalItems);
        Assert.True(_carrito.EstaVacio);
    }

    [Fact]
    public void Agregar_Producto_DejaDeEstarVacio()
    {
        _carrito.Agregar(new Producto("Teclado", 89.99m));

        Assert.False(_carrito.EstaVacio);
    }

    public void Dispose()
    {
        _carrito.Limpiar();
    }
}
