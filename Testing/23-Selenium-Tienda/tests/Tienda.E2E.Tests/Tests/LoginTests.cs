using Tienda.E2E.Tests.Pages;
using Tienda.E2E.Tests.Support;

namespace Tienda.E2E.Tests.Tests;

[TestFixture]
public class LoginTests : SeleniumTestBase
{
    [Test]
    public void Login_ConCredencialesValidas_EntraEnDashboard()
    {
        LoginPage login = new(Driver);

        login.Abrir();
        login.IniciarSesion("ana@ejemplo.com", "Password123!");

        Assert.That(login.EstaEnDashboard(), Is.True);
    }
}
