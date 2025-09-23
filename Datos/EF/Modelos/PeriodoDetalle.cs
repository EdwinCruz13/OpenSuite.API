using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class PeriodoDetalle
{
    public int PeriodoDetalleID { get; set; }

    public int PeriodoID { get; set; }

    public int EmpresaID { get; set; }

    public int CuentaID { get; set; }

    public decimal SaldoAnterior { get; set; }

    public decimal Debe { get; set; }

    public decimal Haber { get; set; }

    public decimal SaldoFinal { get; set; }

    public virtual PlanCuenta Cuenta { get; set; } = null!;

    public virtual Periodo Periodo { get; set; } = null!;
}
