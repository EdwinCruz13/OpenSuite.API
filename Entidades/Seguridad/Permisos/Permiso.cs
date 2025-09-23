using Entidades.Catalogos;
using Entidades.Seguridad.Modulos;
using Entidades.Seguridad.Perfiles;

namespace Entidades.Seguridad.Permisos
{
    public class Permiso
    {
        public Perfil Perfil { get; set; } = null!;

        public Accion Accion { get; set; } = null!;

        public SubModulo SubModulo { get; set; } = null!;

        public Modulo Modulo { get; set; } = null!;

        public virtual Estado Estado { get; set; } = null!;

        public DateTime FechaDesde { get; set; }

        public DateTime? FechaHasta { get; set; }

        public DateTime? FechaGrabado { get; set; }

 

        
    }
}