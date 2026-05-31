using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Builder;

namespace Tienda.Playwright.Tests.Support;

public sealed class LocalApiServer : IAsyncDisposable
{
    private readonly WebApplication _app;

    private LocalApiServer(WebApplication app, string url)
    {
        _app = app;
        Url = url;
    }

    public string Url { get; }

    public static async Task<LocalApiServer> StartAsync()
    {
        int port = GetFreePort();
        string url = $"http://127.0.0.1:{port}";
        WebApplication app = ApiHost.Create(["--urls", url]);
        await app.StartAsync();

        return new LocalApiServer(app, url);
    }

    public async ValueTask DisposeAsync()
    {
        await _app.StopAsync();
        await _app.DisposeAsync();
    }

    private static int GetFreePort()
    {
        TcpListener listener = new(IPAddress.Loopback, 0);
        listener.Start();
        int port = ((IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();
        return port;
    }
}
