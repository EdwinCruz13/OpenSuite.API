using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Catalogos
{
    /// <summary>
    /// Clase que representa un estado dentro de un módulo y submódulo específico.
    /// </summary>
    public class Estado
    {
        public int EstadoID { get; set; }   //Identificador único del estado
        public int Consecutivo { get; set; }   //Consecutivo del estado dentro del módulo y submódulo, Activo, Inactivo, Eliminado, etc.
        public string nEstado { get; set; } = null!;
        public string? Abreviatura { get; set; }

    }
}
