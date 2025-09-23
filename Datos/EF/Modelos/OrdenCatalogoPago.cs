using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class OrdenCatalogoPago
{
    public int OrdenCatalogoPagoID { get; set; }

    public int EmpresaID { get; set; }

    public int? ConceptoID { get; set; }

    public int? MonedaID { get; set; }

    public DateTime? FechaGrabado { get; set; }

    public bool? EsCredito { get; set; }

    public bool? Estado { get; set; }

    public virtual Concepto? Concepto { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual Moneda? Moneda { get; set; }

    public virtual ICollection<OrdenFormaPago> OrdenFormaPago { get; set; } = new List<OrdenFormaPago>();
}
