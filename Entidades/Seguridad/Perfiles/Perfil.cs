using Entidades.Seguridad.Permisos;

namespace Entidades.Seguridad.Perfiles
{
    public class Perfil
    {
        public int PerfilID { get; set; }

        public int EmpresaID { get; set; }

        public int nPerfil { get; set; }

        public string? Codigo { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? FechaGrabado { get; set; }

        public List<Permiso> Permiso { get; set; } = new List<Permiso>();

        public List<UsuarioPerfil> UsuarioPerfil { get; set; } = new List<UsuarioPerfil>();
    }
}