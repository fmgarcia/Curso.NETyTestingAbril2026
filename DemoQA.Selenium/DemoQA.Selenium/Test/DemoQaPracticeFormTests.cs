using System;
using System.Collections.Generic;
using System.Text;
using DemoQA.Selenium.Support;
using OpenQA.Selenium;

namespace DemoQA.Selenium.Test
{
    [TestFixture]
    [Category("DemoQA")]
    public class DemoQaPracticeFormTests : SeleniumExternoTestBase
    {
        [Test]
        public void PracticeForm_ConDatosValidos_MuestraModalDeConfirmacion()
        {
            IrARutaUrlBase("/automation-practice-form");

            Escribir(By.Id("firstName"), "Laura");
            Escribir(By.Id("lastName"), "Perez");
            Escribir(By.Id("userEmail"), "laura.perez@example.com");

            //ClickSeguro(By.CssSelector("label[for='gender-radio-2']"));
            ClickSeguro(By.Id("gender-radio-2"));

            Escribir(By.Id("userNumber"), "1234567890");
            SeleccionarFecha("15 Jan 2000");
            SeleccionarSubject("Maths");

            ClickSeguro(By.CssSelector("label[for='hobbies-checkbox-2']"));
            SubirArchivoDePrueba();

            Escribir(By.Id("currentAddress"), "Avenida Central 10");
            SeleccionarEstadoYCiudad("NCR", "Delhi");

            ClickSeguro(By.Id("submit"));

            IWebElement tituloModal = BuscarVisible(By.Id("example-modal-sizes-title-lg"));
            IWebElement tablaModal = BuscarVisible(By.CssSelector(".table-responsive"));

            Assert.Multiple(() =>
            {
                Assert.That(tituloModal.Text, Is.EqualTo("Thanks for submitting the form"));
                Assert.That(tablaModal.Text, Does.Contain("Laura Perez"));
                Assert.That(tablaModal.Text, Does.Contain("laura.perez@example.com"));
                Assert.That(tablaModal.Text, Does.Contain("Female"));
                Assert.That(tablaModal.Text, Does.Contain("1234567890"));
                Assert.That(tablaModal.Text, Does.Contain("Maths"));
                Assert.That(tablaModal.Text, Does.Contain("Reading"));
                Assert.That(tablaModal.Text, Does.Contain("NCR Delhi"));
            });
        }

        private void SeleccionarFecha(string fecha)
        {
            IWebElement fechaNacimiento = BuscarDisponible(By.Id("dateOfBirthInput"));
            ScrollHasta(fechaNacimiento); // Asegurarse de que el campo esté visible antes de interactuar
            fechaNacimiento.SendKeys(Keys.Control + "a"); // Seleccionar todo el texto existente
            fechaNacimiento.SendKeys(fecha); // Introducir la nueva fecha
            fechaNacimiento.SendKeys(Keys.Enter); // Confirmar la selección
        }

        private void SeleccionarSubject(string subject)
        {
            IWebElement subjects = BuscarDisponible(By.Id("subjectsInput"));
            ScrollHasta(subjects); // Asegurarse de que el campo esté visible antes de interactuar
            subjects.SendKeys(subject); // Introducir la nueva materia
            subjects.SendKeys(Keys.Enter); // Confirmar la selección
        }

        private void SeleccionarEstadoYCiudad(string estado, string ciudad)
        {
            IWebElement state = BuscarDisponible(By.Id("react-select-3-input"));
            state.SendKeys(estado);
            state.SendKeys(Keys.Enter);

            IWebElement city = BuscarDisponible(By.Id("react-select-4-input"));
            city.SendKeys(ciudad);
            city.SendKeys(Keys.Enter);
        }

        private void SubirArchivoDePrueba()
        {
            string path = Path.Combine(TestContext.CurrentContext.WorkDirectory, "archivo_de_prueba.txt");
            File.WriteAllText(path, "Archivo temporal creado por Selenium.");

            Driver.FindElement(By.Id("uploadPicture")).SendKeys(path);
        }



    }
}
