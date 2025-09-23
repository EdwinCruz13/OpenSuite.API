using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class SolicitudCompra
{
    public int SolicitudCompraID { get; set; }

    public int EmpresaID { get; set; }

    public int? NumeroSolicitudID { get; set; }

    public DateTime? Fecha { get; set; }

    public int? Estado { get; set; }

    public string? Observaciones { get; set; }

    public virtual ICollection<OfertaCompraProveedor> OfertaCompraProveedor { get; set; } = new List<OfertaCompraProveedor>();

    public virtual ICollection<SolicitudCompraDetalle> SolicitudCompraDetalle { get; set; } = new List<SolicitudCompraDetalle>();
}
