using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class OrdenFormaPago
{
    public int FormaPagoID { get; set; }

    public long nOrdenID { get; set; }

    public int EmpresaID { get; set; }

    public int? OrdenCatalogoPagoID { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Orden Orden { get; set; } = null!;

    public virtual OrdenCatalogoPago? OrdenCatalogoPago { get; set; }
}
