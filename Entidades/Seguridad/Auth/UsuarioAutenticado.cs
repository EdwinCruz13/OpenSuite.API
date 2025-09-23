using Entidades.Seguridad.Modulos;
using Entidades.Seguridad.Perfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Seguridad.Auth
{
    /// <summary>
    /// Uusario autenticado con sus perfiles y acciones.
    /// </summary>
    public class UsuarioAutenticado
    {
        public String? Usuario { get; set; }
        public String? nUsuario { get; set; }
        public String? PhotoUrl { get; set; }
        public List<Perfil>? Perfiles { get; set; }
        public List<Accion>? Acciones { get; set; }
    }
}
