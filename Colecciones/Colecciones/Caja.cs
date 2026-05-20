using System;
using System.Collections.Generic;
using System.Text;

namespace Colecciones
{
    class Caja<T>
    {
        public T Contenido { get; set; }

        public Caja(T contenido)
        {
            Contenido = contenido;
        }

        public T ObtenerContenido() => Contenido;
        public void CambiarContenido(T nuevo) => Contenido = nuevo;
        public override string ToString() => $"Caja con: {Contenido}";
    }

}
