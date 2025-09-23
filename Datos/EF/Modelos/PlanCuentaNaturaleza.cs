using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class PlanCuentaNaturaleza
{
    public int NaturalezaID { get; set; }

    public string nNaturaleza { get; set; } = null!;

    public string? Abreviacion { get; set; }

    public virtual ICollection<PlanCuenta> PlanCuenta { get; set; } = new List<PlanCuenta>();
}
