using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tienda.E2E.Tests.Suport;


namespace Tienda.E2E.Tests.Test
{
    [TestFixture]
    public class ProductosTests : SeleniumTestBase
    {

        [Test]
        public void AgregarProducto_CategoriaValida_MuestraProductoEnListado()
        {
            // Arrange
            Driver.Navigate().GoToUrl($"{TestSettings.BaseUrl}/productos"); // Navega a la página de administración de productos
            // Act
            Driver.FindElement(By.Id("nuevo-producto")).Click(); // Hace clic en el botón para agregar un nuevo producto
            Wait.Until(d => d.Url == $"{TestSettings.BaseUrl}/productos/nuevo");
            Driver.FindElement(By.Id("nombre")).SendKeys("Nuevo Producto"); // Ingresa el nombre del producto
            Driver.FindElement(By.Id("categoria")).SendKeys("Categoría Válida"); // Ingresa una categoría válida
            Driver.FindElement(By.Id("precio")).SendKeys("19.99"); // Ingresa el precio del producto
            Driver.FindElement(By.Id("stock")).SendKeys("10"); // Ingresa el stock del producto

            Driver.FindElement(By.Id("boton-aceptar")).Click(); // Hace clic en el botón de agregar producto
            // Assert
            Wait.Until(d => d.Url == $"{TestSettings.BaseUrl}/productos");
            string main = Driver.FindElement(By.TagName("main")).Text;

            Assert.That(main, Does.Contain("Nuevo Producto"));
        }

        [Test]
        public void AgregarProducto_SinNombre_MuestraError()
        {
            // Arrange
            Driver.Navigate().GoToUrl($"{TestSettings.BaseUrl}/productos"); // Navega a la página de administración de productos
            // Act
            Driver.FindElement(By.Id("nuevo-producto")).Click(); // Hace clic en el botón para agregar un nuevo producto
            Wait.Until(d => d.Url == $"{TestSettings.BaseUrl}/productos/nuevo");

            Driver.FindElement(By.Id("categoria")).SendKeys("Categoría Válida"); // Ingresa una categoría válida
            Driver.FindElement(By.Id("precio")).SendKeys("19.99"); // Ingresa el precio del producto
            Driver.FindElement(By.Id("stock")).SendKeys("10"); // Ingresa el stock del producto

            Driver.FindElement(By.Id("boton-aceptar")).Click(); // Hace clic en el botón de agregar producto
            // Assert
            IWebElement error = Wait.Until(e => e.FindElement(By.CssSelector(".validation-error"))); // Espera a que aparezca el mensaje de error
            Assert.That(error.Text, Does.Contain("El nombre es obligatorio")); // Verifica que el mensaje de error sea el esperado
        }

    }
}
