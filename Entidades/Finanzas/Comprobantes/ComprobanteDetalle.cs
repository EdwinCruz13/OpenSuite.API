using Entidades.Finanzas.PlanCuentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas.Comprobantes
{
    /// <summary>
    /// Detalle de un comprobante contable.
    /// </summary>
    public class ComprobanteDetalle
    {
        public int DetalleID { get; set; }

        public Comprobante Comprobante { get; set; } = null!;

        public PlanCuenta CuentaID { get; set; } = null!;

        public decimal Debe { get; set; }

        public decimal Haber { get; set; }

        public int Orden { get; set; }

        public virtual ICollection<ComprobanteDocumento> ComprobanteDocumento { get; set; } = new List<ComprobanteDocumento>();
    }
}
