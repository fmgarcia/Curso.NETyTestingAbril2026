using System;
using System.Collections.Generic;
using System.Text;

namespace Json1405
{

    public class Rootobject
    {
        public string empresa { get; set; }
        public string fecha_creacion { get; set; }
        public bool activa { get; set; }
        public Proyecto[] proyectos { get; set; }
        public Configuracion_Sistema configuracion_sistema { get; set; }
        public Usuarios_Admin[] usuarios_admin { get; set; }
    }

    public class Configuracion_Sistema
    {
        public bool modo_depuracion { get; set; }
        public int max_intentos_conexion { get; set; }
        public Rutas_Almacenamiento rutas_almacenamiento { get; set; }
    }

    public class Rutas_Almacenamiento
    {
        public string temporal { get; set; }
        public string permanente { get; set; }
    }

    public class Proyecto
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public string[] tecnologias { get; set; }
        public float presupuesto { get; set; }
    }

    public class Usuarios_Admin
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
    }

}
