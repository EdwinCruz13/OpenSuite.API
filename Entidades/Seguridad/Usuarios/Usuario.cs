using Entidades.Catalogos;
using Entidades.Personas;
using Entidades.Seguridad.Perfiles;
using Entidades.Seguridad.Permisos;


namespace Entidades.Seguridad.Usuarios
{
    public class Usuario
    {
        public int UsuarioID { get; set; }

        public Persona Persona { get; set; } = null!;

        public int EstadoID { get; set; }

        public string Login { get; set; } = null!;

        public DateTime? FechaGrabado { get; set; }

        public Estado Estado { get; set; } = null!;
        public List<UsuarioPerfil> UsuarioPerfil { get; set; } = new List<UsuarioPerfil>(); // Relación con UsuarioPerfil, listado de perfiles asociadas a usuario  

        public virtual ICollection<UsuarioEmpresa> UsuarioEmpresa { get; set; } = new List<UsuarioEmpresa>();
    }

    /// <summary>
    /// Clase que representa un Data Transfer Object (DTO) para la entidad Usuario.
    /// servira para el guardado y la actualizacion
    /// </summary>
    public class UsuarioDTO
    {
        public int UsuarioID { get; set; }
        public int  PersonaID { get; set; }
        public int EstadoID { get; set; }
        public string Login { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public DateTime? FechaGrabado { get; set; }
    }
}