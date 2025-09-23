using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class CajaTipoMovimiento
{
    public int CajaTipoMovimientoID { get; set; }

    public int nMovimiento { get; set; }

    public virtual ICollection<CajaMovimiento> CajaMovimiento { get; set; } = new List<CajaMovimiento>();
}
