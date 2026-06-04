using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Tienda.E2E.Tests.Suport
{
    public class PlaywrightTestBase : PageTest
    {
        private LocalApiServer? _server;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            if (Environment.GetEnvironmentVariable("E2E_BASE_URL") is null)
            {
                _server = await LocalApiServer.StartAsync();
                TestSettings.BaseUrl = _server.Url;
            }
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            if (_server is not null)
                await _server.DisposeAsync();
        }


        /// <summary>
        /// Configura las opciones del contexto del navegador para las pruebas. 
        /// Esto incluye establecer el tamaño de la ventana, el idioma, la zona horaria y la opción para ignorar errores HTTPS.
        /// </summary>
        /// <returns>Opciones de configuración para el contexto del navegador.</returns>
        public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1440, Height = 900 },
                Locale = "es-ES",
                TimezoneId = "Europe/Madrid",
                IgnoreHTTPSErrors = true
            };
        }


    }
}
