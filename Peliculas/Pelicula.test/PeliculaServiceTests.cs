using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Peliculas;

namespace Pelicula.test
{
    public class PeliculaServiceTests
    {
        private PeliculaContext _context;
        private PeliculaService _service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<PeliculaContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;

            _context = new PeliculaContext(options);
            _service = new PeliculaService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task CrearPeliculaAsync_AñadePeliculaYDevuelveId()
        {
            var p = new Peliculas.Pelicula { ImdbID = "tt100", Title = "Matrix", Year = 1999 };

            var id = await _service.CrearPeliculaAsync(p);

            Assert.That(id, Is.EqualTo("tt100"));
            var numPeliculas = await _context.Peliculas.CountAsync();
            Assert.That(numPeliculas, Is.EqualTo(1));
        }

        [Test]
        public async Task ObtenerPeliculaPorIdAsync_DevuelvePeliculaSiExiste()
        {
            _context.Peliculas.Add(new Peliculas.Pelicula { ImdbID = "tt200", Title = "Inception" });
            await _context.SaveChangesAsync();

            var pelicula = await _service.ObtenerPeliculaPorIdAsync("tt200");

            Assert.That(pelicula, Is.Not.Null);
            Assert.That(pelicula!.Title, Is.EqualTo("Inception"));
        }

        [Test]
        public async Task ObtenerPeliculaPorIdAsync_DevuelveNullSiNoExiste()
        {
            var pelicula = await _service.ObtenerPeliculaPorIdAsync("ttNoExiste");

            Assert.That(pelicula, Is.Null);
        }

        [Test]
        public async Task ObtenerTodasLasPeliculasAsync_DevuelveTodas()
        {
            _context.Peliculas.Add(new Peliculas.Pelicula { ImdbID = "tt1", Title = "A" });
            _context.Peliculas.Add(new Peliculas.Pelicula { ImdbID = "tt2", Title = "B" });
            await _context.SaveChangesAsync();

            var resultado = await _service.ObtenerTodasLasPeliculasAsync();

            Assert.That(resultado.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task ActualizarPeliculaAsync_ActualizaYDevuelveTrueSiExiste()
        {
            _context.Peliculas.Add(new Peliculas.Pelicula { ImdbID = "tt1", Title = "Old Title" });
            await _context.SaveChangesAsync();

            var nuevaData = new Peliculas.Pelicula { ImdbID = "tt1", Title = "New Title" };
            var resultado = await _service.ActualizarPeliculaAsync(nuevaData);

            Assert.That(resultado, Is.True);
            var dbItem = await _context.Peliculas.FindAsync("tt1");
            Assert.That(dbItem!.Title, Is.EqualTo("New Title"));
        }

        [Test]
        public async Task ActualizarPeliculaAsync_DevuelveFalseSiNoExiste()
        {
            var nuevaData = new Peliculas.Pelicula { ImdbID = "tt99", Title = "New Title" };
            var resultado = await _service.ActualizarPeliculaAsync(nuevaData);

            Assert.That(resultado, Is.False);
        }

        [Test]
        public async Task EliminarPeliculaAsync_EliminaYDevuelveTrueSiExiste()
        {
            _context.Peliculas.Add(new Peliculas.Pelicula { ImdbID = "tt1", Title = "A" });
            await _context.SaveChangesAsync();

            var resultado = await _service.EliminarPeliculaAsync("tt1");

            Assert.That(resultado, Is.True);
            var count = await _context.Peliculas.CountAsync();
            Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public async Task BuscarPeliculasPorTituloAsync_DevuelveCoincidencias()
        {
            _context.Peliculas.Add(new Peliculas.Pelicula { ImdbID = "tt1", Title = "Batman" });
            _context.Peliculas.Add(new Peliculas.Pelicula { ImdbID = "tt2", Title = "Batman Returns" });
            _context.Peliculas.Add(new Peliculas.Pelicula { ImdbID = "tt3", Title = "Superman" });
            await _context.SaveChangesAsync();

            var resultados = await _service.BuscarPeliculasPorTituloAsync("Bat");

            Assert.That(resultados.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task ObtenerTopPeliculasMejorValoradasAsync_OrdenaDescendente()
        {
            _context.Peliculas.Add(new Peliculas.Pelicula { ImdbID = "tt1", Title = "A", ImdbRating = 5.0 });
            _context.Peliculas.Add(new Peliculas.Pelicula { ImdbID = "tt2", Title = "B", ImdbRating = 9.0 });
            _context.Peliculas.Add(new Peliculas.Pelicula { ImdbID = "tt3", Title = "C", ImdbRating = 8.0 });
            await _context.SaveChangesAsync();

            var resultados = await _service.ObtenerTopPeliculasMejorValoradasAsync(2);

            Assert.That(resultados.Count, Is.EqualTo(2));
            Assert.That(resultados[0].Title, Is.EqualTo("B"));
            Assert.That(resultados[1].Title, Is.EqualTo("C"));
        }

        [Test]
        public async Task ObtenerDirectorConMasPeliculasAsync_DevuelveElMayor()
        {
            _context.Peliculas.Add(new Peliculas.Pelicula { ImdbID = "tt1", Title = "A", Director = "Nolan" });
            _context.Peliculas.Add(new Peliculas.Pelicula { ImdbID = "tt2", Title = "B", Director = "Nolan" });
            _context.Peliculas.Add(new Peliculas.Pelicula { ImdbID = "tt3", Title = "C", Director = "Spielberg" });
            await _context.SaveChangesAsync();

            var (Director, Cantidad) = await _service.ObtenerDirectorConMasPeliculasAsync();

            Assert.That(Director, Is.EqualTo("Nolan"));
            Assert.That(Cantidad, Is.EqualTo(2));
        }
    }
}