using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Core.Tests.TestData
{
    public class ProductoBuilder
    {
        private string _nombre = "Teclado";
        private string _categoria = "Perifericos";
        private decimal _precio = 89.99m;
        private int _stock = 10;
        private DateTime _fechaCreacion = new(2026, 1, 1);

        public ProductoBuilder ConNombre(string nombre)
        {
            _nombre = nombre;
            return this;
        }

        public ProductoBuilder ConCategoria(string categoria)
        {
            _categoria = categoria;
            return this;
        }

        public ProductoBuilder ConPrecio(decimal precio)
        {
            _precio = precio;
            return this;
        }

        public ProductoBuilder ConStock(int stock)
        {
            _stock = stock;
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
                Categoria = _categoria,
                Precio = _precio,
                Stock = _stock,
                FechaCreacion = _fechaCreacion
            };
        }


    }
}
