
using Biblioteca;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Biblioteca.webapi
{
    public class Program
    {

        //static List<Autor> autores = new List<Autor>();

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Con el siguiente comando arreglamos los posibles bucles infinitos que se producen entre Libros y Autores.
            builder.Services.Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            // Obtener la cadena de conexión
            var connectionString = builder.Configuration.GetConnectionString("SqliteConnection");  // lee el fichero appsettings.json y busca SqliteConnection y devuelve su contenido

            // Registrar la cadena de conexion
            builder.Services.AddDbContext<BibliotecaContext>(options => options.UseSqlite(connectionString));


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Añadimos configuración de CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder => builder.WithOrigins("http://localhost:5173")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            var app = builder.Build();

            // Aplicar middleware de CORS (debe ir antes de endpoints)
            app.UseCors("AllowReactApp");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Biblioteca API v1");
                    c.RoutePrefix = "swagger";
                });
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();


            //app.MapControllers();

            //autores.Add(new Autor(id: 1, nombre: "Gabriel García Márquez", pais: "Colombia", libros: new List<Libro>()));
            //autores.Add(new Autor(id: 2, nombre: "Isabel Allende", pais: "Chile", libros: new List<Libro>()));
            //autores.Add(new Autor(id: 3, nombre: "Tolkien", pais: "Usa", libros: new List<Libro>()));

            var autoresApi = app.MapGroup("/api/autores")
                                .WithTags("Autores"); // Esto agrupa visualmente en Swagger / OpenAPI

            autoresApi.MapGet("/", async (BibliotecaContext context) => 
                await context.Autores.Include(a => a.Libros).ToListAsync());

            autoresApi.MapGet("/{id:int}", async (int id, BibliotecaContext context) =>
                await context.Autores.FindAsync(id) is Autor autor ?
                                                    Results.Ok(autor) :
                                                    Results.NotFound());

            autoresApi.MapPost("/", async (Autor autor, BibliotecaContext context) =>
            {
                context.Autores.Add(autor);
                await context.SaveChangesAsync();
                return Results.Created($"/api/autores/{autor.Id}", autor);
            });

            autoresApi.MapPut("/{id:int}", async (int id, Autor inputAutor, BibliotecaContext context) =>
            {
                var autor = await context.Autores.FindAsync(id);

                if (autor is null) return Results.NotFound();

                autor.Nombre = inputAutor.Nombre;
                autor.Pais = inputAutor.Pais;

                await context.SaveChangesAsync();
                return Results.NoContent();
            });

            autoresApi.MapDelete("/{id:int}", async (int id, BibliotecaContext context) =>
            {
                if (await context.Autores.FindAsync(id) is Autor autor)
                {
                    context.Autores.Remove(autor);
                    await context.SaveChangesAsync();
                    return Results.NoContent();
                }

                return Results.NotFound();
            });

            var librosApi = app.MapGroup("/api/libros")
                                .WithTags("Libros"); 

            librosApi.MapGet("/", async (BibliotecaContext context) => 
                await context.Libros.Include(l => l.Autores).ToListAsync());

            librosApi.MapGet("/{id:int}", async (int id, BibliotecaContext context) =>
                await context.Libros.FindAsync(id) is Libro libro ?
                                                    Results.Ok(libro) :
                                                    Results.NotFound());

            librosApi.MapPost("/", async (LibroInputDto dto, BibliotecaContext context) =>
            {
                var libro = new Libro
                {
                    Titulo = dto.Titulo,
                    ISBN = dto.ISBN,
                    Anio = dto.Anio
                };

                if (dto.AutorIds != null && dto.AutorIds.Any())
                {
                    libro.Autores = await context.Autores.Where(a => dto.AutorIds.Contains(a.Id)).ToListAsync();
                }

                context.Libros.Add(libro);
                await context.SaveChangesAsync();
                return Results.Created($"/api/libros/{libro.Id}", libro);
            });

            librosApi.MapPut("/{id:int}", async (int id, LibroInputDto dto, BibliotecaContext context) =>
            {
                var libro = await context.Libros.Include(l => l.Autores).FirstOrDefaultAsync(l => l.Id == id);

                if (libro is null) return Results.NotFound();

                libro.Titulo = dto.Titulo;
                libro.ISBN = dto.ISBN;
                libro.Anio = dto.Anio;

                libro.Autores.Clear();
                if (dto.AutorIds != null && dto.AutorIds.Any())
                {
                    libro.Autores = await context.Autores.Where(a => dto.AutorIds.Contains(a.Id)).ToListAsync();
                }

                await context.SaveChangesAsync();
                return Results.NoContent();
            });

            librosApi.MapDelete("/{id:int}", async (int id, BibliotecaContext context) =>
            {
                if (await context.Libros.FindAsync(id) is Libro libro)
                {
                    context.Libros.Remove(libro);
                    await context.SaveChangesAsync();
                    return Results.NoContent();
                }

                return Results.NotFound();
            });


            app.Run();
        }
    }

    public record LibroInputDto(string Titulo, string ISBN, int Anio, int[] AutorIds);
}
