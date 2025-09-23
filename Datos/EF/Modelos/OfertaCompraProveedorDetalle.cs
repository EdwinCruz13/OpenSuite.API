using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class OfertaCompraProveedorDetalle
{
    public int OfertaCompraProveedorDetalleID { get; set; }

    public int EmpresaID { get; set; }

    public int? OfertaCompraProveedorID { get; set; }

    public int ProductoVarianteID { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public virtual OfertaCompraProveedor? OfertaCompraProveedor { get; set; }

    public virtual ProductoVariante ProductoVariante { get; set; } = null!;
}
