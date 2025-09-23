using Entidades.Configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas.Comprobantes
{
    /// <summary>
    /// Entidad que representa los tipos de comprobantes en el sistema financiero.
    /// </summary>
    public class ComprobanteTipo
    {
        public string ComprobanteTipoID { get; set; } = null!;

        public int EmpresaID { get; set; }

        public int CentroCostoID { get; set; }

        public int ComprobanteNaturalezaID { get; set; }

        public string nTipoComprobante { get; set; } = null!;

        public string CodigoTipo { get; set; } = null!;

        public string? Descripcion { get; set; }

        public virtual CentroCosto CentroCosto { get; set; } = null!;

        public virtual ComprobanteNaturaleza ComprobanteNaturaleza { get; set; } = null!;

        public virtual ICollection<ComprobanteSecuencia> ComprobanteSecuencia { get; set; } = new List<ComprobanteSecuencia>();
    }
}
