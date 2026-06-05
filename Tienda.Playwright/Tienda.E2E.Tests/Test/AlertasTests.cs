using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.E2E.Tests.Suport;

namespace Tienda.E2E.Tests.Test
{
    [TestFixture]
    public class AlertasTests : PlaywrightTestBase
    {

        [Test]
        public async Task Eliminar_AceptaDialogo_MuestraResultado()
        {
            await Page.GotoAsync($"{TestSettings.BaseUrl}/alertas");

            TaskCompletionSource<string> dialogMessage = new();
            Page.Dialog += async (_, dialog) =>
            {
                dialogMessage.SetResult(dialog.Message);
                await dialog.AcceptAsync();
            };

            await Page.GetByRole(AriaRole.Button, new() { Name = "Eliminar" }).ClickAsync();

            Assert.That(await dialogMessage.Task, Does.Contain("Seguro?"));
            await Expect(Page.GetByTestId("resultado-alerta")).ToHaveTextAsync("Eliminado");
        }

        [Test]
        public async Task Eliminar_DescartaDialogo_MuestraResultado()
        {
            await Page.GotoAsync($"{TestSettings.BaseUrl}/alertas");

            TaskCompletionSource<string> dialogMessage = new();
            Page.Dialog += async (_, dialog) =>
            {
                dialogMessage.SetResult(dialog.Message);
                await dialog.DismissAsync();
            };

            await Page.GetByRole(AriaRole.Button, new() { Name = "Eliminar" }).ClickAsync();

            Assert.That(await dialogMessage.Task, Does.Contain("Seguro?"));
            await Expect(Page.GetByTestId("resultado-alerta")).ToHaveTextAsync("");
        }

    }
}
