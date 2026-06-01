using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Core;  // Asegúrate de incluir el espacio de nombres correcto para acceder a la clase CalculadoraDescuentos

namespace Tienda.Core.Tests.Unitarias
{
    [TestFixture]  // Asegúrate de tener el atributo correcto para marcar esta clase como un conjunto de pruebas
    public class CalculadoraDescuentosTests
    {

        [Test]
        public void AplicarDescuento_ConDatosValidos_DevuelveResultado()
        {
            CalculadoraDescuentos calculadora = new();
            decimal precio = 100m;   // Arrange. Preparación de los datos de entrada para la prueba
            decimal porcentajeDescuento = 10m;
            decimal resultado = calculadora.AplicarDescuento(precio, porcentajeDescuento); // Act. Ejecución del método que se va a probar
            Assert.That(resultado, Is.EqualTo(90m)); // Assert. Verificación de que el resultado obtenido es el esperado
        }


        [TestCase(100, 0, 100)]
        [TestCase(100, 10, 90)]
        [TestCase(200, 50, 100)]
        [TestCase(100, 100, 0)]
        [TestCase(0, 50, 0)]
        public void AplicarDescuento_CasosValidos_DevuelveResultado(decimal precio, decimal porcentajeDescuento, decimal resultadoEsperado)
        {
            CalculadoraDescuentos calculadora = new();
            decimal resultado = calculadora.AplicarDescuento(precio, porcentajeDescuento);
            Assert.That(resultado, Is.EqualTo(resultadoEsperado));
        }

        public static IEnumerable<TestCaseData> CasosValidos()
        {
            yield return new TestCaseData(100, 0, 100).SetName("Descuento del 0%");
            yield return new TestCaseData(100, 10, 90).SetName("Descuento del 10%");
            yield return new TestCaseData(200, 50, 100).SetName("Descuento del 50%");
            yield return new TestCaseData(100, 100, 0).SetName("Descuento del 100%");
            yield return new TestCaseData(0, 50, 0).SetName("Precio de 0 con descuento del 50%");
        }

        [TestCaseSource(nameof(CasosValidos))]
        public void AplicarDescuento_CasosValidos_DevuelveResultado_UsandoTestCaseSource(decimal precio, decimal porcentajeDescuento, decimal resultadoEsperado)
        {
            CalculadoraDescuentos calculadora = new();
            decimal resultado = calculadora.AplicarDescuento(precio, porcentajeDescuento);
            Assert.That(resultado, Is.EqualTo(resultadoEsperado));
        }

        [Test]
        public void AplicarDescuento_CasosInvalidos_LanzaExcepcion()
        {
            CalculadoraDescuentos calculadora = new();
            Assert.Throws<ArgumentOutOfRangeException>(() => calculadora.AplicarDescuento(-1, 10)); // Precio negativo
            Assert.Throws<ArgumentOutOfRangeException>(() => calculadora.AplicarDescuento(100, -1)); // Porcentaje negativo
            Assert.Throws<ArgumentOutOfRangeException>(() => calculadora.AplicarDescuento(100, 101)); // Porcentaje mayor a 100
        }

    }
}
