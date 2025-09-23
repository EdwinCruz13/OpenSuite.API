using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class OrdenPedido
{
    public int OrdenPedidoID { get; set; }

    public int EmpresaID { get; set; }

    public int NumeroOrden { get; set; }

    public DateTime Fecha { get; set; }

    public int ProveedorID { get; set; }

    public int? OfertaCompraProveedorID { get; set; }

    public int Estado { get; set; }

    public string? Observaciones { get; set; }

    public virtual ICollection<FacturaCompra> FacturaCompra { get; set; } = new List<FacturaCompra>();

    public virtual OfertaCompraProveedor? OfertaCompraProveedor { get; set; }

    public virtual ICollection<OrdenPedidoDetalle> OrdenPedidoDetalle { get; set; } = new List<OrdenPedidoDetalle>();

    public virtual ICollection<PedidoEntradaMercancia> PedidoEntradaMercancia { get; set; } = new List<PedidoEntradaMercancia>();

    public virtual ICollection<SolicitudDevolucion> SolicitudDevolucion { get; set; } = new List<SolicitudDevolucion>();
}
