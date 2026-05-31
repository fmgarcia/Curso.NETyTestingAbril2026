using System.Net.Http.Json;

namespace Tienda.E2E.Tests.Support;

public static class TestDataApi
{
    public static async Task CrearProductoAsync(string nombre)
    {
        using HttpClient client = new()
        {
            BaseAddress = new Uri(TestSettings.BaseUrl)
        };

        HttpResponseMessage response = await client.PostAsJsonAsync("/api/test/productos", new
        {
            nombre,
            categoria = "Perifericos",
            precio = 89.99m,
            stock = 10
        });

        response.EnsureSuccessStatusCode();
    }
}
