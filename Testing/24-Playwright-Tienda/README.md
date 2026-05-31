# 24 - Playwright

## Objetivo del modulo

Este proyecto muestra pruebas E2E y pruebas de API con Playwright para .NET y NUnit. Incluye una web local para que el estudiante pueda ejecutar todo desde Visual Studio Community sin depender de servicios externos.

Al terminar, el estudiante habra practicado:

- `PageTest` y `Expect`.
- Navegacion con `GotoAsync`.
- Locators accesibles: rol, label, texto y `data-testid`.
- Page Object con `IPage`.
- Pruebas de API con `IAPIRequestContext`.
- Screenshots, traces y storage state.
- Contextos de navegador con viewport, idioma, zona horaria y modo movil.
- Instalacion de navegadores de Playwright.

## Iniciacion

### Requisitos

- Visual Studio Community.
- SDK de .NET 10.
- Acceso a NuGet.
- Windows PowerShell o PowerShell.
- Navegadores de Playwright instalados con el script del proyecto.

### Estructura final

```text
24-Playwright-Tienda/
  Tienda.Playwright.sln
  src/
    Tienda.Core/
      Producto.cs
    Tienda.Api/
      Program.cs
  tests/
    Tienda.Playwright.Tests/
      Pages/
      Support/
      Tests/
```

### Crear la solucion en Visual Studio Community

1. Crea una solucion vacia llamada `Tienda.Playwright`.
2. Agrega un proyecto `Class Library` llamado `Tienda.Core`.
3. Agrega un proyecto `ASP.NET Core Empty` llamado `Tienda.Api`.
4. Agrega un proyecto `NUnit Test Project` llamado `Tienda.Playwright.Tests`.
5. En `Tienda.Api`, agrega referencia a `Tienda.Core`.
6. En `Tienda.Playwright.Tests`, agrega referencias a `Tienda.Api` y `Tienda.Core`.
7. En `Tienda.Playwright.Tests`, instala `Microsoft.Playwright.NUnit`.
8. Crea las carpetas `Pages`, `Support` y `Tests`.
9. Compila el proyecto de pruebas.
10. Ejecuta el script `playwright.ps1 install` para descargar navegadores.

### Crear la solucion por consola

```powershell
dotnet new sln -n Tienda.Playwright -f sln
dotnet new classlib -n Tienda.Core -o src/Tienda.Core --framework net10.0
dotnet new web -n Tienda.Api -o src/Tienda.Api --framework net10.0
dotnet new nunit -n Tienda.Playwright.Tests -o tests/Tienda.Playwright.Tests --framework net10.0
dotnet sln Tienda.Playwright.sln add src/Tienda.Core/Tienda.Core.csproj src/Tienda.Api/Tienda.Api.csproj tests/Tienda.Playwright.Tests/Tienda.Playwright.Tests.csproj
dotnet add src/Tienda.Api/Tienda.Api.csproj reference src/Tienda.Core/Tienda.Core.csproj
dotnet add tests/Tienda.Playwright.Tests/Tienda.Playwright.Tests.csproj reference src/Tienda.Api/Tienda.Api.csproj src/Tienda.Core/Tienda.Core.csproj
dotnet add tests/Tienda.Playwright.Tests/Tienda.Playwright.Tests.csproj package Microsoft.Playwright.NUnit
dotnet build
powershell -ExecutionPolicy Bypass -File tests/Tienda.Playwright.Tests/bin/Debug/net10.0/playwright.ps1 install
```

## Desarrollo paso a paso

### Paso 1. Modelo compartido

Crea `src/Tienda.Core/Producto.cs` con:

- `Id`.
- `Nombre`.
- `Categoria`.
- `Precio`.
- `Stock`.

### Paso 2. Aplicacion web local

En `src/Tienda.Api/Program.cs`, crea `ApiHost.Create(args)` y define:

- `GET /`: pagina de inicio con boton `Menu` y navegacion.
- `GET /login`: formulario de login.
- `POST /login`: redireccion a `/dashboard`.
- `GET /dashboard`: panel.
- `GET /productos`: listado.
- `GET /productos/nuevo`: formulario.
- `POST /productos`: crea producto o muestra error.
- `GET /api/productos`: API de lectura.
- `POST /api/productos`: API de creacion.

Agrega `public partial class Program { }` para que el proyecto pueda usarse desde pruebas si se amplia con `WebApplicationFactory`.

### Paso 3. Configuracion y servidor local

Crea:

- `Support/TestSettings.cs`.
- `Support/LocalApiServer.cs`.

`TestSettings.BaseUrl` debe leer `E2E_BASE_URL` si existe. Si no existe, `LocalApiServer` arranca la web en un puerto libre y actualiza la URL.

### Paso 4. Clase base Playwright

Crea `Support/PlaywrightTestBase.cs` heredando de `PageTest`.

Responsabilidades:

- Arrancar la API local en `[OneTimeSetUp]`.
- Detenerla en `[OneTimeTearDown]`.
- Sobrescribir `ContextOptions`.

Configura:

- `ViewportSize = 1440 x 900`.
- `Locale = "es-ES"`.
- `TimezoneId = "Europe/Madrid"`.
- `IgnoreHTTPSErrors = true`.

### Paso 5. Primer test

Crea `Tests/PrimerTest.cs`.

Prueba:

```csharp
PaginaPrincipal_MuestraTitulo
```

Flujo:

1. `await Page.GotoAsync(TestSettings.BaseUrl)`.
2. `await Expect(Page).ToHaveTitleAsync(new Regex("Tienda"))`.

Este paso valida que Playwright, navegador y servidor local funcionan.

### Paso 6. Tests de productos con locators accesibles

Crea `Tests/ProductosTests.cs`.

Construye las pruebas:

1. `CrearProducto_DatosValidos_ApareceEnListado`.
2. `CrearProducto_SinNombre_MuestraError`.
3. `Listado_TieneTituloYTotal`.

Usa:

- `Page.GetByLabel("Nombre")`.
- `Page.GetByRole(AriaRole.Button, new() { Name = "Guardar" })`.
- `Page.GetByText("El nombre es obligatorio")`.
- `Page.GetByTestId("total")`.

Punto didactico: Playwright favorece selectores parecidos a como un usuario percibe la pagina.

### Paso 7. Page Object

Crea `Pages/ProductosPage.cs`.

Metodos:

- `AbrirNuevoAsync()`.
- `CrearAsync(string nombre, string categoria, decimal precio, int stock)`.
- `Producto(string nombre)`.

Despues agrega la prueba `CrearProducto_ConPageObject`.

### Paso 8. Pruebas de API

Crea `Tests/ApiProductosTests.cs`.

Usa:

- `Playwright.APIRequest.NewContextAsync`.
- `request.GetAsync("/api/productos")`.
- `request.PostAsync("/api/productos", new() { DataObject = ... })`.

Pruebas:

- `ApiProductos_DevuelveOk`.
- `CrearProducto_DesdeApi`.

Punto didactico: no todo flujo necesita navegador. Playwright tambien permite probar la API con el mismo runner.

### Paso 9. Herramientas de depuracion

Crea `Tests/DebugTests.cs`.

Incluye:

- `GuardarScreenshot`.
- `GuardarTrace`.
- `GuardarEstadoLogin`.

Los artefactos se guardan en:

- `artifacts/productos.png`.
- `artifacts/trace.zip`.
- `auth/admin.json`.

Para abrir un trace:

```powershell
powershell -ExecutionPolicy Bypass -File tests/Tienda.Playwright.Tests/bin/Debug/net10.0/playwright.ps1 show-trace tests/Tienda.Playwright.Tests/artifacts/trace.zip
```

### Paso 10. Contexto movil

Crea `Tests/MobileTests.cs`.

Sobrescribe `ContextOptions` con:

- `Width = 390`.
- `Height = 844`.
- `IsMobile = true`.
- `HasTouch = true`.
- `DeviceScaleFactor = 3`.

Prueba que el boton `Menu` hace visible la navegacion.

## Ejecucion

Desde Visual Studio:

1. Compila la solucion.
2. Instala navegadores si aun no lo hiciste.
3. Abre `Test > Test Explorer`.
4. Ejecuta primero `PrimerTest`.
5. Ejecuta el proyecto completo.

Desde consola:

```powershell
dotnet build
powershell -ExecutionPolicy Bypass -File tests/Tienda.Playwright.Tests/bin/Debug/net10.0/playwright.ps1 install
dotnet test
dotnet test -- Playwright.LaunchOptions.Headless=false
dotnet test -- Playwright.BrowserName=chromium
dotnet test -- Playwright.BrowserName=firefox
dotnet test -- Playwright.BrowserName=webkit
```

Si solo instalaste Chromium, ejecuta con Chromium o instala el resto de navegadores antes de probar Firefox/WebKit.

Si quieres usar una web ya arrancada:

```powershell
$env:E2E_BASE_URL="http://localhost:7001"
dotnet test
```

Resultado esperado en este proyecto original:

```text
11 pruebas superadas
```

## Ejercicios

1. Agrega un campo `Descripcion` al formulario y prueba que se muestra en el listado.
2. Sustituye un locator por CSS y comparalo con `GetByRole` o `GetByLabel`.
3. Crea una prueba que use `Page.GetByPlaceholder("Buscar productos")`.
4. Guarda un video de una prueba usando `RecordVideoDir`.
5. Crea un contexto autenticado que reutilice `auth/admin.json`.
6. Agrega una prueba API para validar que el JSON contiene el producto creado.
7. Ejecuta el mismo test en Chromium, Firefox y WebKit.

## Resumen

| Concepto | En el proyecto |
| --- | --- |
| Test base | `PlaywrightTestBase` |
| Primer test | `PrimerTest` |
| Locators accesibles | `ProductosTests` |
| Page Object | `ProductosPage` |
| API testing | `ApiProductosTests` |
| Screenshot | `DebugTests.GuardarScreenshot` |
| Trace | `DebugTests.GuardarTrace` |
| Storage state | `DebugTests.GuardarEstadoLogin` |
| Mobile | `MobileTests` |
| Servidor local | `LocalApiServer` |

## Guia para proyecto espejo

Construye el proyecto espejo en este orden:

1. Web local minima.
2. `PlaywrightTestBase`.
3. Primer test de titulo.
4. Formulario y listado de productos.
5. Tests con locators accesibles.
6. Page Object.
7. Pruebas de API.
8. Screenshots y traces.
9. Contexto movil.
