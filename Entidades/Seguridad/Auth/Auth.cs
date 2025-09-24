using Entidades.Seguridad.Auth;
using Entidades.Seguridad.Perfiles;
using Entidades.Seguridad.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Seguridad.Authentication
{
    /// <summary>
    /// representa la autenticación de un usuario, incluyendo su token, perfiles y permisos.
    /// </summary>
    public class Auth
    {
        public String Token { get; set; } = string.Empty;
        public UsuarioAutenticado Usuario { get; set; }
        public List<String> Perfiles { get; set; } = new List<String>();
        public List<String> Permisos { get; set; } = new List<String>();
    }
}
