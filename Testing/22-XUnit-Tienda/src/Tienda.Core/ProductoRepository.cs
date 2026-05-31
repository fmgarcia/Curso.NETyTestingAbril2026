using Microsoft.Data.Sqlite;

namespace Tienda.Core;

public sealed class ProductoRepository : IAsyncDisposable
{
    private readonly SqliteConnection _connection;
    private readonly bool _ownsConnection;

    public ProductoRepository(SqliteConnection connection, bool ownsConnection = false)
    {
        _connection = connection;
        _ownsConnection = ownsConnection;
    }

    public static async Task<ProductoRepository> CrearParaTestsAsync()
    {
        SqliteConnection connection = new("Data Source=:memory:");
        await connection.OpenAsync();
        ProductoRepository repository = new(connection, ownsConnection: true);
        await repository.InicializarAsync();
        await repository.CrearAsync(new Producto("Teclado", 89.99m) { Categoria = "Perifericos", Stock = 10 });
        return repository;
    }

    public async Task InicializarAsync()
    {
        SqliteCommand command = _connection.CreateCommand();
        command.CommandText = """
            CREATE TABLE IF NOT EXISTS Productos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre TEXT NOT NULL,
                Precio TEXT NOT NULL
            );
            """;

        await command.ExecuteNonQueryAsync();
    }

    public async Task<int> CrearAsync(Producto producto)
    {
        SqliteCommand command = _connection.CreateCommand();
        command.CommandText = """
            INSERT INTO Productos (Nombre, Precio)
            VALUES ($nombre, $precio);
            SELECT last_insert_rowid();
            """;
        command.Parameters.AddWithValue("$nombre", producto.Nombre);
        command.Parameters.AddWithValue("$precio", producto.Precio.ToString(System.Globalization.CultureInfo.InvariantCulture));

        object? result = await command.ExecuteScalarAsync();
        return Convert.ToInt32(result);
    }

    public async Task<List<Producto>> ObtenerTodosAsync()
    {
        SqliteCommand command = _connection.CreateCommand();
        command.CommandText = "SELECT Id, Nombre, Precio FROM Productos ORDER BY Id;";

        List<Producto> productos = [];
        await using SqliteDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            productos.Add(new Producto(
                reader.GetString(1),
                decimal.Parse(reader.GetString(2), System.Globalization.CultureInfo.InvariantCulture))
            {
                Id = reader.GetInt32(0)
            });
        }

        return productos;
    }

    public async ValueTask DisposeAsync()
    {
        if (_ownsConnection)
            await _connection.DisposeAsync();
    }
}
