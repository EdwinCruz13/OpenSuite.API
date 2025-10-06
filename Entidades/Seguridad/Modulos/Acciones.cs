using Entidades.Seguridad.Permisos;

namespace Entidades.Seguridad.Modulos
{
    public class Accion
    {
        public int AccionesID { get; set; }

        public int SubModuloID { get; set; }

        public int ModuloID { get; set; }

        public string nAccion { get; set; } = null!;

        public string? Codigo { get; set; }
        public String Permiso { get; set; } = null!;

        public string? Descripcion { get; set; }
        public string? Icon { get; set; }

        public String RouterLink { get; set; } = null!;
        public String urlApi { get; set; } = null!;
        public String MethodType { get; set; } = null!; //post, get, put, delete, bla bla bla

        public DateTime? FechaGrabado { get; set; }


        //public SubModulo SubModulo { get; set; }

        //public virtual ICollection<Permiso> Permiso { get; set; } = new List<Permiso>();
    }
}