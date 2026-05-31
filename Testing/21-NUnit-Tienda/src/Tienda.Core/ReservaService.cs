namespace Tienda.Core;

public class ReservaService
{
    public void Reservar(Producto producto)
    {
        ArgumentNullException.ThrowIfNull(producto);

        if (producto.Stock <= 0)
            throw new InvalidOperationException("No se puede reservar un producto sin stock.");

        producto.Stock--;
    }
}
