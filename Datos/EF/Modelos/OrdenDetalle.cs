using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class OrdenDetalle
{
    public long OrdenDetalleID { get; set; }

    public long nOrdenID { get; set; }

    public int EmpresaID { get; set; }

    public int ProductoVarianteID { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? DescuentoUnidad { get; set; }

    public decimal TotalPagar { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual Orden Orden { get; set; } = null!;

    public virtual ProductoVariante ProductoVariante { get; set; } = null!;
}
