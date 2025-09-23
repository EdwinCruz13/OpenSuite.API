using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ComprobanteDetalle
{
    public int DetalleID { get; set; }

    public int ComprobanteID { get; set; }

    public int CuentaID { get; set; }

    public decimal Debe { get; set; }

    public decimal Haber { get; set; }

    public int Orden { get; set; }

    public virtual Comprobante Comprobante { get; set; } = null!;

    public virtual ICollection<ComprobanteDocumento> ComprobanteDocumento { get; set; } = new List<ComprobanteDocumento>();

    public virtual PlanCuenta Cuenta { get; set; } = null!;
}
