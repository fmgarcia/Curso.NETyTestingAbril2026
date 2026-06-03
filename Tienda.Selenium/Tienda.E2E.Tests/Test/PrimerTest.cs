using System;
using System.Collections.Generic;
using System.Text;
using Tienda.E2E.Tests.Suport;

namespace Tienda.E2E.Tests.Test
{
    internal class PrimerTest : SeleniumTestBase
    {

        [Test]
        public void AbrirPaginaPrincipal_MuestraTitulo()
        {
            Driver.Navigate().GoToUrl(TestSettings.BaseUrl); // Navega a la URL base configurada para las pruebas
            Assert.That(Driver.Title, Is.EqualTo("Inicio")); // Verifica que el título de la página sea "Inicio"

        }
    }
}
