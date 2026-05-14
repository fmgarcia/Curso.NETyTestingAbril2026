using System;
using System.Collections.Generic;
using System.Text;

namespace Json1405
{
    public class ModeloDatos
    {
        // MODELO DE DATOS: Definimos un record para representar la estructura de los datos de la empresa
        public record DatosEmpresa(
            string Empresa,
            DateTime FechaCreacion,
            bool Activa,
            List<Proyecto> Proyectos,
            ConfiguracionSistena ConfiguracionSistema,
            List<UsuarioAdmin> UsuariosAdmin

        );

        public record Proyecto(
            string Id,
            string Nombre,
            string Estado,
            List<string> Tecnologias,
            decimal Presupuesto
        );

        public record ConfiguracionSistena(
            bool ModoDepuracion,
            int MaxIntentosConexion,
            RutasAlmacenamiento RutasAlmacenamiento
        );

        public record RutasAlmacenamiento(
            string Temporal,
            string Permanente
        );

        public record UsuarioAdmin(
            int Id,
            string Nombre,
            string Email
        );
    }
}
