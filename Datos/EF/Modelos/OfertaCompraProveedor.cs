using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class OfertaCompraProveedor
{
    public int OfertaCompraProveedorID { get; set; }

    public int EmpresaID { get; set; }

    public int? SolicitudCompraID { get; set; }

    public int? ProveedorID { get; set; }

    public DateTime? FechaOferta { get; set; }

    public int? ValidezDias { get; set; }

    public string? Observaciones { get; set; }

    public virtual ICollection<OfertaCompraProveedorDetalle> OfertaCompraProveedorDetalle { get; set; } = new List<OfertaCompraProveedorDetalle>();

    public virtual ICollection<OrdenPedido> OrdenPedido { get; set; } = new List<OrdenPedido>();

    public virtual SolicitudCompra? SolicitudCompra { get; set; }
}
