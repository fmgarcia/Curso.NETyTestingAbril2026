using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Selenium.Support
{
    public abstract class SeleniumExternoTestBase
    {
        protected const string BaseUrl = "https://demoqa.com";

        protected IWebDriver Driver { get; private set; } = null!;
        protected WebDriverWait Wait { get; private set; } = null!;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new();

            if (Environment.GetEnvironmentVariable("CI") == "true")
                options.AddArgument("--headless=new");

            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--disable-notifications");

            Driver = new ChromeDriver(options);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(12));
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
                GuardarCaptura(TestContext.CurrentContext.Test.Name);

            Driver.Quit();
            Driver.Dispose();
        }

        protected void IrARutaUrlBase(string ruta)
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}{ruta}");
            CerrarElementosQueTapanLaPagina();
        }

        protected IWebElement BuscarVisible(By locator)
        {
            return Wait.Until(driver =>
            {
                try
                {
                    IWebElement element = driver.FindElement(locator);
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            })!;
        }

        protected IWebElement BuscarDisponible(By locator)
        {
            return Wait.Until(driver =>
            {
                try
                {
                    IWebElement element = driver.FindElement(locator);
                    return element.Displayed && element.Enabled ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            })!;
        }

        protected void Escribir(By locator, string texto)
        {
            IWebElement element = BuscarDisponible(locator);
            ScrollHasta(element);
            element.Clear();
            element.SendKeys(texto);
        }

        protected void ClickSeguro(By locator)
        {
            CerrarElementosQueTapanLaPagina();

            IWebElement element = BuscarDisponible(locator);
            ClickSeguro(element);
        }

        protected void ClickSeguro(IWebElement element)
        {
            CerrarElementosQueTapanLaPagina();

            ScrollHasta(element);
            element.Click();
        }

        protected void ScrollHasta(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript(
                "arguments[0].scrollIntoView({ block: 'center', inline: 'nearest' });",
                element);
        }

        protected IAlert EsperarAlerta()
        {
            return Wait.Until(driver =>
            {
                try
                {
                    return driver.SwitchTo().Alert();
                }
                catch (NoAlertPresentException)
                {
                    return null;
                }
            })!;
        }

        protected void GuardarCaptura(string nombre)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();

            Directory.CreateDirectory("screenshots");
            string path = Path.Combine("screenshots", $"{nombre}-{DateTime.UtcNow:yyyyMMddHHmmss}.png");

            screenshot.SaveAsFile(path);
        }

        private void CerrarElementosQueTapanLaPagina()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript(
                "document.querySelectorAll('iframe[id^=\"google_ads\"], iframe[name^=\"google_ads\"], #fixedban, footer').forEach(e => e.remove());");
        }
    }
}
