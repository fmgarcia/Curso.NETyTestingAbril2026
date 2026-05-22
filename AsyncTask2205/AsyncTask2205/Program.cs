using System.Text.Json;

namespace AsyncTask2205
{
    internal class Program
    {

        static async Task<string> ObtenerDatosWebAsync(string url)
        {
            using HttpClient client = new();
            string respuesta = await client.GetStringAsync(url);
            return respuesta;
        }

        // Deserializar la respuesta JSON
        record Todo(int UserId, int Id, string Title, bool Completed);
        record ProductOpenfacts(string Product_Name, string Brands);
        record Openfacts(string Code, ProductOpenfacts Product);
        static string url_base = "https://jsonplaceholder.typicode.com/todos/";
        static string openfoodfacts = "https://world.openfoodfacts.net/api/v2/product/";

        static async Task<Todo?> ObtenerTodoAsync(string url, int id)
        {
            using HttpClient client = new();
            string json = await client.GetStringAsync(
                $"{url}{id}");
            return JsonSerializer.Deserialize<Todo>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        static async Task<T?> ObtenerTodoAsyncGenerico<T>(string url_base, string id, string finalCadena = "")
        {
            using HttpClient client = new();
            string json = await client.GetStringAsync(
                $"{url_base}{id}");
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        static async Task Main(string[] args)
        {
            // Uso
            //string datos = await ObtenerDatosWebAsync("https://jsonplaceholder.typicode.com/todos/1");
            //Console.WriteLine(datos);

            //Todo? todo = await ObtenerTodoAsync(url_base, 1);
            //Console.WriteLine($"Tarea: {todo?.Title} (Completada: {todo?.Completed})");

            //Todo? todoGenerico = await ObtenerTodoAsyncGenerico<Todo>(url_base, "1");
            var openfactsGenerico = await ObtenerTodoAsyncGenerico<Openfacts>(openfoodfacts, "3274080005003", ".json");
            Console.WriteLine($"Código: {openfactsGenerico?.Code} Nombre: {openfactsGenerico?.Product?.Product_Name} Marcas: {openfactsGenerico?.Product?.Brands}");


        }
    }
}
