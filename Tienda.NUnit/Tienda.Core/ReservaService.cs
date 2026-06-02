using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Core
{
    public class ReservaService
    {

        public void Reservar(Producto producto)
        {
            ArgumentNullException.ThrowIfNull(producto); // Validar que el producto no sea nulo. Si es nulo lanzará una excepción ArgumentNullException.
            if (producto.Stock <= 0) // Verificar si el stock del producto es menor o igual a cero. Si es así, se lanza una excepción InvalidOperationException indicando que no hay stock disponible para reservar.
            {
                throw new InvalidOperationException("No hay stock disponible para reservar.");
            }
            producto.Stock--; // Si el producto tiene stock disponible, se decrementa el stock en uno para reflejar la reserva realizada.
        }


    }
}
