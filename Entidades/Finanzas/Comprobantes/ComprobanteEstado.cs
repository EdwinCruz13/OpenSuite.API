using Entidades.Catalogos;
using Entidades.Seguridad.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas.Comprobantes
{
    /// <summary>
    /// Representa el estado de un comprobante financiero.
    /// </summary>
    public class ComprobanteEstado
    {
        public int ComprobanteID { get; set; }
        public DateTime Fecha { get; set; }
        public Estado Estado { get; set; } = null!;

        public Usuario Usuario { get; set; } = null!;

        public bool Activo { get; set; }

        public string? Observaciones { get; set; }

        public string? MAC { get; set; }

        public Comprobante Comprobante { get; set; } = null!;

        
    }
}
