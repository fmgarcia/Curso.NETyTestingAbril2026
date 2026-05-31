using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tienda.Core.Tests.Api;

public class ProductosApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ProductosApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetProductos_DevuelveOk()
    {
        HttpResponseMessage response = await _client.GetAsync(
            "/api/productos",
            TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
