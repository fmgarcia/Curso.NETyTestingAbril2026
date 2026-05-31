# 21 - NUnit

## Objetivo del modulo

En este proyecto se construye una biblioteca `Tienda.Core` y un proyecto de pruebas `Tienda.Core.Tests` con NUnit. El objetivo no es solo ejecutar pruebas, sino aprender a desarrollar el codigo de produccion y las pruebas en paralelo.

Al terminar, el estudiante habra practicado:

- Pruebas unitarias con `[Test]`.
- Aserciones con `Assert.That`.
- Pruebas parametrizadas con `[TestCase]` y `[TestCaseSource]`.
- Preparacion y limpieza con `[SetUp]`, `[TearDown]`, `[OneTimeSetUp]` y `[OneTimeTearDown]`.
- Pruebas asincronas.
- Dobles de prueba manuales.
- Pruebas de integracion con SQLite en memoria.
- Categorias, pruebas ignoradas, repeticion y ejecucion filtrada.

## Iniciacion

### Requisitos

- Visual Studio Community con la carga de trabajo `.NET desktop development` o `ASP.NET and web development`.
- SDK de .NET 10.
- Acceso a NuGet para restaurar paquetes.

### Estructura final

```text
21-NUnit-Tienda/
  Tienda.NUnit.sln
  src/
    Tienda.Core/
      CalculadoraDescuentos.cs
      Carrito.cs
      PedidoService.cs
      Producto.cs
      ProductoRepository.cs
      ProductoService.cs
      ReservaService.cs
  tests/
    Tienda.Core.Tests/
      Unitarias/
      Integracion/
      TestData/
      Properties/
```

### Crear la solucion en Visual Studio Community

1. Crea una solucion vacia llamada `Tienda.NUnit`.
2. Agrega un proyecto `Class Library` llamado `Tienda.Core`.
3. Agrega un proyecto `NUnit Test Project` llamado `Tienda.Core.Tests`.
4. En `Tienda.Core.Tests`, agrega una referencia de proyecto a `Tienda.Core`.
5. En `Tienda.Core`, instala el paquete `Microsoft.Data.Sqlite`.
6. En `Tienda.Core.Tests`, comprueba que existan los paquetes `NUnit`, `NUnit3TestAdapter`, `Microsoft.NET.Test.Sdk`, `NUnit.Analyzers` y `coverlet.collector`.
7. Crea las carpetas `Unitarias`, `Integracion`, `TestData` y `Properties` dentro del proyecto de pruebas.

### Crear la solucion por consola

```powershell
dotnet new sln -n Tienda.NUnit -f sln
dotnet new classlib -n Tienda.Core -o src/Tienda.Core --framework net10.0
dotnet new nunit -n Tienda.Core.Tests -o tests/Tienda.Core.Tests --framework net10.0
dotnet sln Tienda.NUnit.sln add src/Tienda.Core/Tienda.Core.csproj tests/Tienda.Core.Tests/Tienda.Core.Tests.csproj
dotnet add tests/Tienda.Core.Tests/Tienda.Core.Tests.csproj reference src/Tienda.Core/Tienda.Core.csproj
dotnet add src/Tienda.Core/Tienda.Core.csproj package Microsoft.Data.Sqlite
```

## Desarrollo paso a paso

### Paso 1. Primera clase de negocio

Crea `src/Tienda.Core/CalculadoraDescuentos.cs`.

La clase debe exponer `AplicarDescuento(decimal precio, decimal porcentaje)`. Empieza con el caso feliz:

- Si el precio es `100` y el porcentaje es `10`, el resultado debe ser `90`.
- Si el precio es negativo, debe lanzar `ArgumentOutOfRangeException`.
- Si el porcentaje es menor que `0` o mayor que `100`, tambien debe lanzar `ArgumentOutOfRangeException`.

### Paso 2. Primera prueba NUnit

Crea `tests/Tienda.Core.Tests/Unitarias/CalculadoraDescuentosTests.cs`.

Primero escribe una prueba simple:

```csharp
[Test]
public void AplicarDescuento_ConPrecio100YDescuento10_Devuelve90()
```

Explica el patron:

- Arrange: crear `CalculadoraDescuentos`.
- Act: llamar a `AplicarDescuento`.
- Assert: comprobar con `Assert.That(resultado, Is.EqualTo(90m))`.

Despues agrega la prueba de excepcion con `Throws.TypeOf<ArgumentOutOfRangeException>()`.

### Paso 3. Parametrizar pruebas

En la misma clase agrega una prueba con `[TestCase]`:

- `100, 0, 100`
- `100, 10, 90`
- `200, 25, 150`
- `50, 50, 25`

Luego agrega una fuente externa con `IEnumerable<TestCaseData>` y `[TestCaseSource]`. Este paso permite explicar por que no conviene duplicar la misma prueba para muchos datos.

### Paso 4. Ciclo de vida de una prueba

Crea `Carrito` en `src/Tienda.Core/Carrito.cs` y `CarritoTests` en `tests/Tienda.Core.Tests/Unitarias`.

Implementa:

- `TotalItems`.
- `EstaVacio`.
- `Agregar(Producto producto)`.
- `Limpiar()`.

En la prueba usa:

- `[OneTimeSetUp]` para explicar preparacion por clase.
- `[SetUp]` para crear un carrito nuevo antes de cada prueba.
- `[TearDown]` para limpiar despues de cada prueba.
- `[OneTimeTearDown]` para cerrar el ciclo.
- `Assert.Multiple` para comprobar varias propiedades del mismo resultado.

### Paso 5. Modelo de dominio compartido

Crea `Producto` en `src/Tienda.Core/Producto.cs` con:

- `Id`.
- `Nombre`.
- `Categoria`.
- `Precio`.
- `Stock`.
- `FechaCreacion`.

Usa esta clase en `Carrito`, `ReservaService` y `ProductoRepository`.

### Paso 6. Pruebas asincronas

Crea `ProductoService` con `ObtenerPrecioAsync(int productoId)`.

Pruebas a construir:

- `ObtenerPrecioAsync_ProductoExistente_DevuelvePrecio`.
- `ObtenerAsync_IdInvalido_LanzaExcepcion`.

Este paso sirve para explicar que una prueba NUnit puede devolver `Task` y usar `await`.

### Paso 7. Dobles de prueba manuales

Crea `IEmailSender` y `PedidoService`.

En `PedidoServiceTests`, crea un `FakeEmailSender` que guarde los destinatarios en una lista. La prueba debe confirmar que `ConfirmarPedidoAsync("ana@ejemplo.com")` intenta enviar un email a esa direccion.

Punto didactico: no hace falta introducir un framework de mocks para explicar el concepto de doble de prueba.

### Paso 8. Builder de datos de prueba

Crea `tests/Tienda.Core.Tests/TestData/ProductoBuilder.cs`.

Debe permitir construir productos con valores por defecto y modificar lo necesario:

- `ConNombre(string nombre)`.
- `SinStock()`.
- `Build()`.

Usalo en `ReservaServiceTests` para probar que reservar un producto sin stock lanza `InvalidOperationException`.

### Paso 9. Prueba de integracion con SQLite

Crea `ProductoRepository` en `Tienda.Core` usando `Microsoft.Data.Sqlite`.

En `ProductoRepositoryTests`:

1. Abre una conexion `Data Source=:memory:`.
2. Inicializa la tabla en `[SetUp]`.
3. Inserta un producto con `CrearAsync`.
4. Recuperalo con `ObtenerPorIdAsync`.
5. Cierra la conexion en `[TearDown]`.

Este paso marca la diferencia entre prueba unitaria y prueba de integracion: aqui se prueba tambien SQL, conexion y mapeo de datos.

### Paso 10. Categorias, ignorados y paralelismo

Crea `AtributosTests` para mostrar:

- `[Category("Unitarias")]`.
- `[Category("Integracion")]`.
- `[Ignore("...")]`.
- `[Repeat(3)]`.

Crea `Properties/AssemblyInfo.cs` con:

```csharp
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(4)]
```

## Ejecucion

Desde Visual Studio:

1. Compila la solucion.
2. Abre `Test > Test Explorer`.
3. Ejecuta todas las pruebas.
4. Filtra por nombre o categoria.

Desde consola:

```powershell
dotnet test
dotnet test --filter "Category=Unitarias"
dotnet test --filter "Category=Integracion"
dotnet test --collect:"XPlat Code Coverage"
```

Resultado esperado en este proyecto original:

```text
18 pruebas superadas, 1 prueba omitida
```

## Ejercicios

1. Agrega una clase `CalculadoraImpuestos` con IVA general, reducido y superreducido. Pruebala con `[TestCase]`.
2. Amplia `Carrito` para eliminar productos y calcular el total.
3. Agrega descuentos al carrito y prueba el total final con `Assert.Multiple`.
4. Haz que `ProductoService` simule un error asincrono para un producto inexistente y pruebalo.
5. Amplia `ProductoRepository` con un metodo `ObtenerTodosAsync`.
6. Crea una categoria nueva llamada `Lentas` y ejecuta solo esas pruebas.

## Resumen

| Concepto | En el proyecto |
| --- | --- |
| Test basico | `CalculadoraDescuentosTests` |
| Parametrizacion | `[TestCase]`, `[TestCaseSource]` |
| Ciclo de vida | `CarritoTests` |
| Pruebas async | `ProductoServiceTests` |
| Dobles de prueba | `PedidoServiceTests` |
| Builder | `ProductoBuilder` |
| Integracion | `ProductoRepositoryTests` |
| Categorias | `AtributosTests` |
| Ejecucion | `dotnet test` o Test Explorer |

## Guia para proyecto espejo

La forma recomendada para clase es abrir este proyecto original en un monitor y construir un proyecto espejo en paralelo:

1. Crea la solucion vacia.
2. Agrega `Tienda.Core`.
3. Agrega `Tienda.Core.Tests`.
4. Escribe una prueba roja.
5. Implementa el minimo codigo para ponerla en verde.
6. Refactoriza nombres y estructura.
7. Repite el ciclo con parametrizacion, setup, asincronia, dobles e integracion.
