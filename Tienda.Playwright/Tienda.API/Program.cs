using Tienda.Core;
using System.Globalization;
using System.Net;


WebApplication app = ApiHost.Create(args);
await app.RunAsync();

public static class ApiHost
{

    public static WebApplication Create(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => Results.Content(Page("Inicio", """
            <h1>Dashboard</h1>
            <button aria-label="Menu" id="menu">Menu</button>
            <nav aria-label="Principal"><a href="/productos">Productos</a></nav>
            """), "text/html"));

        app.MapGet("/login", () => Results.Content(Page("Login", """
            <h1>Login</h1>
            <form method="post" action="/login">
              <label for="email">Email</label>
              <input id="email" name="email" />
              <label for="password">Password</label>
              <input id="password" name="password" type="password" />
              <button id="loginButton" type="submit">Entrar</button>
            </form>
            <a href="/registro">Crear cuenta</a>
            """), "text/html"));

        app.MapPost("/login", () => Results.Redirect("/dashboard"));

        app.MapGet("/dashboard", () => Results.Content(Page("Dashboard", """
            <h1 id="panel-usuario">Panel de usuario</h1>
            <a href="/productos">Ir a productos</a>
            """), "text/html"));

        app.MapGet("/productos", () => Results.Content(ProductosPage(), "text/html"));
        app.MapGet("/productos/nuevo", () => Results.Content(ProductoForm(), "text/html"));
        app.MapGet("/controles", () => Results.Content(ControlesPage(), "text/html"));
        app.MapGet("/ventanas", () => Results.Content(VentanasPage(), "text/html"));
        app.MapGet("/ayuda", () => Results.Content(Page("Ayuda", """
            <h1>Ayuda</h1>
            <p>Pagina abierta en una pestana nueva.</p>
            """), "text/html"));
        app.MapGet("/alertas", () => Results.Content(AlertasPage(), "text/html"));

        app.MapPost("/productos", async (HttpRequest request) =>
        {
            IFormCollection form = await request.ReadFormAsync();
            string nombre = form["nombre"].ToString();

            if (string.IsNullOrWhiteSpace(nombre))
                return Results.Content(ProductoForm("El nombre es obligatorio"), "text/html", statusCode: StatusCodes.Status400BadRequest);

            ProductoStore.Add(new Producto
            {
                Nombre = nombre,
                Categoria = form["categoria"].ToString(),
                Precio = decimal.Parse(form["precio"].ToString(), CultureInfo.InvariantCulture),
                Stock = int.Parse(form["stock"].ToString(), CultureInfo.InvariantCulture)
            });

            return Results.Redirect("/productos");
        });

        app.MapGet("/api/productos", () => Results.Ok(ProductoStore.All()));

        app.MapPost("/api/test/productos", (Producto producto) =>
        {
            Producto creado = ProductoStore.Add(producto);
            return Results.Created($"/api/productos/{creado.Id}", creado);
        });

        return app;
    }

    private static string Page(string title, string body) => $$"""
            <!DOCTYPE html>
            <html lang="es">
            <head>
                <meta charset="utf-8" />
                <title>{{title}}</title>
                <style>
                    body { font-family: Segoe UI, Arial, sans-serif; max-width: 900px; margin: 40px auto; line-height: 1.5; }
                    label, input, select { display: block; margin: 8px 0; }
                    input, select { padding: 8px; min-width: 280px; }
                    input[type='checkbox'], input[type='radio'] { display: inline-block; min-width: auto; }
                    button, a { display: inline-block; margin-top: 12px; padding: 8px 12px; }
                    .validation-error { color: #b00020; font-weight: 600; }
                    article { border-bottom: 1px solid #ddd; padding: 10px 0; }
                </style>
            </head>
            <body>
                {{body}}
            </body>
            </html>
            """;

    private static string ProductosPage()
    {
        string items = string.Join(Environment.NewLine, ProductoStore.All().Select(producto =>
            $"""<article data-testid="producto"><h2>{WebUtility.HtmlEncode(producto.Nombre)}</h2><p>{WebUtility.HtmlEncode(producto.Categoria)} - {producto.Precio:0.00}</p></article>"""));

        return Page("Productos", $$"""
            <h1>Productos</h1>
            <label for="buscar">Buscar productos</label>
            <input id="buscar" placeholder="Buscar productos" />
            <main>{{items}}</main>
            <output data-testid="total">{{ProductoStore.All().Count}}</output>
            <a id="nuevo-producto" href="/productos/nuevo">Nuevo producto</a>
            """);
    }

    private static string ProductoForm(string? error = null)
    {
        string errorHtml = error is null ? string.Empty : $"""<p class="validation-error">{WebUtility.HtmlEncode(error)}</p>""";

        return Page("Nuevo producto", $$"""
            <h1>Nuevo producto</h1>
            {{errorHtml}}
            <form method="post" action="/productos">
              <label for="nombre">Nombre</label>
              <input id="nombre" name="nombre" />
              <label for="categoria">Categoria</label>
              <input id="categoria" name="categoria" />
              <label for="precio">Precio</label>
              <input id="precio" name="precio" value="0" />
              <label for="stock">Stock</label>
              <input id="stock" name="stock" value="0" />
              <button id="boton-aceptar" type="submit" data-testid="guardar-producto">Guardar</button>
            </form>
            """);
    }

    private static string ControlesPage() => Page("Controles", """
        <h1>Controles avanzados</h1>
        <label for="categoria">Categoria</label>
        <select id="categoria" name="categoria">
          <option value="">Selecciona categoria</option>
          <option value="perifericos">Perifericos</option>
          <option value="pantallas">Pantallas</option>
        </select>
        <label for="activo">
          <input id="activo" name="activo" type="checkbox" />
          Activo
        </label>
        <fieldset>
          <legend>Tipo de envio</legend>
          <label><input name="envio" type="radio" value="normal" /> Normal</label>
          <label><input name="envio" type="radio" value="urgente" /> Urgente</label>
        </fieldset>
        <button type="button" data-testid="guardar-controles"
          onclick="document.querySelector('[data-testid=resultado-controles]').textContent='Controles guardados';">
          Guardar controles
        </button>
        <p data-testid="resultado-controles"></p>
        """);

    private static string VentanasPage() => Page("Ventanas", """
        <h1>Ventanas</h1>
        <button id="abrir-ayuda" type="button" onclick="window.open('/ayuda', '_blank')">Abrir ayuda</button>
        """);

    private static string AlertasPage() => Page("Alertas", """
        <h1>Alertas</h1>
        <button id="eliminar" type="button"
          onclick="if (confirm('Seguro?')) document.querySelector('[data-testid=resultado-alerta]').textContent='Eliminado';">
          Eliminar
        </button>
        <p data-testid="resultado-alerta"></p>
        """);

}

public static class ProductoStore
{
    private static readonly List<Producto> Productos =
    [
        new Producto { Id = 1, Nombre = "Monitor", Categoria = "Pantallas", Precio = 199.99m, Stock = 5 }
    ];

    public static IReadOnlyList<Producto> All() => Productos;

    public static Producto Add(Producto producto)
    {
        Producto creado = producto with { Id = Productos.Count + 1 };
        Productos.Add(creado);
        return creado;
    }
}

public partial class Program
{
}



