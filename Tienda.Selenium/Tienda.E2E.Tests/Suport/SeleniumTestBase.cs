using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.E2E.Tests.Suport
{
    public abstract class SeleniumTestBase
    {

        private LocalApiServer? _server;

        protected IWebDriver Driver { get; private set; } = null!;
        protected WebDriverWait Wait { get; private set; } = null!;

        /// <summary>
        /// Configura el servidor API local y establece la URL base para las pruebas antes de ejecutar cualquier prueba.
        /// </summary>
        /// <returns></returns>
        [OneTimeSetUp] // Se ejecuta una vez antes de todas las pruebas en la clase
        public async Task OneTimeSetUp()
        {
            _server = await LocalApiServer.StartAsync();  // Inicia el servidor API local
            TestSettings.BaseUrl = _server.Url;  // Configura la URL base para las pruebas
        }

        /// <summary>
        /// Detiene el servidor API local y libera los recursos asociados después de ejecutar todas las pruebas.
        /// </summary>
        /// <returns></returns>
        [OneTimeTearDown] // Se ejecuta una vez después de todas las pruebas en la clase
        public async Task OneTimeTearDown()
        {
            if (_server != null)
            {
                await _server.DisposeAsync();  // Detiene el servidor API local y libera los recursos asociados
            }
        }

        /// <summary>
        /// Configura el entorno de pruebas antes de cada prueba individual. 
        /// Esto incluye la creación de una nueva instancia del controlador de Chrome con opciones específicas, 
        /// como el modo headless para entornos de integración continua, 
        /// y la configuración de un tiempo de espera explícito para las operaciones de Selenium.
        /// </summary>
        [SetUp] // Se ejecuta antes de cada prueba
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            if (Environment.GetEnvironmentVariable("CI") == "true") // Si estamos en un entorno de integración continua, ejecutamos el navegador en modo headless
            {
                options.AddArgument("--headless=new"); // Ejecuta Chrome en modo headless (sin interfaz gráfica)
            }
            options.AddArgument("--window-size=1920,1080"); // Establece el tamaño de la ventana del navegador
            Driver = new ChromeDriver(options); // Crea una nueva instancia del controlador de Chrome con las opciones configuradas
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); // Configura un tiempo de espera explícito para las operaciones de Selenium
        }

        /// <summary>
        /// Limpia el entorno de pruebas después de cada prueba individual.
        /// Si la prueba ha fallado, captura una captura de pantalla del estado del navegador en el momento del fallo 
        /// para facilitar la depuración.
        /// </summary>
        [TearDown] // Se ejecuta después de cada prueba
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                GuardarCaptura(TestContext.CurrentContext.Test.Name);
            }
            Driver.Quit();
            Driver.Dispose();
        }

        /// <summary>
        /// Guarda una captura de pantalla del estado actual del navegador en un archivo 
        /// con un nombre que incluye el nombre de la prueba y la fecha y hora de la captura.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        protected void GuardarCaptura(string nombreArchivo)
        {
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                Directory.CreateDirectory("screenshots");
                string rutaCaptura = Path.Combine("screenshots", $"{nombreArchivo}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                screenshot.SaveAsFile(rutaCaptura);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar la captura de pantalla: {ex.Message}");
            }
        }


    }
}
