using Entidades.Configuraciones;
using Entidades.Finanzas.PlanCuentas;
using Entidades.Seguridad.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas.Comprobantes
{
    /// <summary>
    /// Representa un comprobante financiero.
    /// </summary>
    public class Comprobante
    {
        public int ComprobanteID { get; set; }

        public PlanCuenta CuentaID { get; set; } = null!;

        public ComprobanteTipo ComprobanteTipo { get; set; } = null!;

        public Empresa Empresa { get; set; } = null!;

        public CentroCosto CentroCosto { get; set; } = null!;

        public string Concepto { get; set; } = null!;

        public decimal Debe { get; set; }

        public decimal Haber { get; set; }

        public int Orden { get; set; }

        public Usuario Usuario { get; set; } = null!;

        public DateTime FechaModificacion { get; set; }
    }
}
