using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class TipoMovimientoConceptos
{
    public string TipoMovimientoConceptosID { get; set; } = null!;

    public int EmpresaID { get; set; }

    public string TipoMovimientoID { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Concepto { get; set; }

    public string? CuentaContable { get; set; }

    public bool? Estado { get; set; }

    public virtual TipoMovimiento TipoMovimiento { get; set; } = null!;
}
