using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Core
{
    public class ProductoService
    {
        public async Task<decimal> ObtenerPrecioAsync(int productoId)
        {
            if (productoId <= 0)
                throw new ArgumentOutOfRangeException(nameof(productoId));

            await Task.Delay(50);  // Emulo una llamada a una base de datos o servicio externo

            return productoId == 1 ? 89.99m : 0m;
        }


    }
}
