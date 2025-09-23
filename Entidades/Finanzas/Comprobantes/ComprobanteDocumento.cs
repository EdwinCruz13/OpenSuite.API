using Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas.Comprobantes
{
    /// <summary>
    /// Clase que representa la relación entre un comprobante contable y un documento asociado.
    /// </summary>
    public class ComprobanteDocumento
    {
        public int DocumentoID { get; set; }
        public ComprobanteDetalle Detalle { get; set; } = null!;
        public string DocReferencia { get; set; } = null!;
        public virtual DocumentoMadre TipoDocumento { get; set; } = null!;
    }
}
