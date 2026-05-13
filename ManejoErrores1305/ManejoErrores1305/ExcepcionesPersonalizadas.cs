using System;
using System.Collections.Generic;
using System.Text;

namespace ManejoErrores1305
{
    // Excepción personalizada
    class SaldoInsuficienteException : Exception  // Excepción personalizada que hereda de Exception
    {
        public double SaldoActual { get; }
        public double MontoSolicitado { get; }

        public SaldoInsuficienteException(double saldo, double monto)
            : base($"Saldo insuficiente. Tienes {saldo:C2} y necesitas {monto:C2}")
        {
            SaldoActual = saldo;
            MontoSolicitado = monto;
        }
    }

    // Uso
    class CuentaBancaria
    {
        public double Saldo { get; private set; }

        public CuentaBancaria(double saldoInicial)
        {
            Saldo = saldoInicial;
        }

        public void Retirar(double monto)
        {
            if (monto <= 0)
                throw new ArgumentException("El monto debe ser positivo");

            if (monto > Saldo)
                throw new SaldoInsuficienteException(Saldo, monto);

            Saldo -= monto;
            Console.WriteLine($"Retirado: {monto:C2}. Saldo: {Saldo:C2}");
        }
    }
}
