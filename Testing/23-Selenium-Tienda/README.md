# 23 - Selenium

## Objetivo del modulo

Este proyecto muestra pruebas de extremo a extremo con Selenium WebDriver, NUnit y una aplicacion web local. La solucion incluye `Tienda.Api` para que el estudiante no dependa de una web externa ni de datos manuales.

Al terminar, el estudiante habra practicado:

- Crear y cerrar un `ChromeDriver`.
- Navegar a una pagina con `GoToUrl`.
- Localizar elementos con `By.Id`, `By.CssSelector`, `By.TagName` y `By.XPath`.
- Escribir texto, hacer click y leer contenido.
- Usar esperas explicitas con `WebDriverWait`.
- Aplicar el patron Page Object.
- Preparar datos por API antes de usar el navegador.
- Ejecutar en modo headless y guardar capturas en fallos.

## Iniciacion

### Requisitos

- Visual Studio Community.
- SDK de .NET 10.
- Google Chrome instalado.
- Acceso a NuGet.

Selenium Manager se encarga de localizar o descargar el driver compatible con Chrome.

### Estructura final

```text
23-Selenium-Tienda/
  Tienda.Selenium.sln
  src/
    Tienda.Core/
      Producto.cs
    Tienda.Api/
      Program.cs
  tests/
    Tienda.E2E.Tests/
      Pages/
      Support/
      Tests/
```

### Crear la solucion en Visual Studio Community

1. Crea una solucion vacia llamada `Tienda.Selenium`.
2. Agrega un proyecto `Class Library` llamado `Tienda.Core`.
3. Agrega un proyecto `ASP.NET Core Empty` llamado `Tienda.Api`.
4. Agrega un proyecto `NUnit Test Project` llamado `Tienda.E2E.Tests`.
5. En `Tienda.Api`, agrega referencia a `Tienda.Core`.
6. En `Tienda.E2E.Tests`, agrega referencias a `Tienda.Api` y `Tienda.Core`.
7. En `Tienda.E2E.Tests`, instala `Selenium.WebDriver` y `Selenium.Support`.
8. Crea las carpetas `Pages`, `Support` y `Tests`.

### Crear la solucion por consola

```powershell
dotnet new sln -n Tienda.Selenium -f sln
dotnet new classlib -n Tienda.Core -o src/Tienda.Core --framework net10.0
dotnet new web -n Tienda.Api -o src/Tienda.Api --framework net10.0
dotnet new nunit -n Tienda.E2E.Tests -o tests/Tienda.E2E.Tests --framework net10.0
dotnet sln Tienda.Selenium.sln add src/Tienda.Core/Tienda.Core.csproj src/Tienda.Api/Tienda.Api.csproj tests/Tienda.E2E.Tests/Tienda.E2E.Tests.csproj
dotnet add src/Tienda.Api/Tienda.Api.csproj reference src/Tienda.Core/Tienda.Core.csproj
dotnet add tests/Tienda.E2E.Tests/Tienda.E2E.Tests.csproj reference src/Tienda.Api/Tienda.Api.csproj src/Tienda.Core/Tienda.Core.csproj
dotnet add tests/Tienda.E2E.Tests/Tienda.E2E.Tests.csproj package Selenium.WebDriver
dotnet add tests/Tienda.E2E.Tests/Tienda.E2E.Tests.csproj package Selenium.Support
```

## Desarrollo paso a paso

### Paso 1. Modelo compartido

Crea `src/Tienda.Core/Producto.cs` con:

- `Id`.
- `Nombre`.
- `Categoria`.
- `Precio`.
- `Stock`.

Este modelo se usara en la web y en la API de datos de prueba.

### Paso 2. Aplicacion web local

En `src/Tienda.Api/Program.cs`, crea una aplicacion minima con:

- `GET /`: pagina de inicio.
- `GET /login`: formulario de login.
- `POST /login`: redireccion a `/dashboard`.
- `GET /dashboard`: panel de usuario.
- `GET /productos`: listado de productos.
- `GET /productos/nuevo`: formulario de producto.
- `POST /productos`: crea producto o muestra error si falta el nombre.
- `GET /api/productos`: devuelve productos.
- `POST /api/test/productos`: permite preparar datos desde las pruebas.

Extrae la creacion de la aplicacion a `ApiHost.Create(args)` para que las pruebas puedan arrancar la web dentro del mismo proceso.

### Paso 3. Configuracion de entorno

Crea `Support/TestSettings.cs`.

Debe exponer `BaseUrl`. Si existe la variable `E2E_BASE_URL`, se usa esa URL. Si no existe, se usa una URL local que se actualizara al arrancar el servidor de pruebas.

### Paso 4. Servidor local para pruebas

Crea `Support/LocalApiServer.cs`.

Responsabilidades:

1. Buscar un puerto libre.
2. Crear la web con `ApiHost.Create`.
3. Arrancarla con `StartAsync`.
4. Exponer la URL.
5. Pararla en `DisposeAsync`.

Asi los tests no necesitan que el estudiante pulse `F5` antes de ejecutar las pruebas.

### Paso 5. Clase base Selenium

Crea `Support/SeleniumTestBase.cs`.

Debe hacer:

- `[OneTimeSetUp]`: arrancar `LocalApiServer` si no hay `E2E_BASE_URL`.
- `[SetUp]`: crear `ChromeDriver` y `WebDriverWait`.
- `[TearDown]`: guardar captura si la prueba falla, cerrar y liberar el driver.
- `[OneTimeTearDown]`: detener el servidor local.

Configura Chrome:

- `--window-size=1920,1080`.
- `--headless=new` cuando `CI=true`.

### Paso 6. Primer test de navegador

Crea `Tests/PrimerTest.cs`.

Prueba:

```csharp
AbrirPaginaPrincipal_MuestraTitulo
```

Flujo:

1. Navegar a `TestSettings.BaseUrl`.
2. Comprobar que `Driver.Title` contiene `Inicio`.

Este es el test mas pequeno para validar que Selenium, Chrome y la web local funcionan.

### Paso 7. Page Object de login

Crea `Pages/LoginPage.cs`.

Metodos:

- `Abrir()`.
- `IniciarSesion(string email, string password)`.
- `EstaEnDashboard()`.

Usa:

- `By.Id("email")`.
- `By.Id("password")`.
- `By.CssSelector("button[type='submit']")`.
- `WebDriverWait` para esperar la URL `/dashboard`.

### Paso 8. Test de login

Crea `Tests/LoginTests.cs`.

Prueba:

```csharp
Login_ConCredencialesValidas_EntraEnDashboard
```

Este paso muestra como el test se vuelve mas legible cuando se delegan los detalles de Selenium en un Page Object.

### Paso 9. Tests de productos

Crea `Tests/ProductosTests.cs`.

Construye las pruebas en este orden:

1. `Listado_MuestraTitulo`: navegar a `/productos` y buscar el `h1`.
2. `CrearProducto_DatosValidos_MuestraProductoEnListado`: rellenar formulario, guardar y comprobar el listado.
3. `CrearProducto_SinNombre_MuestraError`: guardar sin nombre y comprobar `.validation-error`.
4. `SelectCheckboxYRadio_EjemploDeLocalizadores`: usar el formulario para practicar localizadores.

### Paso 10. Preparar datos por API

Crea `Support/TestDataApi.cs`.

Debe enviar un `POST` a `/api/test/productos`. Despues crea la prueba:

```csharp
BuscarProducto_ProductoExistente_ApareceEnResultados
```

Flujo:

1. Crear producto por API.
2. Navegar al listado.
3. Escribir en el buscador.
4. Localizar el texto con XPath.

Punto didactico: los datos de prueba deben prepararse de forma controlada, no depender de pruebas anteriores.

## Ejecucion

Desde Visual Studio:

1. Compila la solucion.
2. Abre `Test > Test Explorer`.
3. Ejecuta primero `PrimerTest`.
4. Ejecuta luego todo el proyecto.

Desde consola:

```powershell
dotnet test
dotnet test --filter "FullyQualifiedName~Productos"
$env:CI="true"; dotnet test
```

Si quieres usar una web ya arrancada:

```powershell
$env:E2E_BASE_URL="http://localhost:7001"
dotnet test
```

Resultado esperado en este proyecto original:

```text
7 pruebas superadas
```

## Ejercicios

1. Agrega una pagina `/ayuda` y prueba abrirla desde un enlace.
2. Agrega un boton de confirmacion con `alert` y prueba `SwitchTo().Alert()`.
3. Agrega un campo `Activo` al formulario y prueba un checkbox.
4. Agrega una categoria como `select` y prueba `SelectElement`.
5. Crea un Page Object `ProductosPage`.
6. Guarda capturas tambien al final de una prueba concreta, no solo en fallo.
7. Ejecuta los tests con `CI=true` y compara el comportamiento headless.

## Resumen

| Concepto | En el proyecto |
| --- | --- |
| Driver | `SeleniumTestBase` |
| Navegacion | `Driver.Navigate().GoToUrl(...)` |
| Localizadores | `ProductosTests` y `LoginPage` |
| Esperas | `WebDriverWait` |
| Page Object | `LoginPage` |
| Datos por API | `TestDataApi` |
| Servidor local | `LocalApiServer` |
| Capturas | `GuardarCaptura` |
| Headless | Variable `CI=true` |

## Guia para proyecto espejo

Construye el proyecto espejo en este orden:

1. Web local minima con `/` y `/productos`.
2. Primer test que comprueba el titulo.
3. Clase base con `ChromeDriver`.
4. Login Page Object.
5. Formulario de producto.
6. Tests de validacion.
7. Preparacion de datos por API.
8. Capturas en fallo y modo headless.
