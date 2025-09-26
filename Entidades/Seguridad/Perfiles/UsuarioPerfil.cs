using Entidades.Catalogos;
using Entidades.Seguridad.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Seguridad.Perfiles
{
    /// <summary>
    /// Clase que representa la relación entre un usuario y un perfil en el sistema.
    /// </summary>
    public class UsuarioPerfil
    {
        public int UsuarioID { get; set; }

        public Perfil Perfil { get; set; } = new Perfil();

        public Estado Estado { get; set; } = null!;

        public DateTime FechaDesde { get; set; }

        public DateTime? FechaHasta { get; set; }

        public bool esTemporal { get; set; }

        public DateTime FechaGrabado { get; set; }
    }
}
