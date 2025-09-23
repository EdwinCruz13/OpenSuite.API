using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class FacturaCompra
{
    public int FacturaCompraID { get; set; }

    public int EmpresaID { get; set; }

    public int? ProveedorID { get; set; }

    public int? OrdenPedidoID { get; set; }

    public string? NumeroFactura { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? MontoFactura { get; set; }

    public int? MonedaID { get; set; }

    public int? Estado { get; set; }

    public string? Observaciones { get; set; }

    public int? ComprobanteID { get; set; }

    public virtual ICollection<AnticipoProveedorAplicacion> AnticipoProveedorAplicacion { get; set; } = new List<AnticipoProveedorAplicacion>();

    public virtual ICollection<FacturaCompraPagos> FacturaCompraPagos { get; set; } = new List<FacturaCompraPagos>();

    public virtual OrdenPedido? OrdenPedido { get; set; }
}
