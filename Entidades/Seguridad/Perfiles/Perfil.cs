using Entidades.Seguridad.Permisos;

namespace Entidades.Seguridad.Perfiles
{
    public class Perfil
    {
        public int PerfilID { get; set; }

        public int EmpresaID { get; set; }

        public string nPerfil { get; set; }

        public string? Codigo { get; set; }

        public string? Descripcion { get; set; }
    }
}