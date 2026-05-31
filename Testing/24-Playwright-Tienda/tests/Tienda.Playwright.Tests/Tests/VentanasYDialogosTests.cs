using Microsoft.Playwright;
using Tienda.Playwright.Tests.Support;

namespace Tienda.Playwright.Tests.Tests;

public class VentanasYDialogosTests : PlaywrightTestBase
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
}
