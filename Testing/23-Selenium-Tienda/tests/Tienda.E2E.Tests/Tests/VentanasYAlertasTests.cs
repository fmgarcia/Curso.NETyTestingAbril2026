using OpenQA.Selenium;
using Tienda.E2E.Tests.Support;

namespace Tienda.E2E.Tests.Tests;

[TestFixture]
public class VentanasYAlertasTests : SeleniumTestBase
{
    [Test]
    public void AbrirAyuda_EnNuevaPestana_MuestraTitulo()
    {
        Driver.Navigate().GoToUrl($"{TestSettings.BaseUrl}/ventanas");
        string original = Driver.CurrentWindowHandle;

        Driver.FindElement(By.Id("abrir-ayuda")).Click();

        Wait.Until(d => d.WindowHandles.Count == 2);
        string nueva = Driver.WindowHandles.Single(handle => handle != original);
        Driver.SwitchTo().Window(nueva);

        Assert.That(Driver.Title, Does.Contain("Ayuda"));

        Driver.Close();
        Driver.SwitchTo().Window(original);
    }

    [Test]
    public void Eliminar_ConfirmaAlerta_MuestraResultado()
    {
        Driver.Navigate().GoToUrl($"{TestSettings.BaseUrl}/alertas");

        Driver.FindElement(By.Id("eliminar")).Click();
        IAlert alert = Driver.SwitchTo().Alert();

        Assert.That(alert.Text, Does.Contain("Seguro?"));

        alert.Accept();
        IWebElement resultado = Wait.Until(d => d.FindElement(By.CssSelector("[data-testid='resultado-alerta']")));

        Assert.That(resultado.Text, Is.EqualTo("Eliminado"));
    }
}
