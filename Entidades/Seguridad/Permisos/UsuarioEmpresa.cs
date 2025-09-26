using Entidades.Configuraciones;
using Entidades.Seguridad.Usuarios;

namespace Entidades.Seguridad.Permisos
{
    public class UsuarioEmpresa
    {
        public int UsuarioID { get; set; }

        public int EmpresaID { get; set; }

        public DateTime FechaDesde { get; set; }

        public DateTime? FechaHasta { get; set; }

        public bool esTemporal { get; set; }

        public DateTime? FechaGrabado { get; set; }

        

       
    }
}