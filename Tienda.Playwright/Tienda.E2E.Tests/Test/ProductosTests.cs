using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Tienda.E2E.Tests.Pages;
using Tienda.E2E.Tests.Suport;

namespace Tienda.E2E.Tests.Test
{
    [TestFixture]
    public class ProductosTests : PlaywrightTestBase
    {
        [Test]
        public async Task CrearProducto_NuevoProducto()
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

    }
}
