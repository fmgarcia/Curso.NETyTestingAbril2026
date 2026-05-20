using System;
using System.Collections.Generic;
using System.Text;

namespace Colecciones
{
    internal class SerializarObjeto<T>
    {

        public T objeto;

        public SerializarObjeto(T objeto) { this.objeto = objeto; }

        public SerializarObjeto(string nombreFichero)
        {

        }

    }
}
