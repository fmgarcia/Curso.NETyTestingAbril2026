using Microsoft.Playwright;
using Tienda.Playwright.Tests.Support;

namespace Tienda.Playwright.Tests.Tests;

public class MobileTests : PlaywrightTestBase
{
    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions
        {
            ViewportSize = new ViewportSize
            {
                Width = 390,
                Height = 844
            },
            IsMobile = true,
            HasTouch = true,
            DeviceScaleFactor = 3,
            Locale = "es-ES"
        };
    }

    [Test]
    public async Task MenuMovil_SeAbre()
    {
        await Page.GotoAsync(TestSettings.BaseUrl);

        await Page.GetByRole(AriaRole.Button, new() { Name = "Menu" }).ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Navigation)).ToBeVisibleAsync();
    }
}
