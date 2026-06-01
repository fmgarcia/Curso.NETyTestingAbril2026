using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Core;  // Asegúrate de incluir el espacio de nombres correcto para acceder a la clase Carrito

namespace Tienda.Core.Tests.Unitarias
{
    [TestFixture]
    [Category("Unitarias")] // Asegúrate de tener el atributo correcto para marcar esta clase como un conjunto de pruebas unitarias
    //[Parallelizable(ParallelScope.All)] // Permite la ejecución paralela de las pruebas dentro de esta clase
    //[NonParallelizable] // Si deseas que las pruebas de esta clase se ejecuten de forma secuencial, puedes usar este atributo
    public class CarritoTests
    {
        [OneTimeSetUp]  // Este método se ejecutará una vez antes de todas las pruebas en esta clase
        public void AntesDeTodasLasPruebas()
        {
            // Configuración global para todas las pruebas, si es necesario
            TestContext.Out.WriteLine("Iniciando pruebas de Carrito... Esto se ejecuta una sola vez antes que todos los tests de la clase");
        }

        [SetUp]  // Este método se ejecutará antes de cada prueba individual
        public void AntesDeCadaPrueba()
        {
            // Configuración específica para cada prueba, si es necesario
            TestContext.Out.WriteLine("Preparando el entorno para la siguiente prueba de Carrito... Esto se ejecuta antes de cada test");
        }

        [TearDown]  // Este método se ejecutará después de cada prueba individual
        public void DespuesDeCadaPrueba()
        {
            // Limpieza específica después de cada prueba, si es necesario
            TestContext.Out.WriteLine("Limpiando el entorno después de la prueba de Carrito... Esto se ejecuta después de cada test");
        }

        [OneTimeTearDown]  // Este método se ejecutará una vez después de todas las pruebas en esta clase
        public void DespuesDeTodasLasPruebas()
        {
            // Limpieza global después de todas las pruebas, si es necesario
            TestContext.Out.WriteLine("Finalizando pruebas de Carrito... Esto se ejecuta una sola vez después de todos los tests de la clase");
        }

        [Test]
        [Repeat(3)]
        public void Agregar_ProductoValido_AumentaTotalItems()
        {
            // Arrange
            Carrito carrito = new();
            Producto producto = new() { Id = 1, Nombre = "Producto 1", Precio = 10m };
            // Act
            carrito.Agregar(producto);
            // Assert
            Assert.That(carrito.TotalItems, Is.EqualTo(1));
            Assert.AreEqual(carrito.TotalItems, 1); // Alternativa usando Assert.AreEqual
        }

        [Test]
        public void Carrito_Nuevo_EstaVacio()
        {
            // Arrange
            Carrito carrito = new();
            // Act & Assert
            Assert.That(carrito.EstaVacio, Is.True);
            Assert.AreEqual(carrito.EstaVacio, true); // Alternativa usando Assert.AreEqual); 
        }

        [Test]
        public void Limpiar_CarritoConProductos_EstaVacio()
        {
            // Arrange
            Carrito carrito = new();
            Producto producto = new() { Id = 1, Nombre = "Producto 1", Precio = 10m };
            carrito.Agregar(producto);
            // Act
            carrito.Limpiar();
            // Assert
            Assert.That(carrito.EstaVacio, Is.True);
        }
    }
}
