using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class PeriodoFactura
{
    public int PeriodoID { get; set; }

    public int EmpresaID { get; set; }

    public int CuentaID { get; set; }

    public DateOnly FechaApertura { get; set; }

    public DateOnly FechaCierre { get; set; }

    public int EstadoID { get; set; }

    public int Unidades { get; set; }

    public decimal Ventas { get; set; }

    public decimal Devoluciones { get; set; }

    public decimal Monto { get; set; }

    public DateTime? FechaGrabado { get; set; }

    public int? UsuarioGrabaID { get; set; }

    public virtual PlanCuenta Cuenta { get; set; } = null!;

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;
}
