using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class PlanCuenta
{
    public int CuentaID { get; set; }

    public int EmpresaID { get; set; }

    public int? PadreID { get; set; }

    public int NivelID { get; set; }

    public int NaturalezaID { get; set; }

    public string CodigoContable { get; set; } = null!;

    public string nCuentaContable { get; set; } = null!;

    public int EstadoID { get; set; }

    public DateTime FechaGrabado { get; set; }

    public virtual ICollection<Caja> Caja { get; set; } = new List<Caja>();

    public virtual ICollection<ComprobanteDetalle> ComprobanteDetalle { get; set; } = new List<ComprobanteDetalle>();

    public virtual ICollection<CuentaBancaria> CuentaBancaria { get; set; } = new List<CuentaBancaria>();

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<PlanCuenta> InversePadre { get; set; } = new List<PlanCuenta>();

    public virtual PlanCuentaNaturaleza Naturaleza { get; set; } = null!;

    public virtual PlanCuentaNivel Nivel { get; set; } = null!;

    public virtual PlanCuenta? Padre { get; set; }

    public virtual ICollection<PeriodoDetalle> PeriodoDetalle { get; set; } = new List<PeriodoDetalle>();

    public virtual ICollection<PeriodoFactura> PeriodoFactura { get; set; } = new List<PeriodoFactura>();

    public virtual ICollection<PeriodoInventario> PeriodoInventario { get; set; } = new List<PeriodoInventario>();
}
