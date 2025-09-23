using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class OrdenPedidoDetalle
{
    public int OrdenPedidoDetalleID { get; set; }

    public int EmpresaID { get; set; }

    public int OrdenPedidoID { get; set; }

    public int ProductoVarianteID { get; set; }

    public decimal Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual OrdenPedido OrdenPedido { get; set; } = null!;

    public virtual ProductoVariante ProductoVariante { get; set; } = null!;
}
