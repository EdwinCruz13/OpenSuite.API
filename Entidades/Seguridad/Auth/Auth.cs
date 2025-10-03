using Entidades.Configuraciones;
using Entidades.Seguridad.Auth;
using Entidades.Seguridad.Modulos;
using Entidades.Seguridad.Perfiles;


namespace Entidades.Seguridad.Authentication
{
    /// <summary>
    /// representa la autenticación de un usuario, incluyendo su token, perfiles y permisos.
    /// </summary>
    public class Auth
    {
        public String Token { get; set; } = string.Empty;
        public UsuarioAutenticado Usuario { get; set; } = new UsuarioAutenticado();
        public Empresa Empresa { get; set; } = new Empresa();
        public List<Perfil> Perfiles { get; set; } = new List<Perfil>();
        public List<Accion> Acciones { get; set; } = new List<Accion>();
    }
}
