using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.E2E.Tests.Suport;

namespace Tienda.E2E.Tests.Test
{
    [TestFixture]
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
            Assert.Pass("Screenshot guardada en artifacts/productos.png");
        }

        [Test]
        public async Task GuardarScreenshot_NavegacionIncorrecta()
        {
            Directory.CreateDirectory("artifacts");
            try
            {
                await Page.GotoAsync($"{TestSettings.BaseUrl}/productos2");
                await Page.ScreenshotAsync(new()
                {
                    Path = "artifacts/productos_correcto.png",
                    FullPage = true
                });
                Assert.Pass("Screenshot guardada en artifacts/productos.png");
            }
            catch (Exception)
            {

                await Page.ScreenshotAsync(new()
                {
                    Path = "artifacts/productos_incorrecto.png",
                    FullPage = true
                });
                Assert.Fail("Navegación incorrecta, screenshot guardada en artifacts/productos.png");
            }

        }

        [Test]
        public async Task GuardarTrace()
        {
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
        }


        [Test]
        public async Task GuardarTraceStarWars()
        {
            await Context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            try
            {
                await Page.GotoAsync($"https://swapi.info");
                // Busca en la barra de navegación el enlace que se llame exactamente "Films"
                await Page.GetByRole(AriaRole.Navigation)
                          .GetByRole(AriaRole.Link, new() { Name = "Films", Exact = true })
                          .ClickAsync();

                // Ejecutamos la acción que abre el popup
                IPage popup = await Page.RunAndWaitForPopupAsync(async () =>
                {
                    await Page.Locator("a[href='https://swapi.info/api/films']").ClickAsync();
                });
                await popup.WaitForLoadStateAsync();
                var cuerpoPagina = popup.Locator("body");
                await Expect(cuerpoPagina).ToContainTextAsync("["); // Indicamos que devuelve el Json una lista
                await Expect(cuerpoPagina).ToContainTextAsync($"title");
                await Expect(cuerpoPagina).ToContainTextAsync($"A New Hope");

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                await Context.Tracing.StopAsync(new()
                {
                    Path = $"artifacts/trace_star_wars_{DateTime.Now:yyyyMMdd_HHmmss}.zip"
                });
            }


        }



    }
}
