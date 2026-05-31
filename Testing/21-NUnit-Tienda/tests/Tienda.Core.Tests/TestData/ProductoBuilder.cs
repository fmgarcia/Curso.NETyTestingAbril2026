using Tienda.Core;

namespace Tienda.Core.Tests.TestData;

public class ProductoBuilder
{
    private string _nombre = "Teclado";
    private decimal _precio = 89.99m;
    private int _stock = 10;

    public ProductoBuilder ConNombre(string nombre)
    {
        _nombre = nombre;
        return this;
    }

    public ProductoBuilder SinStock()
    {
        _stock = 0;
        return this;
    }

    public Producto Build()
    {
        return new Producto
        {
            Nombre = _nombre,
            Precio = _precio,
            Stock = _stock
        };
    }
}
