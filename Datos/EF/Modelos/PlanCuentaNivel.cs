using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class PlanCuentaNivel
{
    public int NivelID { get; set; }

    public string nNivel { get; set; } = null!;

    public int Orden { get; set; }

    public int Longitud { get; set; }

    public virtual ICollection<PlanCuenta> PlanCuenta { get; set; } = new List<PlanCuenta>();
}
