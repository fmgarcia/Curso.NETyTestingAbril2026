using System.Text;

namespace POOLinq
{
    internal class Program
    {

        static void Ejercicio1()
        {
            List<Venta> ventas = new List<Venta>
            {
                new Venta("Smartphone", "Electrónica", 800.00, 10, new DateTime(2024, 2, 20)),
                new Venta("Laptop", "Electrónica", 1200.00, 49, new DateTime(2024, 1, 15)),
                new Venta("Camiseta", "Ropa", 25.00, 50, new DateTime(2024, 3, 5)),
                new Venta("Pantalones", "Ropa", 40.00, 30, new DateTime(2024, 4, 10)),
                new Venta("Sofá", "Muebles", 500.00, 2, new DateTime(2024, 5, 25)),
                new Venta("Sillas", "Muebles", 200.00, 4, new DateTime(2024, 5, 25)),
                new Venta("Mesa de comedor", "Muebles", 300.00, 3, new DateTime(2024, 6, 30)),
                new Venta("Auriculares", "Electrónica", 150.00, 20, new DateTime(2024, 7, 15)),
                new Venta("Zapatos", "Ropa", 60.00, 40, new DateTime(2024, 8, 20)),
                new Venta("Silla de oficina", "Muebles", 200.00, 5, new DateTime(2024, 9, 10)),
                new Venta("Tablet", "Electrónica", 400.00, 15, new DateTime(2024, 10, 5)),
                new Venta("Laptop", "Electrónica", 1000.00, 2, new DateTime(2025, 1, 15))
            };

            // Las 5 ventas más caras
            ventas
                .OrderByDescending(p => p.Precio * p.Cantidad)
                .Take(5)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p}: Total Venta = {p.Precio * p.Cantidad}"));

            // Total de ventas por categoría
            var totalbycategory = ventas.GroupBy(p => p.Categoria);

            Console.WriteLine("Total By Category:");
            foreach (var category in totalbycategory)
            {
                Console.WriteLine($"- {category.Key}: ${category.Sum(s => s.Precio * s.Cantidad):F2}");
            }

            Console.WriteLine("Total By Category2:");
            ventas
                .GroupBy(p => p.Categoria)
                .ToList()
                .ForEach(category => Console.WriteLine($"- {category.Key}: ${category.Sum(s => s.Precio * s.Cantidad):F2}"));

            Console.WriteLine("Total By Category3:");
            ventas
                .GroupBy(p => p.Categoria)
                .ToList()
                .ForEach(category => Console.WriteLine($"- {category.Key}: ${category.Aggregate(0.0, (total, venta) => total + venta.Precio * venta.Cantidad):F2}"));

            // Producto más vendido
            Console.WriteLine("¡¡Producto Mas Vendido!!");
            ventas
                .GroupBy(p => new { p.Producto, p.Categoria })  // Agrupamos por producto y categoría para evitar confusiones entre productos con el mismo nombre en diferentes categorías
                .OrderByDescending(g => g.Sum(v => v.Cantidad)) // Ordenamos por la cantidad total vendida de cada producto
                .Take(1) // Tomamos el producto más vendido
                .ToList() // Convertimos a lista para poder usar ForEach
                .ForEach(e => Console.WriteLine($"- {e.Key.Producto}/{e.Key.Categoria}: {e.Sum(v => v.Cantidad)} unidades"));

            // Ventas por mes
            Console.WriteLine("Ventas por Mes:");
            ventas
                .GroupBy(p => new { p.Fecha.Year, p.Fecha.Month }) // Agrupamos por año y mes para obtener las ventas mensuales
                .OrderBy(g => g.Key.Year) // Ordenamos por año 
                .ThenBy(g => g.Key.Month) // Luego por mes dentro de cada año
                .ToList()
                .ForEach(m => Console.WriteLine($"- {m.Key.Month}/{m.Key.Year}: ${m.Sum(s => s.Precio * s.Cantidad):F2}"));

        }

        static void Ejercicio2()
        {
            string texto = "Hola mundo, hola a todos. Este es un texto de prueba para contar palabras. ¡Hola!";
            string texto2 = "!;";
            string texto3 = "a e i o u á é í ó ú à è ì ò ù ä ë ï ö ü â ê î ô û !;-";

            // Contador de palabras utilizando el método ContarPalabras de la clase UtilidadesTextos
            var resultado = UtilidadesTextos.ContarPalabras(texto);
            foreach (var palabra in resultado)
            {
                Console.WriteLine($"Palabra: '{palabra.Key}', Cantidad: {palabra.Value}");
            }

            // Palabra más frecuente utilizando el método PalabraMasFrecuente de la clase UtilidadesTextos
            string palabraMasFrecuente = UtilidadesTextos.PalabraMasFrecuente(texto);
            Console.WriteLine($"Palabra más frecuente: {(palabraMasFrecuente == string.Empty ? "(No hay palabras)" : palabraMasFrecuente)}");

            // Palabras ordenadas alfabéticamente con al menos 4 letras utilizando el método OrdenarAlfabeticamentePalabrasNLetras de la clase UtilidadesTextos
            Console.WriteLine($"Palabras ordenadas alfabéticamente con al menos 4 letras:");
            var palabrasOrdenadas = UtilidadesTextos.OrdenarAlfabeticamentePalabrasNLetras(texto, 4);
            palabrasOrdenadas.ForEach(p => Console.WriteLine($"- {p}"));

            // Contador de vocales utilizando el método ContarVocales de la clase UtilidadesTextos
            int cantidadVocales = UtilidadesTextos.ContarVocales(texto); // 28
            Console.WriteLine($"El número de vocales en el texto es: {cantidadVocales}");

        }

        static void Main(string[] args)
        {
            //Ejercicio1();
            Ejercicio2();
        }
    }
}
