using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.E2E.Tests.Suport;


namespace Tienda.E2E.Tests.Test
{
    [TestFixture]
    public class LoginTest : SeleniumTestBase
    {

        [Test]
        public void Login_UsuarioValido_RedireccionaAlInicio()
        {
            // Arrange
            Driver.Navigate().GoToUrl($"{TestSettings.BaseUrl}/login"); // Navega a la página de login
            // Act
            Driver.FindElement(By.Id("email")).SendKeys("fran@example.com"); // Ingresa un nombre de usuario válido
            Driver.FindElement(By.Id("password")).SendKeys("contraseña_valida"); // Ingresa una contraseña válida
            Driver.FindElement(By.Id("loginButton")).Click(); // Hace clic en el botón de login
            // Assert
            Wait.Until(d => d.Url == $"{TestSettings.BaseUrl}/dashboard"); // Espera hasta que la URL sea la del inicio
            Assert.That(Driver.Title, Is.EqualTo("Dashboard")); // Verifica que el título de la página sea "Inicio"
        }
    }
}
