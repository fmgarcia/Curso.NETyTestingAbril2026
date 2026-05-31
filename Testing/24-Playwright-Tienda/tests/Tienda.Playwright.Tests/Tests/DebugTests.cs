using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Tienda.Playwright.Tests.Support;

namespace Tienda.Playwright.Tests.Tests;

public class DebugTests : PlaywrightTestBase
{
    [Test]
    public async Task GuardarScreenshot()
    {
        Directory.CreateDirectory("artifacts");
        await Page.GotoAsync($"{TestSettings.BaseUrl}/productos");

        await Page.ScreenshotAsync(new()
        {
            Path = "artifacts/productos.png",
            FullPage = true
        });

        Assert.Pass();
    }

    [Test]
    public async Task GuardarTrace()
    {
        Directory.CreateDirectory("artifacts");

        await Context.Tracing.StartAsync(new()
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        await Page.GotoAsync($"{TestSettings.BaseUrl}/productos");

        await Context.Tracing.StopAsync(new()
        {
            Path = "artifacts/trace.zip"
        });

        Assert.Pass();
    }

    [Test]
    public async Task GuardarEstadoLogin()
    {
        Directory.CreateDirectory("auth");

        await Page.GotoAsync($"{TestSettings.BaseUrl}/login");
        await Page.GetByLabel("Email").FillAsync("admin@ejemplo.com");
        await Page.GetByLabel("Contrasena").FillAsync("Password123!");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Entrar" }).ClickAsync();

        await Expect(Page).ToHaveURLAsync(new Regex(".*/dashboard"));

        await Context.StorageStateAsync(new()
        {
            Path = "auth/admin.json"
        });
    }
}
