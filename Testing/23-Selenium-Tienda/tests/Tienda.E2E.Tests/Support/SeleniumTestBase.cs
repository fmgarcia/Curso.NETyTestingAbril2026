using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Tienda.E2E.Tests.Support;

public abstract class SeleniumTestBase
{
    private LocalApiServer? _server;

    protected IWebDriver Driver { get; private set; } = null!;
    protected WebDriverWait Wait { get; private set; } = null!;

    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        if (Environment.GetEnvironmentVariable("E2E_BASE_URL") is null)
        {
            _server = await LocalApiServer.StartAsync();
            TestSettings.BaseUrl = _server.Url;
        }
    }

    [SetUp]
    public void SetUp()
    {
        ChromeOptions options = new();

        if (Environment.GetEnvironmentVariable("CI") == "true")
            options.AddArgument("--headless=new");

        options.AddArgument("--window-size=1920,1080");

        Driver = new ChromeDriver(options);
        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
    }

    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            GuardarCaptura(TestContext.CurrentContext.Test.Name);

        Driver.Quit();
        Driver.Dispose();
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        if (_server is not null)
            await _server.DisposeAsync();
    }

    protected void GuardarCaptura(string nombre)
    {
        Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();

        Directory.CreateDirectory("screenshots");
        string path = Path.Combine("screenshots", $"{nombre}-{DateTime.UtcNow:yyyyMMddHHmmss}.png");

        screenshot.SaveAsFile(path);
    }
}
