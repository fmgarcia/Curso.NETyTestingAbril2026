using Linq4_0206.Entities;

namespace Linq4_0206
{
    internal class Program
    {

        static List<Empleado> empleados = new List<Empleado>()
        {
            new Empleado(1, "Juan", "Flores", 1, 50000),
            new Empleado(2, "María", "García", 1, 55000),
            new Empleado(3, "Pedro", "López", 2, 60000),
            new Empleado(4, "Ana", "Martínez", 2, 65000),
            new Empleado(5, "Luis", "González", 3, 70000),
            new Empleado(6, "Sofía", "Rodríguez", 3, 75000),
        };

        static List<Departamento> departamentos = new List<Departamento>()
        {
            new Departamento(1, "Recursos Humanos"),
            new Departamento(2, "Finanzas"),
            new Departamento(3, "Tecnología"),
        };

        // Método para mostrar empleados con su departamento utilizando LINQ
        public static void EmpleadosConDepartamento()
        {
            var consulta = empleados  // Sintaxis de método Linq
                .Join(departamentos,
                    e => e.DepartamentoId,
                    d => d.DepartamentoId,
                    (e, d) => new
                    {
                        EmpleadoNombre = $"{e.Nombre} {e.Apellido}",
                        DepartamentoNombre = d.Nombre,
                        Salario = e.Salario
                    });

            var consulta2 = from e in empleados  // Sintaxis de consulta
                            join d in departamentos on e.DepartamentoId equals d.DepartamentoId
                            select new
                            {
                                EmpleadoNombre = $"{e.Nombre} {e.Apellido}",
                                DepartamentoNombre = d.Nombre,
                                Salario = e.Salario
                            };

            foreach (var item in consulta)
            {
                Console.WriteLine($"Empleado: {item.EmpleadoNombre}, Departamento: {item.DepartamentoNombre}, Salario: {item.Salario:C}");
            }
        }

        // Contar empleados por departamento utilizando LINQ
        static public void ContarEmpleadosPorDepartamento()
        {
            var consulta = empleados
                .GroupBy(e => e.DepartamentoId)
                .Select(g => new
                {
                    DepartamentoId = g.Key,
                    CantidadEmpleados = g.Count()
                });
            foreach (var item in consulta)
            {
                Console.WriteLine($"DepartamentoId: {item.DepartamentoId}, Cantidad de Empleados: {item.CantidadEmpleados}");
            }
        }


        // Salario total por departamento, junto con el nombre del departamento utilizando LINQ
        static public void SalarioTotalPorDepartamento()
        {
            var consulta = empleados
                .GroupBy(e => e.DepartamentoId)
                .Select(g => new
                {
                    DepartamentoId = g.Key,
                    SalarioTotal = g.Sum(e => e.Salario)
                })
                .Join(departamentos,
                    s => s.DepartamentoId,
                    d => d.DepartamentoId,
                    (s, d) => new
                    {
                        DepartamentoId = s.DepartamentoId,
                        SalarioTotal = s.SalarioTotal,
                        DepartamentoNombre = d.Nombre
                    });
            foreach (var item in consulta)
            {
                Console.WriteLine($"Departamento: {item.DepartamentoId}-{item.DepartamentoNombre}, Salario Total: {item.SalarioTotal:C}");
            }
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            EmpleadosConDepartamento();
            ContarEmpleadosPorDepartamento();
            SalarioTotalPorDepartamento();
        }
    }
}
