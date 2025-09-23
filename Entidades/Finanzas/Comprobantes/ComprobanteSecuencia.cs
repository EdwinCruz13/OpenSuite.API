using Entidades.Configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas.Comprobantes
{
    /// <summary>
    /// Entidad que representa la secuencia de comprobantes en el sistema financiero.
    /// </summary>
    public class ComprobanteSecuencia
    {
        public int SecuenciaID { get; set; }


        public Empresa EmpresaID { get; set; } = null!;

        public CentroCosto CentroCostoID { get; set; } = null!;

        public int AñoComprobante { get; set; }

        public int MesComprobante { get; set; }

        public int Numero { get; set; }

        public string CodigoComprobante { get; set; } = null!;

        public DateTime FechaGrabado { get; set; }

        public virtual ComprobanteTipo ComprobanteTipo { get; set; } = null!;
    }
}
