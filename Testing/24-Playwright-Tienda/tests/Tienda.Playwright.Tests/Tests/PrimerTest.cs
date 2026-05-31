using System.Text.RegularExpressions;
using Tienda.Playwright.Tests.Support;

namespace Tienda.Playwright.Tests.Tests;

public class PrimerTest : PlaywrightTestBase
{
    [Test]
    public async Task PaginaPrincipal_MuestraTitulo()
    {
        await Page.GotoAsync(TestSettings.BaseUrl);

        await Expect(Page).ToHaveTitleAsync(new Regex("Tienda"));
    }
}
