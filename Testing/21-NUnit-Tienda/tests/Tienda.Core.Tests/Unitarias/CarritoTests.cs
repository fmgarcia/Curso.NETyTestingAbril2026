using Tienda.Core;

namespace Tienda.Core.Tests.Unitarias;

[TestFixture]
[Category("Unitarias")]
public class CarritoTests
{
    private Carrito _carrito = null!;

    [OneTimeSetUp]
    public void AntesDeTodas()
    {
        TestContext.Out.WriteLine("Se ejecuta una vez antes de la clase");
    }

    [SetUp]
    public void AntesDeCadaTest()
    {
        _carrito = new Carrito();
    }

    [TearDown]
    public void DespuesDeCadaTest()
    {
        _carrito.Limpiar();
    }

    [OneTimeTearDown]
    public void DespuesDeTodas()
    {
        TestContext.Out.WriteLine("Se ejecuta una vez al final");
    }

    [Test]
    public void Carrito_Nuevo_EstaVacio()
    {
        Assert.That(_carrito.TotalItems, Is.EqualTo(0));
    }

    [Test]
    public void Agregar_UnProducto_AumentaTotalItems()
    {
        _carrito.Agregar(new Producto { Nombre = "Teclado", Precio = 89.99m, Stock = 12 });

        Assert.Multiple(() =>
        {
            Assert.That(_carrito.TotalItems, Is.EqualTo(1));
            Assert.That(_carrito.EstaVacio, Is.False);
            Assert.That(_carrito.Productos, Has.Some.Matches<Producto>(p => p.Stock == 12));
        });
    }
}
