namespace Tienda.Core;

public record Producto(string Nombre, decimal Precio)
{
    public int Id { get; init; }
    public string Categoria { get; init; } = string.Empty;
    public int Stock { get; init; }
}
