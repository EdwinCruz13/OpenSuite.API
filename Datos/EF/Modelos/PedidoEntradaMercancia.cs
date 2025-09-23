using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class PedidoEntradaMercancia
{
    public int PedidoEntradaID { get; set; }

    public int EmpresaID { get; set; }

    public int? OrdenPedidoID { get; set; }

    public DateTime? FechaRecepcion { get; set; }

    public int? Estado { get; set; }

    public string? Observaciones { get; set; }

    public virtual OrdenPedido? OrdenPedido { get; set; }

    public virtual ICollection<PedidoEntradaMercanciaDetalle> PedidoEntradaMercanciaDetalle { get; set; } = new List<PedidoEntradaMercanciaDetalle>();
}
