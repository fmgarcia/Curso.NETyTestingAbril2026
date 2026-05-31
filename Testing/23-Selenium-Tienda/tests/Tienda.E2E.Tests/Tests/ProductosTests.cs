using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tienda.E2E.Tests.Support;

namespace Tienda.E2E.Tests.Tests;

[TestFixture]
public class ProductosTests : SeleniumTestBase
{
    [Test]
    public void Listado_MuestraTitulo()
    {
        Driver.Navigate().GoToUrl($"{TestSettings.BaseUrl}/productos");

        IWebElement h1 = Wait.Until(d => d.FindElement(By.TagName("h1")));

        Assert.That(h1.Text, Is.EqualTo("Productos"));
    }

    [Test]
    public void CrearProducto_DatosValidos_MuestraProductoEnListado()
    {
        Driver.Navigate().GoToUrl($"{TestSettings.BaseUrl}/productos/nuevo");

        Driver.FindElement(By.Id("nombre")).SendKeys("Teclado mecanico");
        Driver.FindElement(By.Id("categoria")).SendKeys("Perifericos");
        Driver.FindElement(By.Id("precio")).Clear();
        Driver.FindElement(By.Id("precio")).SendKeys("89.99");
        Driver.FindElement(By.Id("stock")).Clear();
        Driver.FindElement(By.Id("stock")).SendKeys("12");
        Driver.FindElement(By.CssSelector("[data-testid='guardar-producto']")).Click();

        Wait.Until(d => d.Url.EndsWith("/productos", StringComparison.OrdinalIgnoreCase));

        string listado = Driver.FindElement(By.CssSelector("main")).Text;

        Assert.That(listado, Does.Contain("Teclado mecanico"));
    }

    [Test]
    public void CrearProducto_SinNombre_MuestraError()
    {
        Driver.Navigate().GoToUrl($"{TestSettings.BaseUrl}/productos/nuevo");

        Driver.FindElement(By.CssSelector("[data-testid='guardar-producto']")).Click();

        IWebElement error = Wait.Until(d => d.FindElement(By.CssSelector(".validation-error")));

        Assert.That(error.Text, Does.Contain("El nombre es obligatorio"));
    }

    [Test]
    public async Task BuscarProducto_ProductoExistente_ApareceEnResultados()
    {
        await TestDataApi.CrearProductoAsync("Teclado E2E");

        Driver.Navigate().GoToUrl($"{TestSettings.BaseUrl}/productos");
        Driver.FindElement(By.Id("buscar")).SendKeys("Teclado E2E");

        IWebElement resultado = Wait.Until(d =>
            d.FindElement(By.XPath("//*[contains(text(), 'Teclado E2E')]")));

        Assert.That(resultado.Displayed, Is.True);
    }

    [Test]
    public void SelectCheckboxYRadio_EjemploDeLocalizadores()
    {
        Driver.Navigate().GoToUrl($"{TestSettings.BaseUrl}/controles");

        SelectElement categoria = new(Driver.FindElement(By.Id("categoria")));
        categoria.SelectByText("Perifericos");

        IWebElement activo = Driver.FindElement(By.Id("activo"));
        if (!activo.Selected)
            activo.Click();

        Driver.FindElement(By.CssSelector("input[name='envio'][value='urgente']")).Click();
        Driver.FindElement(By.CssSelector("[data-testid='guardar-controles']")).Click();

        IWebElement resultado = Wait.Until(d => d.FindElement(By.CssSelector("[data-testid='resultado-controles']")));

        Assert.Multiple(() =>
        {
            Assert.That(categoria.SelectedOption.Text, Is.EqualTo("Perifericos"));
            Assert.That(activo.Selected, Is.True);
            Assert.That(resultado.Text, Is.EqualTo("Controles guardados"));
        });
    }
}
