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
        public int UsuarioID { get; set; }
        public String Usuario { get; set; } = string.Empty;
        public String nUsuario { get; set; } = string.Empty;
        public String PhotoUrl { get; set; } = string.Empty;
    }
}
