using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class PedidoEntradaMercanciaDetalle
{
    public int PedidoEntradaMercanciaDetalleID { get; set; }

    public int EmpresaID { get; set; }

    public int? PedidoEntradaID { get; set; }

    public int? ProductoVarianteID { get; set; }

    public decimal? CantidadRecibida { get; set; }

    public virtual PedidoEntradaMercancia? PedidoEntradaMercancia { get; set; }

    public virtual ProductoVariante? ProductoVariante { get; set; }
}
