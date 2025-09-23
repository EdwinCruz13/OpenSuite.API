using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class TipoDocumentoMovimiento
{
    public int TipoDocumentoMovimientoID { get; set; }

    public int EmpresaID { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public bool AfectaInventario { get; set; }

    public int? TipoMovimientoID { get; set; }

    public virtual ICollection<KardexMovimiento> KardexMovimiento { get; set; } = new List<KardexMovimiento>();

    public virtual TipoMovimiento1? TipoMovimiento { get; set; }
}
