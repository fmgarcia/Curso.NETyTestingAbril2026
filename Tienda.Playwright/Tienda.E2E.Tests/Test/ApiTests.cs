using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.E2E.Tests.Suport;

namespace Tienda.E2E.Tests.Test
{
    [TestFixture]
    public class ApiTests : PlaywrightTestBase
    {

        [Test]
        public async Task ApiProductos_DevuelveOk()
        {
            await using IAPIRequestContext request = await Playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = TestSettings.BaseUrl,
                IgnoreHTTPSErrors = true
            });

            IAPIResponse response = await request.GetAsync("/api/productos");  // Conecta con el endpoint de productos

            Assert.That(response.Ok, Is.True); // Verifica que la respuesta sea exitosa (código 200-299)
        }

        [Test]
        public async Task ApiStarWars_DevuelveOk()
        {
            await using IAPIRequestContext request = await Playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = "https://swapi.info/api",
                IgnoreHTTPSErrors = true
            });

            IAPIResponse response = await request.GetAsync("/films");  // Conecta con el endpoint de productos

            Assert.That(response.Ok, Is.True); // Verifica que la respuesta sea exitosa (código 200-299)
        }


        [Test]
        public async Task ApiAnyadirProducto_Correcto()
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
}
