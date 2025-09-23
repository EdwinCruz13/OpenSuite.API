using Entidades.Configuraciones;
using Entidades.Seguridad.Usuarios;

namespace Entidades.Seguridad.Permisos
{
    public class UsuarioEmpresa
    {
        public Usuario Usuario { get; set; } = null!;

        public Empresa Empresa { get; set; } = null!;

        public DateTime FechaDesde { get; set; }

        public DateTime? FechaHasta { get; set; }

        public bool esTemporal { get; set; }

        public DateTime? FechaGrabado { get; set; }

        

       
    }
}