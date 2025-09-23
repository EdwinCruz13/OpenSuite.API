using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas.Comprobantes
{
    /// <summary>
    /// Clase que representa la naturaleza de un comprobante financiero.
    /// </summary>
    public class ComprobanteNaturaleza
    {
        public int ComprobanteNaturalezaID { get; set; }

        public string nComprobanteNaturaleza { get; set; } = null!;

        public string? Abreviacion { get; set; }
    }
}
