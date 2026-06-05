using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.E2E.Tests.Suport;

namespace Tienda.E2E.Tests.Test
{
    public class VentanasTests : PlaywrightTestBase
    {
        [Test]
        public async Task AbrirAyuda_EnPopup_MuestraTitulo()
        {
            await Page.GotoAsync($"{TestSettings.BaseUrl}/ventanas");

            IPage popup = await Page.RunAndWaitForPopupAsync(async () =>
            {
                await Page.GetByRole(AriaRole.Button, new() { Name = "Abrir ayuda" }).ClickAsync();
            });

            await popup.WaitForLoadStateAsync();
            await Expect(popup).ToHaveTitleAsync("Ayuda");
        }


    }
}
