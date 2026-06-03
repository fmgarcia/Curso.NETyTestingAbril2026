using DemoQA.Selenium.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Selenium.Test
{
    [TestFixture]
    [Category("DemoQA")]
    public class DemoQaTextBoxTests : SeleniumExternoTestBase
    {
        [Test]
        public void TextBox_EnviaFormulario_MuestraLosDatosIntroducidos()
        {
            IrARutaUrlBase("/text-box");

            Escribir(By.Id("userName"), "Fran Garcia");
            Escribir(By.Id("userEmail"), "fran.garcia@example.com");
            Escribir(By.Id("currentAddress"), "Calle Mayor 1");
            Escribir(By.Id("permanentAddress"), "Calle Luna 2");

            ClickSeguro(By.Id("submit"));

            IWebElement output = BuscarVisible(By.Id("output"));

            Assert.Multiple(() =>
            {
                Assert.That(output.Text, Does.Contain("Fran Garcia"));
                Assert.That(output.Text, Does.Contain("fran.garcia@example.com"));
                Assert.That(output.Text, Does.Contain("Calle Mayor 1"));
                Assert.That(output.Text, Does.Contain("Calle Luna 2"));
            });
        }

        [Test]
        public void TextBox_EmailInvalido_MarcaElInputComoError()
        {
            IrARutaUrlBase("/text-box");

            Escribir(By.Id("userName"), "Fran Garcia");
            Escribir(By.Id("userEmail"), "email-invalido");

            ClickSeguro(By.Id("submit"));

            IWebElement email = BuscarVisible(By.Id("userEmail"));

            Assert.That(email.GetAttribute("class"), Does.Contain("field-error"));
        }


    }
}
