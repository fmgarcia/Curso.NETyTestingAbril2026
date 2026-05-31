namespace Tienda.Core.Tests.Unitarias;

[TestFixture]
public class AtributosTests
{
    [Test]
    [Category("Unitarias")]
    public void TestUnitarioRapido()
    {
        Assert.Pass();
    }

    [Test]
    [Category("Integracion")]
    public void TestDeIntegracion()
    {
        Assert.Pass();
    }

    [Test]
    [Ignore("Ejemplo didactico de prueba ignorada")]
    public void TestTemporalmenteIgnorado()
    {
        Assert.Fail();
    }

    [Test]
    [Repeat(3)]
    public void TestRepetido()
    {
        Assert.That(Guid.NewGuid(), Is.Not.EqualTo(Guid.Empty));
    }
}
