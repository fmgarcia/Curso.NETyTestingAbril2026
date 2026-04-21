// ============================================================
// Archivo: Program.cs
// Descripción: Punto de entrada de la aplicación.
//
// En .NET 6 y versiones posteriores se usan "Top-level statements":
// no hace falta declarar una clase ni un método Main() explícito.
// El compilador lo genera automáticamente por nosotros.
//
// La responsabilidad de este archivo es mínima y clara:
// crear la interfaz de usuario y arrancarla.
// Toda la lógica está en sus propias clases.
// ============================================================

// Creamos una instancia de la clase InterfazUsuario.
// 'new' reserva memoria y llama al constructor de la clase.
using CalculadoraBasica;

InterfazUsuario ui = new InterfazUsuario();

// Llamamos al método Ejecutar(), que contiene el bucle
// principal de la calculadora y no termina hasta que
// el usuario decide salir.
ui.Ejecutar();
