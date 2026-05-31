using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tienda.E2E.Tests.Support;

namespace Tienda.E2E.Tests.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Abrir()
    {
        _driver.Navigate().GoToUrl($"{TestSettings.BaseUrl}/login");
    }

    public void IniciarSesion(string email, string password)
    {
        _driver.FindElement(By.Id("email")).SendKeys(email);
        _driver.FindElement(By.Id("password")).SendKeys(password);
        _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
    }

    public bool EstaEnDashboard()
    {
        return _wait.Until(driver => driver.Url.Contains("/dashboard"));
    }
}
