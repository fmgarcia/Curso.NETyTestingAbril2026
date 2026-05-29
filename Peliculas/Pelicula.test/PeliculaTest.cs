using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Peliculas;

namespace Pelicula.test
{
    public class PeliculaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Pelicula_ConstructorVacio_InstanciaCorrecta()
        {
            var p = new Peliculas.Pelicula();
            Assert.That(p, Is.Not.Null);
            Assert.That(p.ImdbID, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Pelicula_ConstructorParametros_InstanciaCorrecta()
        {
            var p = new Peliculas.Pelicula("tt12345", "Test Movie", 2000, 8.5, "Action", "Director", "http://poster.com");
            
            Assert.Multiple(() =>
            {
                Assert.That(p.ImdbID, Is.EqualTo("tt12345"));
                Assert.That(p.Title, Is.EqualTo("Test Movie"));
                Assert.That(p.Year, Is.EqualTo(2000));
                Assert.That(p.ImdbRating, Is.EqualTo(8.5));
                Assert.That(p.Genre, Is.EqualTo("Action"));
                Assert.That(p.Director, Is.EqualTo("Director"));
                Assert.That(p.Poster, Is.EqualTo("http://poster.com"));
            });
        }

        [Test]
        public void Pelicula_ValidacionTitle_ErrorSiFalta()
        {
            var p = new Peliculas.Pelicula { ImdbID = "tt1", Year = 2000 };
            
            var context = new ValidationContext(p, null, null);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(p, context, results, true);
            
            Assert.That(isValid, Is.False, "La entidad sin título debería ser inválida");
            Assert.That(results.Count, Is.GreaterThan(0));
            Assert.That(results[0].ErrorMessage, Does.Contain("El título es obligatorio."));
        }

        [Test]
        public void Pelicula_Equals_ComparaPorId()
        {
            var p1 = new Peliculas.Pelicula { ImdbID = "tt1" };
            var p2 = new Peliculas.Pelicula { ImdbID = "tt1" };
            var p3 = new Peliculas.Pelicula { ImdbID = "tt2" };

            Assert.Multiple(() =>
            {
                Assert.That(p1.Equals(p2), Is.True);
                Assert.That(p1.Equals(p3), Is.False);
            });
        }
    }
}
