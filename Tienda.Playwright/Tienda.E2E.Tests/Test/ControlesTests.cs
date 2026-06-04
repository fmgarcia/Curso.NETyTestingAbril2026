using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.E2E.Tests.Suport;
using Microsoft.Playwright;

namespace Tienda.E2E.Tests.Test
{
    [TestFixture]
    public class ControlesTests : PlaywrightTestBase
    {

        [Test]
        public async Task SelectCheckboxYRadio_GuardaControles()
        {
            await Page.GotoAsync($"{TestSettings.BaseUrl}/controles");

            await Page.Locator("#categoria").SelectOptionAsync(new[] { "perifericos" });
            await Page.GetByLabel("Activo").CheckAsync();
            await Page.Locator("input[name='envio'][value='urgente']").CheckAsync();
            await Page.GetByTestId("guardar-controles").ClickAsync();

            await Expect(Page.GetByTestId("resultado-controles")).ToHaveTextAsync("Controles guardados");
        }


    }
}
