using Microsoft.Data.Sqlite;
using Tienda.Core;

namespace Tienda.Core.Tests.Integracion;

[TestFixture]
[Category("Integracion")]
public class ProductoRepositoryTests
{
    private SqliteConnection _connection = null!;
    private ProductoRepository _repository = null!;

    [SetUp]
    public async Task SetUp()
    {
        _connection = new SqliteConnection("Data Source=:memory:");
        await _connection.OpenAsync();

        _repository = new ProductoRepository(_connection);
        await _repository.InicializarAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        await _connection.DisposeAsync();
    }

    [Test]
    public async Task CrearAsync_GuardaProducto()
    {
        int id = await _repository.CrearAsync(new Producto
        {
            Nombre = "Monitor",
            Categoria = "Pantallas",
            Precio = 199.99m,
            Stock = 5,
            FechaCreacion = DateTime.UtcNow
        });

        Producto? producto = await _repository.ObtenerPorIdAsync(id);

        Assert.That(producto, Is.Not.Null);
        Assert.That(producto!.Nombre, Is.EqualTo("Monitor"));
    }
}
