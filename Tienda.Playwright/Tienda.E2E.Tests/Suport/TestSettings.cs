using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.E2E.Tests.Suport
{
    public static class TestSettings
    {
        public static string BaseUrl { get; set; } = Environment.GetEnvironmentVariable("E2E_BASE_URL")
            ?? "http://127.0.0.1:5123"; // Valor por defecto si no se establece la variable de entorno

    }
}
