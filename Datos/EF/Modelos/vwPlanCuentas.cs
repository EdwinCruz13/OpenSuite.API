using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class vwPlanCuentas
{
    public int CuentaID { get; set; }

    public int EmpresaID { get; set; }

    public int? PadreID { get; set; }

    public string CodigoContable { get; set; } = null!;

    public string nCuentaContable { get; set; } = null!;

    public int EstadoID { get; set; }

    public DateTime FechaGrabado { get; set; }

    public int NaturalezaID { get; set; }

    public string nNaturaleza { get; set; } = null!;

    public string? Abreviacion { get; set; }

    public int NivelID { get; set; }

    public string nNivel { get; set; } = null!;

    public int Orden { get; set; }
}
