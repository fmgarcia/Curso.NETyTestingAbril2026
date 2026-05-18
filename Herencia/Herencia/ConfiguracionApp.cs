using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    sealed class ConfiguracionApp  // Clase sellada, no se puede heredar
    {
        public string NombreApp { get; set; } = "MiApp";
        public string Version { get; set; } = "1.0";

        // Singleton: una sola instancia (patrón de diseño)
        private static ConfiguracionApp? _instancia;
        public static ConfiguracionApp Instancia => _instancia ??= new ConfiguracionApp();

        private ConfiguracionApp() { }  // Constructor privado
    }
}
