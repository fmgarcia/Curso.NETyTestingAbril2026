using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace EntityFramework2505
{
    internal class Program
    {

        static void EjemploInsertarCategoria(string nombre, string descripcion)
        {
            using var db = new TiendaContext();  // Creación de una instancia del contexto de la tienda utilizando la declaración "using". Esto asegura que el contexto se dispose correctamente después de su uso, liberando los recursos asociados. El contexto "TiendaContext" es la clase que representa la conexión a la base de datos y proporciona acceso a las tablas y entidades definidas en el modelo de datos.
            var nuevaCategoria = new Categoria  // Creación de una nueva instancia de la clase "Categoria" con los datos que se desean insertar en la base de datos.
            {
                Nombre = nombre,
                Descripcion = descripcion
            };
            db.Categorias.Add(nuevaCategoria);  // Agrega la nueva categoría al DbSet "Categorias" del contexto de la tienda. Esto marca la entidad como "Added" (Agregada) en el seguimiento de cambios del contexto, lo que indica que se debe insertar un nuevo registro en la base de datos cuando se llame a "SaveChanges".
            db.SaveChanges();  // Guarda los cambios en la base de datos. Al llamar a "SaveChanges", Entity Framework Core genera y ejecuta la consulta SQL necesaria para insertar el nuevo registro en la tabla de categorías de la base de datos, utilizando los datos proporcionados en la instancia de "Categoria". Después de ejecutar esta línea, la nueva categoría "Deportes" se habrá insertado correctamente en la base de datos.
            Console.WriteLine($"Categoría '{nombre}' insertada correctamente.");
        }


        static void EjemploInsertarProducto(string nombre, string descripcion, decimal precio, int stock, int categoriaId)
        {
            using var db = new TiendaContext();  // Creación de una instancia del contexto de la tienda utilizando la declaración "using". Esto asegura que el contexto se dispose correctamente después de su uso, liberando los recursos asociados. El contexto "TiendaContext" es la clase que representa la conexión a la base de datos y proporciona acceso a las tablas y entidades definidas en el modelo de datos.
            var nuevoProducto = new Producto  // Creación de una nueva instancia de la clase "Producto" con los datos que se desean insertar en la base de datos.
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Precio = precio,
                Stock = stock,
                CategoriaId = categoriaId
            };
            db.Productos.Add(nuevoProducto);  // Agrega el nuevo producto al DbSet "Productos" del contexto de la tienda. Esto marca la entidad como "Added" (Agregada) en el seguimiento de cambios del contexto, lo que indica que se debe insertar un nuevo registro en la base de datos cuando se llame a "SaveChanges".
            db.SaveChanges();  // Guarda los cambios en la base de datos. Al llamar a "SaveChanges", Entity Framework Core genera y ejecuta la consulta SQL necesaria para insertar el nuevo registro en la tabla de productos de la base de datos, utilizando los datos proporcionados en la instancia de "Producto". Después de ejecutar esta línea, el nuevo producto se habrá insertado correctamente en la base de datos.
            Console.WriteLine($"Producto '{nombre}' insertado correctamente.");
        }

        static void EjemploLeerProductos()
        {
            // Obtener todos los productos de la base de datos utilizando el método "ToList" para ejecutar la consulta y obtener una lista de productos.
            new TiendaContext().Productos
                .ToList()
                .ForEach(p => Console.WriteLine($"ID: {p.Id}, Nombre: {p.Nombre}, Precio: {p.Precio}, Stock: {p.Stock}"));  // Itera sobre la lista de productos y muestra sus detalles en la consola. Para cada producto, se imprime su ID, nombre, precio y stock.
        }

        static void EjemploLeerUnProducto(int id)
        {

            var producto = new TiendaContext().Productos.Find(id);  // Busca un producto específico en la base de datos utilizando su ID. El método "Find" es una forma eficiente de buscar una entidad por su clave primaria, ya que primero verifica si la entidad ya está cargada en el contexto antes de realizar una consulta a la base de datos. Si el producto con el ID especificado existe, se devuelve la instancia del producto; de lo contrario, se devuelve null.
            Console.WriteLine($"{(producto != null ? $"ID: {producto.Id}, Nombre: {producto.Nombre}, Precio: {producto.Precio}, Stock: {producto.Stock}" : "Producto no encontrado")}");
        }

        static void MostrarCategoriaConProductos(int categoriaId)
        {
            var categoria = new TiendaContext().Categorias
                .Include(c => c.Productos)  // Utiliza el método "Include" para cargar la relación entre categorías y productos. Esto permite acceder a los productos asociados a cada categoría sin necesidad de realizar consultas adicionales a la base de datos.
                .FirstOrDefault(c => c.Id == categoriaId);  // Busca la primera categoría que tenga un ID igual al proporcionado. Si se encuentra una categoría con ese ID, se devuelve la instancia de la categoría; de lo contrario, se devuelve null.

            if (categoria != null)
            {
                Console.WriteLine($"Categoría: {categoria.Nombre}");
                foreach (var producto in categoria.Productos)
                {
                    Console.WriteLine($" - Producto: {producto.Nombre}, Precio: {producto.Precio}");
                }
            }
            else
            {
                Console.WriteLine("Categoría no encontrada.");
            }
        }

        static void BuscarProductosPorDescripcion(string texto)
        {
            var productos = new TiendaContext().Productos
                .Where(p => p.Descripcion.Contains(texto))  // Utiliza el método "Where" para filtrar los productos que contienen el texto especificado en su descripción. Esto genera una consulta SQL que busca coincidencias en la columna de descripción de la tabla de productos.
                .ToList();  // Ejecuta la consulta y obtiene una lista de productos que cumplen con el criterio de búsqueda.
            if (productos.Count > 0)
            {
                Console.WriteLine($"Productos que contienen '{texto}' en su descripción:");
                foreach (var producto in productos)
                {
                    Console.WriteLine($" - Producto: {producto.Nombre}, Descripción: {producto.Descripcion}");
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron productos que contengan '{texto}' en su descripción.");
            }
        }

        static void BuscarProductosPorPrecio(decimal precioMinimo, decimal precioMaximo)
        {
            var productos = new TiendaContext().Productos
                .Where(p => p.Precio >= precioMinimo && p.Precio <= precioMaximo)  // Utiliza el método "Where" para filtrar los productos que tienen un precio dentro del rango especificado. Esto genera una consulta SQL que busca productos cuyo precio sea mayor o igual al precio mínimo y menor o igual al precio máximo.
                .OrderBy(p => p.Precio)  // Ordena los productos por su precio de forma ascendente. Esto genera una cláusula "ORDER BY" en la consulta SQL para ordenar los resultados por la columna de precio.
                .ToList();  // Ejecuta la consulta y obtiene una lista de productos que cumplen con el criterio de búsqueda.
            if (productos.Count > 0)
            {
                Console.WriteLine($"Productos con precio entre {precioMinimo} y {precioMaximo}:");
                foreach (var producto in productos)
                {
                    Console.WriteLine($" - Producto: {producto.Nombre}, Precio: {producto.Precio}");
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron productos con precio entre {precioMinimo} y {precioMaximo}.");
            }
        }

        static void ActualizarProducto(int id, decimal nuevoPrecio, int nuevoStock)
        {
            var db = new TiendaContext();  // Creación de una instancia del contexto de la tienda para realizar operaciones de actualización en la base de datos.
            var producto = db.Productos.Find(id);  // Busca el producto que se desea actualizar utilizando su ID. El método "Find" es una forma eficiente de buscar una entidad por su clave primaria, ya que primero verifica si la entidad ya está cargada en el contexto antes de realizar una consulta a la base de datos. Si el producto con el ID especificado existe, se devuelve la instancia del producto; de lo contrario, se devuelve null.
            if (producto is not null)
            {
                producto.Precio = nuevoPrecio;  // Actualiza el precio del producto con el nuevo valor proporcionado.
                producto.Stock = nuevoStock;  // Actualiza el stock del producto con el nuevo valor proporcionado.
                db.SaveChanges();  // Guarda los cambios en la base de datos. Al llamar a "SaveChanges", Entity Framework Core genera y ejecuta la consulta SQL necesaria para actualizar el registro del producto en la tabla de productos de la base de datos, utilizando los nuevos valores de precio y stock proporcionados. Después de ejecutar esta línea, el producto se habrá actualizado correctamente en la base de datos.
                Console.WriteLine($"Producto '{producto.Nombre}' actualizado correctamente.");

            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }

        }

        private static void EliminarProducto(int id)
        {
            var db = new TiendaContext();  // Creación de una instancia del contexto de la tienda para realizar operaciones de eliminación en la base de datos.
            var producto = db.Productos.Find(id);  // Busca el producto que se desea eliminar utilizando su ID.
            if (producto is not null)
            {
                db.Productos.Remove(producto);  // Marca el producto para eliminación.
                db.SaveChanges();  // Guarda los cambios en la base de datos. Al llamar a "SaveChanges", Entity Framework Core genera y ejecuta la consulta SQL necesaria para eliminar el registro del producto en la tabla de productos de la base de datos.
                Console.WriteLine($"Producto '{producto.Nombre}' eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        private static void EliminarCategoria(int id)
        {
            var db = new TiendaContext();  // Creación de una instancia del contexto de la tienda para realizar operaciones de eliminación en la base de datos.
            var categoria = db.Categorias.Find(id);  // Busca la categoría que se desea eliminar utilizando su ID.
            if (categoria is not null)
            {
                db.Categorias.Remove(categoria);  // Marca la categoría para eliminación.
                db.SaveChanges();  // Guarda los cambios en la base de datos. Al llamar a "SaveChanges", Entity Framework Core genera y ejecuta la consulta SQL necesaria para eliminar el registro de la categoría en la tabla de categorías de la base de datos.
                Console.WriteLine($"Categoría '{categoria.Nombre}' eliminada correctamente.");
            }
            else
            {
                Console.WriteLine("Categoría no encontrada.");
            }
        }


        static void MostrarMenu()
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Insertar nueva categoría");
            Console.WriteLine("2. Insertar nuevo producto");
            Console.WriteLine("3. Leer todos los productos");
            Console.WriteLine("4. Leer un producto por ID");
            Console.WriteLine("5. Mostrar categoría con productos");
            Console.WriteLine("6. Buscar productos por descripción");
            Console.WriteLine("7. Buscar productos por precio");
            Console.WriteLine("8. Actualizar un producto");
            Console.WriteLine("9. Eliminar un producto");
            Console.WriteLine("10. Eliminar una categoría");
            Console.WriteLine("0. Salir");
        }

        static void GestionarMenu()
        {
            int opcion;
            do
            {
                MostrarMenu();
                Console.Write("Ingrese su opción: ");
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Ingrese el nombre de la categoría: ");
                            string nombreCategoria = Console.ReadLine() ?? string.Empty;
                            Console.Write("Ingrese la descripción de la categoría: ");
                            string descripcionCategoria = Console.ReadLine() ?? string.Empty;
                            EjemploInsertarCategoria(nombreCategoria, descripcionCategoria);
                            break;
                        case 2:
                            Console.Write("Ingrese el nombre del producto: ");
                            string nombreProducto = Console.ReadLine() ?? string.Empty;
                            Console.Write("Ingrese la descripción del producto: ");
                            string descripcionProducto = Console.ReadLine() ?? string.Empty;
                            Console.Write("Ingrese el precio del producto: ");
                            decimal precioProducto = decimal.Parse(Console.ReadLine() ?? "0");
                            Console.Write("Ingrese el stock del producto: ");
                            int stockProducto = int.Parse(Console.ReadLine() ?? "0");
                            Console.Write("Ingrese el ID de la categoría del producto: ");
                            int categoriaIdProducto = int.Parse(Console.ReadLine() ?? "0");
                            EjemploInsertarProducto(nombreProducto, descripcionProducto, precioProducto, stockProducto, categoriaIdProducto);
                            break;
                        case 3:
                            EjemploLeerProductos();
                            break;
                        case 4:
                            Console.Write("Ingrese el ID del producto a leer: ");
                            int idProductoLeer = int.Parse(Console.ReadLine() ?? "0");
                            EjemploLeerUnProducto(idProductoLeer);
                            break;
                        case 5:
                            Console.Write("Ingrese el ID de la categoría a mostrar con productos: ");
                            int idCategoriaMostrar = int.Parse(Console.ReadLine() ?? "0");
                            MostrarCategoriaConProductos(idCategoriaMostrar);
                            break;
                        case 6:
                            Console.Write("Ingrese el texto a buscar en la descripción de los productos: ");
                            string textoBuscarDescripcion = Console.ReadLine() ?? string.Empty;
                            BuscarProductosPorDescripcion(textoBuscarDescripcion);
                            break;
                        case 7:
                            Console.Write("Ingrese el precio mínimo para buscar productos: ");
                            decimal precioMinimoBuscar = decimal.Parse(Console.ReadLine() ?? "0");
                            Console.Write("Ingrese el precio máximo para buscar productos: ");
                            decimal precioMaximoBuscar = decimal.Parse(Console.ReadLine() ?? "0");
                            BuscarProductosPorPrecio(precioMinimoBuscar, precioMaximoBuscar);
                            break;
                        case 8:
                            Console.WriteLine("Ingrese el ID del producto a actualizar: ");
                            int idProductoActualizar = int.Parse(Console.ReadLine() ?? "0");
                            Console.WriteLine("Ingrese el nuevo precio del producto: ");
                            decimal nuevoPrecio = decimal.Parse(Console.ReadLine() ?? "0");
                            Console.WriteLine("Ingrese el nuevo stock del producto: ");
                            int nuevoStock = int.Parse(Console.ReadLine() ?? "0");
                            ActualizarProducto(idProductoActualizar, nuevoPrecio, nuevoStock);
                            break;
                        case 9:
                            Console.WriteLine("Ingrese el ID del producto a eliminar: ");
                            int idProductoEliminar = int.Parse(Console.ReadLine() ?? "0");
                            EliminarProducto(idProductoEliminar);
                            break;
                        case 10:
                            Console.WriteLine("Ingrese el ID de la categoría a eliminar: ");
                            int idCategoriaEliminar = int.Parse(Console.ReadLine() ?? "0");
                            EliminarCategoria(idCategoriaEliminar);
                            break;
                        case 0:
                            Console.WriteLine("Saliendo del programa...");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida. Por favor, ingrese un número.");
                }
            } while (opcion != 0);
        }

        // Ejemplo de consulta avanzada utilizando LINQ y Entity Framework Core para obtener un resumen de productos por categoría, incluyendo la cantidad de productos, el precio promedio, el precio máximo y el precio mínimo para cada categoría. La consulta se agrupa por categoría y se ordena por la cantidad de productos en orden descendente.
        // El resultado se muestra en la consola con los detalles de cada categoría y sus estadísticas correspondientes.
        // Sería equivalente a la siguiente consulta SQL:
        // Select Categorias.Nombre as Categoria, count(Productos.Id) as CantidadProductos,
        //    avg(Productos.Precio) as PrecioPromedio,
        //    max(Productos.Precio) as PrecioMaximo,
        //    min(Productos.Precio) as PrecioMinimo
        // from Productos, Categorias
        // where Productos.CategoriaId = Categorias.Id
        // group by CategoriaId, Categorias.Nombre
        // Order by CantidadProductos desc

        static void ConsultaAvanzada()  // Ejemplo LINQ + EF Core
        {
            using var db = new TiendaContext();  // Creación de una instancia del contexto de la tienda para realizar consultas avanzadas en la base de datos.

            // Agrupar productos por categoría y calcular estadísticas
            var resumen = db.Productos
                .Include(e => e.Categoria)  // Incluye la relación con la categoría para acceder a los datos de la categoría en la consulta.
                .GroupBy(e => e.Categoria.Nombre)  // Agrupa los productos por el nombre de la categoría.
                .Select(g => new   // Proyección de los resultados en una nueva clase anónima que contiene la categoría, la cantidad de productos, el precio promedio, el precio máximo y el precio mínimo para cada grupo de productos.
                {
                    Categoria = g.Key,
                    CantidadProductos = g.Count(),
                    PrecioPromedio = g.Average(p => p.Precio),
                    PrecioMaximo = g.Max(p => p.Precio),
                    PrecioMinimo = g.Min(p => p.Precio)
                })
                .OrderByDescending(e => e.CantidadProductos)  // Ordena los resultados por la cantidad de productos en orden descendente.
                .ToList();  // Ejecuta la consulta y obtiene una lista de resultados.

            foreach (var item in resumen)
            {
                Console.WriteLine($"Categoría: {item.Categoria}, Cantidad de Productos: {item.CantidadProductos}, Precio Promedio: {item.PrecioPromedio:C}, Precio Máximo: {item.PrecioMaximo:C}, Precio Mínimo: {item.PrecioMinimo:C}");
            }
        }


        static List<Producto> PaginacionesOrdenadasNombre(int pagina, int tamanyo)
        {
            using var db = new TiendaContext();
            return db.Productos
                .OrderBy(p => p.Nombre)
                .Skip((pagina - 1) * tamanyo)
                .Take(tamanyo)
                .ToList();
        }

        static void Main(string[] args)
        {
            // CRUD sobre la base de datos utilizando Entity Framework Core. En este caso, se muestra un ejemplo de inserción de una nueva categoría en la base de datos utilizando el método "EjemploInsertar". Este método crea una nueva instancia de la clase "Categoria", la agrega al DbSet "Categorias" del contexto de la tienda, y luego llama a "SaveChanges" para guardar los cambios en la base de datos. Puedes ejecutar este código para insertar una nueva categoría llamada "Deportes" con su descripción correspondiente.
            // CRUD (Create, Read, Update, Delete) es un acrónimo que se refiere a las operaciones básicas que se pueden realizar en una base de datos. En este caso, el código muestra cómo realizar la operación de "Create" (Crear) para insertar un nuevo registro en la tabla de categorías de la base de datos utilizando Entity Framework Core.
            // Create
            // EjemploInsertarCategoria("Ordenadores", "PCs y portátiles.");  // Llamada al método que inserta una nueva categoría en la base de datos. (Create)
            // EjemploInsertarProducto("Bicicleta", "Bicicleta de montaña para adultos.", 299.99m, 15, 4);  // Llamada al método que inserta un nuevo producto en la base de datos. (Create
            // Read
            // EjemploLeerProductos();  // Llamada al método que lee y muestra todos los productos de la base de datos. (Read)
            // EjemploLeerUnProducto(1); // Llamada al método que lee y muestra un producto específico de la base de datos utilizando su ID. (Read)
            // MostrarCategoriaConProductos(1);  // Llamada al método que muestra una categoría junto con sus productos asociados utilizando el método "Include" para cargar la relación entre categorías y productos. (Read)
            // BuscarProductosPorDescripcion("para");  // Llamada al método que busca productos por su descripción utilizando el método "Where" para filtrar los productos que contienen un texto específico en su descripción. (Read)
            // BuscarProductosPorPrecio(100m, 500m);  // Llamada al método que busca productos por su precio utilizando el método "Where" para filtrar los productos que tienen un precio dentro de un rango específico. (Read)
            // Update
            // ActualizarProducto(1, 649.99m, 45);  // Llamada al método que actualiza un producto específico en la base de datos utilizando su ID. El método busca el producto, actualiza sus propiedades (precio y stock), y luego guarda los cambios en la base de datos. (Update)
            // Delete
            // EliminarProducto(1);  // Llamada al método que elimina un producto específico de la base de datos utilizando su ID. El método busca el producto, lo marca para eliminación, y luego guarda los cambios en la base de datos. (Delete)
            // EliminarCategoria(5);  // Llamada al método que elimina una categoría específica de la base de datos utilizando su ID. El método busca la categoría, la marca para eliminación, y luego guarda los cambios en la base de datos. (Delete)
            // EliminarCategoria(4);  // Si eliminas una categoría que tiene productos asociados, se eliminarán automáticamente todos los productos relacionados debido a la configuración de eliminación en cascada definida en la relación entre categorías y productos. Esto significa que al eliminar la categoría con ID 4, todos los productos que pertenecen a esa categoría también serán eliminados de la base de datos. Es importante tener cuidado al realizar esta operación, ya que puede resultar en la pérdida de datos si no se tiene en cuenta la relación entre las entidades.
            GestionarMenu();
            // ConsultaAvanzada();
        }
    }
}
