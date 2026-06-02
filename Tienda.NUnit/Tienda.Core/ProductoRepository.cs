using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Core
{
    public class ProductoRepository
    {
        private readonly SqliteConnection _connection;

        public ProductoRepository(SqliteConnection connection)
        {
            _connection = connection;
        }

        public async Task InicializarAsync()
        {
            SqliteCommand command = _connection.CreateCommand();
            command.CommandText = """
            CREATE TABLE IF NOT EXISTS Productos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre TEXT NOT NULL,
                Categoria TEXT NOT NULL,
                Precio TEXT NOT NULL,
                Stock INTEGER NOT NULL,
                FechaCreacion TEXT NOT NULL
            );
            """;

            await command.ExecuteNonQueryAsync();
        }

        public async Task<int> CrearAsync(Producto producto)
        {
            SqliteCommand command = _connection.CreateCommand();
            command.CommandText = """
            INSERT INTO Productos (Nombre, Categoria, Precio, Stock, FechaCreacion)
            VALUES ($nombre, $categoria, $precio, $stock, $fechaCreacion);
            SELECT last_insert_rowid();
            """;
            command.Parameters.AddWithValue("$nombre", producto.Nombre);
            command.Parameters.AddWithValue("$categoria", producto.Categoria);
            command.Parameters.AddWithValue("$precio", producto.Precio.ToString(System.Globalization.CultureInfo.InvariantCulture));
            command.Parameters.AddWithValue("$stock", producto.Stock);
            command.Parameters.AddWithValue("$fechaCreacion", producto.FechaCreacion.ToString("O"));

            object? result = await command.ExecuteScalarAsync();

            return Convert.ToInt32(result);
        }

        public async Task<Producto?> ObtenerPorIdAsync(int id)
        {
            SqliteCommand command = _connection.CreateCommand();
            command.CommandText = """
            SELECT Id, Nombre, Categoria, Precio, Stock, FechaCreacion
            FROM Productos
            WHERE Id = $id;
            """;
            command.Parameters.AddWithValue("$id", id);

            await using SqliteDataReader reader = await command.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return null;

            return new Producto
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Categoria = reader.GetString(2),
                Precio = decimal.Parse(reader.GetString(3), System.Globalization.CultureInfo.InvariantCulture),
                Stock = reader.GetInt32(4),
                FechaCreacion = DateTime.Parse(
                    reader.GetString(5),
                    null,
                    System.Globalization.DateTimeStyles.RoundtripKind)
            };

        }

        public async Task<List<Producto>> ObtenerTodosAsync()
        {
            SqliteCommand command = _connection.CreateCommand();
            command.CommandText = """
            SELECT Id, Nombre, Categoria, Precio, Stock, FechaCreacion
            FROM Productos;
            """;
            List<Producto> productos = new();
            await using SqliteDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                productos.Add(new Producto
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Categoria = reader.GetString(2),
                    Precio = decimal.Parse(reader.GetString(3), System.Globalization.CultureInfo.InvariantCulture),
                    Stock = reader.GetInt32(4),
                    FechaCreacion = DateTime.Parse(
                        reader.GetString(5),
                        null,
                        System.Globalization.DateTimeStyles.RoundtripKind)
                });
            }
            return productos;
        }

    }
}
