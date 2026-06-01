using System;
using System.Collections.Generic;
using System.Text;


namespace Tienda.Core
{
    public class CalculadoraDescuentos
    {

        public decimal AplicarDescuento(decimal precio, decimal porcentaje)
        {
            if (precio < 0)
                throw new ArgumentOutOfRangeException(nameof(precio));

            if (porcentaje is < 0 or > 100)
                throw new ArgumentOutOfRangeException(nameof(porcentaje));

            return precio - precio * porcentaje / 100;
        }



    }
}
