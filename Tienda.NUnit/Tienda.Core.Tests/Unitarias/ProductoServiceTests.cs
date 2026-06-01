using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Core;  // Asegúrate de incluir el espacio de nombres correcto para acceder a la clase ProductoService  

namespace Tienda.Core.Tests.Unitarias
{
    [TestFixture]
    [Category("Unitarias")] // Asegúrate de tener el atributo correcto para marcar esta clase como un conjunto de pruebas unitarias
    public class ProductoServiceTests
    {

        [Test]
        public async Task ObtenerPrecioAsync_ProductoExistente_DevuelvePrecio()
        {
            var productoService = new ProductoService();
            //ProductoService service = new();
            decimal precio = await productoService.ObtenerPrecioAsync(1); // Asumiendo que el producto con ID 1 existe

            Assert.That(precio, Is.EqualTo(89.99m)); // Reemplaza 89.99m con el precio esperado para el producto con ID 1
        }


    }
}
