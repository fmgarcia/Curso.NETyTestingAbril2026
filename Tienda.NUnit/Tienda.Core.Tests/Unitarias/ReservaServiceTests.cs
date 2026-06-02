using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Core;
using Tienda.Core.Tests.TestData;

namespace Tienda.Core.Tests.Unitarias
{
    [TestFixture]
    [Category("Unitarias")]
    public class ReservaServiceTests
    {

        [Test]
        public void Reservar_ProductoSinStock_LanzaExcepcion()
        {
            // Arrange
            var producto = new ProductoBuilder().SinStock().Build();
            var reservaService = new ReservaService();
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => reservaService.Reservar(producto));
        }

        [Test]
        public void Reservar_ProductoConStock_DecrementaStock()
        {
            // Arrange
            var producto = new ProductoBuilder().ConStock(5).Build();
            var reservaService = new ReservaService();
            // Act
            reservaService.Reservar(producto);
            // Assert
            Assert.AreEqual(4, producto.Stock);
        }




    }
}
