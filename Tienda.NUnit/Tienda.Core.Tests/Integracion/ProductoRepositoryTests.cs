using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Core;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;

namespace Tienda.Core.Tests.Integracion
{
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

            Assert.Multiple(() =>
            {
                Assert.That(producto, Is.Not.Null);
                Assert.That(producto!.Nombre, Is.EqualTo("Monitor"));
                Assert.That(producto.Categoria, Is.EqualTo("Pantallas"));
                Assert.That(producto.Stock, Is.EqualTo(5));
            });

        }


        [Test]
        public async Task ObtenerPorIdAsync_IdInexistente_DevuelveNull()
        {
            Producto? producto = await _repository.ObtenerPorIdAsync(999);

            Assert.That(producto, Is.Null);
        }

        [Test]
        public async Task ObtenerTodosAsync_ConProductos_DevuelveLista()
        {
            await _repository.CrearAsync(new Producto
            {
                Nombre = "Teclado",
                Categoria = "Perifericos",
                Precio = 89.99m,
                Stock = 10,
                FechaCreacion = DateTime.UtcNow
            });

            await _repository.CrearAsync(new Producto
            {
                Nombre = "Monitor",
                Categoria = "Pantallas",
                Precio = 199.99m,
                Stock = 5,
                FechaCreacion = DateTime.UtcNow
            });

            List<Producto> productos = await _repository.ObtenerTodosAsync();

            Assert.Multiple(() =>
            {
                Assert.That(productos, Has.Count.EqualTo(2));
                Assert.That(productos.Select(p => p.Nombre), Does.Contain("Teclado"));
                Assert.That(productos.Select(p => p.Nombre), Does.Contain("Monitor"));
            });
        }

    }
}
