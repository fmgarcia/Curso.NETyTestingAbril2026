# 22 - xUnit

## Objetivo del modulo

Este proyecto muestra como construir pruebas con xUnit v3 en una solucion con codigo de dominio, base de datos en memoria y una API minima. La idea es comparar el estilo de xUnit con NUnit y mostrar como cambian los mecanismos de setup, cleanup, fixtures y datos de prueba.

Al terminar, el estudiante habra practicado:

- `[Fact]` para pruebas fijas.
- `[Theory]`, `[InlineData]` y `[MemberData]` para pruebas con datos.
- Constructor y `IDisposable` como setup y cleanup por prueba.
- `IAsyncLifetime` para recursos asincronos.
- `IClassFixture<T>` y `ICollectionFixture<T>` para compartir contexto.
- `ITestOutputHelper` para trazas de diagnostico.
- Pruebas HTTP con `WebApplicationFactory<Program>`.

## Iniciacion

### Requisitos

- Visual Studio Community.
- SDK de .NET 10.
- Acceso a NuGet.

### Estructura final

```text
22-XUnit-Tienda/
  Tienda.XUnit.sln
  src/
    Tienda.Core/
      Calculadora.cs
      CalculadoraDescuentos.cs
      Carrito.cs
      PedidoProcessor.cs
      Producto.cs
      ProductoRepository.cs
      PromocionService.cs
    Tienda.Api/
      Program.cs
  tests/
    Tienda.Core.Tests/
      Api/
      Fixtures/
      Integracion/
      Unitarias/
      xunit.runner.json
```

### Crear la solucion en Visual Studio Community

1. Crea una solucion vacia llamada `Tienda.XUnit`.
2. Agrega un proyecto `Class Library` llamado `Tienda.Core`.
3. Agrega un proyecto `ASP.NET Core Empty` llamado `Tienda.Api`.
4. Agrega un proyecto `Class Library` llamado `Tienda.Core.Tests`.
5. En `Tienda.Api`, agrega una referencia a `Tienda.Core`.
6. En `Tienda.Core.Tests`, agrega referencias a `Tienda.Core` y `Tienda.Api`.
7. En `Tienda.Core`, instala `Microsoft.Data.Sqlite`.
8. En `Tienda.Core.Tests`, instala `xunit.v3`, `xunit.runner.visualstudio`, `Microsoft.NET.Test.Sdk` y `Microsoft.AspNetCore.Mvc.Testing`.
9. En `Tienda.Core.Tests`, establece `OutputType` como `Exe`. xUnit v3 usa Microsoft Testing Platform y necesita ejecutable.
10. Agrega `xunit.runner.json` y configuralo para copiarse al directorio de salida.

### Crear la solucion por consola

```powershell
dotnet new sln -n Tienda.XUnit -f sln
dotnet new classlib -n Tienda.Core -o src/Tienda.Core --framework net10.0
dotnet new web -n Tienda.Api -o src/Tienda.Api --framework net10.0
dotnet new classlib -n Tienda.Core.Tests -o tests/Tienda.Core.Tests --framework net10.0
dotnet sln Tienda.XUnit.sln add src/Tienda.Core/Tienda.Core.csproj src/Tienda.Api/Tienda.Api.csproj tests/Tienda.Core.Tests/Tienda.Core.Tests.csproj
dotnet add src/Tienda.Api/Tienda.Api.csproj reference src/Tienda.Core/Tienda.Core.csproj
dotnet add tests/Tienda.Core.Tests/Tienda.Core.Tests.csproj reference src/Tienda.Core/Tienda.Core.csproj src/Tienda.Api/Tienda.Api.csproj
dotnet add src/Tienda.Core/Tienda.Core.csproj package Microsoft.Data.Sqlite
dotnet add tests/Tienda.Core.Tests/Tienda.Core.Tests.csproj package xunit.v3
dotnet add tests/Tienda.Core.Tests/Tienda.Core.Tests.csproj package xunit.runner.visualstudio
dotnet add tests/Tienda.Core.Tests/Tienda.Core.Tests.csproj package Microsoft.NET.Test.Sdk
dotnet add tests/Tienda.Core.Tests/Tienda.Core.Tests.csproj package Microsoft.AspNetCore.Mvc.Testing
```

## Desarrollo paso a paso

### Paso 1. Primera clase y primer `[Fact]`

Crea `Calculadora` con:

- `Sumar(int a, int b)`.
- `Dividir(int a, int b)`.

Crea `CalculadoraTests` y escribe:

```csharp
[Fact]
public void Sumar_DosNumeros_DevuelveSuma()
```

Despues agrega la prueba de division por cero con `Assert.Throws<DivideByZeroException>`.

### Paso 2. Pruebas con datos

En `CalculadoraTests`, convierte varios casos de suma en una prueba `[Theory]`:

- `[InlineData(2, 3, 5)]`.
- `[InlineData(-2, 2, 0)]`.
- `[InlineData(10, 15, 25)]`.

Punto didactico: `[Fact]` describe un caso cerrado; `[Theory]` describe una regla que se comprueba con varios datos.

### Paso 3. Datos externos con `[MemberData]`

Crea `CalculadoraDescuentos` con `Aplicar(decimal precio, decimal porcentaje)`.

En `CalculadoraDescuentosTests`:

1. Crea un metodo estatico `CasosDescuento`.
2. Devuelve `IEnumerable<object[]>`.
3. Usa `[MemberData(nameof(CasosDescuento))]`.
4. Repite el ejercicio con un record `CasoDescuento`.

Tambien prueba que un precio negativo lanza `ArgumentOutOfRangeException` y comprueba `ParamName`.

### Paso 4. Setup y cleanup sin atributos

Crea `Carrito` y `CarritoTests`.

En xUnit, el constructor se ejecuta antes de cada prueba. `Dispose` se ejecuta despues de cada prueba.

Implementa:

- Constructor: crea un carrito nuevo.
- Prueba `Carrito_Nuevo_EstaVacio`.
- Prueba `Agregar_Producto_DejaDeEstarVacio`.
- `Dispose`: llama a `Limpiar`.

### Paso 5. Pruebas async y dobles sencillos

Crea:

- `IClock`.
- `FakeClock`.
- `PromocionService`.
- `PedidoProcessor`.

Pruebas:

- `EstaActiva_CuandoEsViernes_DevuelveTrue`.
- `ProcesarAsync_IdInvalido_LanzaExcepcion`.

Aqui se explica `Assert.True`, `Assert.ThrowsAsync` y el uso de un fake para controlar el tiempo.

### Paso 6. Salida de diagnostico

Crea `PedidoTests` e inyecta `ITestOutputHelper` por constructor.

Usa `_output.WriteLine("Creando pedido de prueba...")`.

Punto didactico: la salida no es para comprobar el resultado, sino para ayudar a diagnosticar fallos.

### Paso 7. Repositorio con SQLite en memoria

Crea `ProductoRepository` con:

- `CrearParaTestsAsync`.
- `InicializarAsync`.
- `CrearAsync`.
- `ObtenerTodosAsync`.
- `DisposeAsync`.

La base de datos debe vivir mientras la conexion SQLite en memoria permanezca abierta.

### Paso 8. `IAsyncLifetime`

Crea `TestDatabase` y `RepositorioTests`.

La clase de prueba implementa `IAsyncLifetime`:

- `InitializeAsync`: crea la base de datos.
- `DisposeAsync`: libera la conexion.

Esto permite explicar setup y cleanup asincrono por clase.

### Paso 9. `IClassFixture<T>`

Crea `DatabaseFixture` y `ProductoRepositoryTests`.

El fixture se crea una vez y se inyecta en el constructor de la clase de pruebas. Usalo para comprobar que `ObtenerTodosAsync` devuelve productos.

### Paso 10. Colecciones compartidas

Crea:

- `BaseDatosCollection` con `[CollectionDefinition("BaseDatos")]`.
- `ProductosRepositoryCollectionTests` con `[Collection("BaseDatos")]`.

Este paso explica como compartir un fixture entre varias clases de pruebas.

### Paso 11. API minima y prueba HTTP

En `Tienda.Api/Program.cs`, crea endpoints:

- `GET /`.
- `GET /api/productos`.
- `POST /api/productos`.

Al final agrega `public partial class Program { }` para que `WebApplicationFactory<Program>` pueda localizar la aplicacion.

En `ProductosApiTests`, usa:

- `IClassFixture<WebApplicationFactory<Program>>`.
- `factory.CreateClient()`.
- `GetAsync("/api/productos")`.
- `Assert.Equal(HttpStatusCode.OK, response.StatusCode)`.

## Ejecucion

Desde Visual Studio:

1. Compila la solucion.
2. Abre `Test > Test Explorer`.
3. Ejecuta todas las pruebas.
4. Filtra por clase, metodo o namespace.

Desde consola:

```powershell
dotnet test
dotnet test --filter "FullyQualifiedName~Calculadora"
dotnet test tests/Tienda.Core.Tests/Tienda.Core.Tests.csproj
```

Resultado esperado en este proyecto original:

```text
19 pruebas superadas
```

## Ejercicios

1. Agrega una prueba `[Theory]` para `Dividir`.
2. Crea una clase `CalculadoraImpuestos` y prueba varios tipos de IVA con `[MemberData]`.
3. Agrega un metodo `Eliminar` al carrito y pruebalo.
4. Amplia `PromocionService` para que acepte un rango de fechas.
5. Agrega `ObtenerPorIdAsync` al repositorio.
6. Crea un endpoint `GET /api/productos/{id}` y pruebalo con `WebApplicationFactory`.
7. Divide las pruebas lentas en una coleccion propia.

## Resumen

| Concepto | En el proyecto |
| --- | --- |
| Test fijo | `[Fact]` en `CalculadoraTests` |
| Test con datos | `[Theory]` e `[InlineData]` |
| Datos externos | `[MemberData]` |
| Setup por prueba | Constructor |
| Cleanup por prueba | `IDisposable` |
| Setup async | `IAsyncLifetime` |
| Fixture por clase | `IClassFixture<T>` |
| Fixture compartido | `ICollectionFixture<T>` |
| Prueba HTTP | `ProductosApiTests` |
| Configuracion runner | `xunit.runner.json` |

## Guia para proyecto espejo

Construye el proyecto espejo en este orden:

1. `Calculadora` y una prueba `[Fact]`.
2. `[Theory]` con varios casos.
3. `CalculadoraDescuentos` con `[MemberData]`.
4. `CarritoTests` con constructor y `Dispose`.
5. `PromocionService` con fake.
6. Repositorio SQLite con `IAsyncLifetime`.
7. Fixture compartido.
8. API minima y prueba HTTP.
