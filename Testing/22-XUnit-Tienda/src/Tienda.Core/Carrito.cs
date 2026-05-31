namespace Tienda.Core;

public class Carrito
{
    private readonly List<Producto> _productos = [];

    public int TotalItems => _productos.Count;
    public bool EstaVacio => _productos.Count == 0;

    public void Agregar(Producto producto) => _productos.Add(producto);
    public void Limpiar() => _productos.Clear();
}
