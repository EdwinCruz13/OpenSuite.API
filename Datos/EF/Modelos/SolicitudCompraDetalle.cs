using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class SolicitudCompraDetalle
{
    public int SolicitudCompraDetalleID { get; set; }

    public int EmpresaID { get; set; }

    public int? SolicitudCompraID { get; set; }

    public int? ProductoVarianteID { get; set; }

    public decimal? Cantidad { get; set; }

    public virtual ProductoVariante? ProductoVariante { get; set; }

    public virtual SolicitudCompra? SolicitudCompra { get; set; }
}
