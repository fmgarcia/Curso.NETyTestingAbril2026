using System.Globalization;
using Microsoft.Playwright;
using Tienda.Playwright.Tests.Support;

namespace Tienda.Playwright.Tests.Pages;

public class ProductosPage
{
    private readonly IPage _page;

    public ProductosPage(IPage page)
    {
        _page = page;
    }

    public async Task AbrirNuevoAsync()
    {
        await _page.GotoAsync($"{TestSettings.BaseUrl}/productos/nuevo");
    }

    public async Task CrearAsync(string nombre, string categoria, decimal precio, int stock)
    {
        await _page.GetByLabel("Nombre").FillAsync(nombre);
        await _page.GetByLabel("Categoria").FillAsync(categoria);
        await _page.GetByLabel("Precio").FillAsync(precio.ToString(CultureInfo.InvariantCulture));
        await _page.GetByLabel("Stock").FillAsync(stock.ToString(CultureInfo.InvariantCulture));
        await _page.GetByRole(AriaRole.Button, new() { Name = "Guardar" }).ClickAsync();
    }

    public ILocator Producto(string nombre)
    {
        return _page.GetByText(nombre);
    }
}
