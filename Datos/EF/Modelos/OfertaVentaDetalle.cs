using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class OfertaVentaDetalle
{
    public long OfertaVentaID { get; set; }

    public int EmpresaID { get; set; }

    public int ProductoID { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? DescuentoUnidad { get; set; }

    public decimal TotalPagar { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual OfertaVenta OfertaVenta { get; set; } = null!;
}
