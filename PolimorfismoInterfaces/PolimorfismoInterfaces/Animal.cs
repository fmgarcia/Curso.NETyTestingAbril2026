using System;
using System.Collections.Generic;
using System.Text;

namespace PolimorfismoInterfaces
{
    abstract class Animal
    {
        public string Nombre { get; set; } = "";
        public abstract string HacerSonido();
    }
}
