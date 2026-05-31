using Tienda.Core;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

List<Producto> productos =
[
    new Producto("Teclado", 89.99m) { Id = 1, Categoria = "Perifericos", Stock = 12 },
    new Producto("Raton", 29.99m) { Id = 2, Categoria = "Perifericos", Stock = 20 }
];

app.MapGet("/", () => Results.Text("Tienda API", "text/plain"));

app.MapGet("/api/productos", () => Results.Ok(productos));

app.MapPost("/api/productos", (Producto producto) =>
{
    Producto creado = producto with { Id = productos.Count + 1 };
    productos.Add(creado);
    return Results.Created($"/api/productos/{creado.Id}", creado);
});

app.Run();

public partial class Program
{
}
