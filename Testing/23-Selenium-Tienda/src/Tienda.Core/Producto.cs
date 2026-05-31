namespace Tienda.Core;

public record Producto
{
    public int Id { get; init; }
    public string Nombre { get; init; } = string.Empty;
    public string Categoria { get; init; } = string.Empty;
    public decimal Precio { get; init; }
    public int Stock { get; init; }
}
