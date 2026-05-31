using Microsoft.Playwright;
using Tienda.Playwright.Tests.Support;

namespace Tienda.Playwright.Tests.Tests;

public class ApiProductosTests : PlaywrightTestBase
{
    [Test]
    public async Task ApiProductos_DevuelveOk()
    {
        await using IAPIRequestContext request = await Playwright.APIRequest.NewContextAsync(new()
        {
            BaseURL = TestSettings.BaseUrl,
            IgnoreHTTPSErrors = true
        });

        IAPIResponse response = await request.GetAsync("/api/productos");

        Assert.That(response.Ok, Is.True);
    }

    [Test]
    public async Task CrearProducto_DesdeApi()
    {
        await using IAPIRequestContext request = await Playwright.APIRequest.NewContextAsync(new()
        {
            BaseURL = TestSettings.BaseUrl,
            IgnoreHTTPSErrors = true
        });

        IAPIResponse response = await request.PostAsync("/api/productos", new()
        {
            DataObject = new
            {
                nombre = "Webcam",
                categoria = "Perifericos",
                precio = 49.99,
                stock = 20
            }
        });

        Assert.That(response.Status, Is.EqualTo(201));
    }
}
