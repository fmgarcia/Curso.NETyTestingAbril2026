namespace Tienda.E2E.Tests.Support;

public static class TestSettings
{
    public static string BaseUrl { get; set; } =
        Environment.GetEnvironmentVariable("E2E_BASE_URL")
        ?? "http://127.0.0.1:5123";
}
