using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class TipoMovimiento1
{
    public int TipoMovimientoID { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<TipoDocumentoMovimiento> TipoDocumentoMovimiento { get; set; } = new List<TipoDocumentoMovimiento>();
}
