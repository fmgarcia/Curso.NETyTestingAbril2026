using System;
using System.Collections.Generic;
using System.Text;

namespace PolimorfismoInterfaces
{
    // Por convención, los nombres de interfaz empiezan con 'I'
    interface IVolador
    {
        void Despegar();
        void Aterrizar();
        double AlturaActual { get; }
    }
}
