using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Comprobante
{
    public int ComprobanteID { get; set; }

    public string ComprobanteTipoID { get; set; } = null!;

    public string CodigoComprobante { get; set; } = null!;

    public int EmpresaID { get; set; }

    public int CentroCostoID { get; set; }

    public string Concepto { get; set; } = null!;

    public DateTime? FechaGrabado { get; set; }

    public virtual ICollection<ComprobanteDetalle> ComprobanteDetalle { get; set; } = new List<ComprobanteDetalle>();

    public virtual ICollection<ComprobanteEstado> ComprobanteEstado { get; set; } = new List<ComprobanteEstado>();

    public virtual ComprobanteTipo ComprobanteTipo { get; set; } = null!;
}
