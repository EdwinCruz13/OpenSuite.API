using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class DevolucionMercanciaDetalle
{
    public int DevolucionDetalleID { get; set; }

    public int EmpresaID { get; set; }

    public int? DevolucionMercanciaID { get; set; }

    public int? ProductoVarianteID { get; set; }

    public decimal? CantidadDevuelta { get; set; }

    public decimal? CostoUnitario { get; set; }

    public virtual DevolucionMercancia? DevolucionMercancia { get; set; }

    public virtual ProductoVariante? ProductoVariante { get; set; }
}
