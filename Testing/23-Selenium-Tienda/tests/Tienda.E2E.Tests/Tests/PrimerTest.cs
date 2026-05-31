using Tienda.E2E.Tests.Support;

namespace Tienda.E2E.Tests.Tests;

[TestFixture]
public class PrimerTest : SeleniumTestBase
{
    [Test]
    public void AbrirPaginaPrincipal_MuestraTitulo()
    {
        Driver.Navigate().GoToUrl(TestSettings.BaseUrl);

        Assert.That(Driver.Title, Does.Contain("Inicio"));
    }
}
