using System;
using System.Collections.Generic;
using System.Text;

namespace POO1505
{
    internal class CuentaBancaria
    {

        public string Titular { get; set; } = "";
        public int Saldo
        {
            get; set
            {
                if (value < 0)
                {
                    Console.WriteLine("El saldo no puede ser negativo. Le asignaré 0.");
                    value = 0;
                }

            }
        } = 0;

        private int _deuda = 0; // Campo privado (convención: _camelCase)
        public int Deuda
        {
            get { return _deuda; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("La deuda no puede ser negativa. Le asignaré 0.");
                    _deuda = 0;
                }
                else
                {
                    _deuda = value;
                }
            }
        }

        public bool AsignarValorNegativoDeuda(int valor)
        {
            _deuda = valor;
            return true;
        }

        public bool AsignarValorNegativoSaldo(int valor)
        {
            Saldo = valor;
            return true;
        }


        public CuentaBancaria(string titular, int saldo)
        {
            Titular = titular;
            Saldo = saldo;
        }

        public CuentaBancaria(string titular, int saldo, int deuda)
        {
            {
                Titular = titular;
                Saldo = saldo;
                Deuda = deuda;
            }

        }


        public bool Retirar(int cantidad)
        {
            if (cantidad > Saldo)
            {
                Console.WriteLine("No tienes suficiente saldo para retirar esa cantidad.");
                return false;
            }
            else
            {
                Saldo -= cantidad;
                Console.WriteLine($"Has retirado {cantidad}. Saldo restante: {Saldo}");
                return true;
            }
        }

        public bool Ingresar(int cantidad)
        {
            if (cantidad < 0)
            {
                Console.WriteLine("No puedes ingresar una cantidad negativa.");
                return false;
            }
            else
            {
                Saldo += cantidad;
                Console.WriteLine($"Has ingresado {cantidad}. Saldo actual: {Saldo}");
                return true;
            }


        }


    }
}
