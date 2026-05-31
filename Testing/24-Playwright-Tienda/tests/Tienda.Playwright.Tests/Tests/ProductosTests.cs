using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Tienda.Playwright.Tests.Pages;
using Tienda.Playwright.Tests.Support;

namespace Tienda.Playwright.Tests.Tests;

public class ProductosTests : PlaywrightTestBase
{
    [Test]
    public async Task CrearProducto_DatosValidos_ApareceEnListado()
    {
        await Page.GotoAsync($"{TestSettings.BaseUrl}/productos/nuevo");

        await Page.GetByLabel("Nombre").FillAsync("Teclado mecanico");
        await Page.GetByLabel("Categoria").FillAsync("Perifericos");
        await Page.GetByLabel("Precio").FillAsync("89.99");
        await Page.GetByLabel("Stock").FillAsync("12");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Guardar" }).ClickAsync();

        await Expect(Page).ToHaveURLAsync(new Regex(".*/productos"));
        await Expect(Page.GetByText("Teclado mecanico")).ToBeVisibleAsync();
    }

    [Test]
    public async Task CrearProducto_SinNombre_MuestraError()
    {
        await Page.GotoAsync($"{TestSettings.BaseUrl}/productos/nuevo");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Guardar" }).ClickAsync();

        await Expect(Page.GetByText("El nombre es obligatorio")).ToBeVisibleAsync();
    }

    [Test]
    public async Task CrearProducto_ConPageObject()
    {
        ProductosPage productos = new(Page);

        await productos.AbrirNuevoAsync();
        await productos.CrearAsync("Raton", "Perifericos", 29.99m, 30);

        await Expect(productos.Producto("Raton")).ToBeVisibleAsync();
    }

    [Test]
    public async Task Listado_TieneTituloYTotal()
    {
        await Page.GotoAsync($"{TestSettings.BaseUrl}/productos");

        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Productos" })).ToBeVisibleAsync();
        await Expect(Page.GetByTestId("total")).ToContainTextAsync("89,99");
    }
}
