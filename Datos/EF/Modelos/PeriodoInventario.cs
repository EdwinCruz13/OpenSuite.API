using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class PeriodoInventario
{
    public int PeriodoID { get; set; }

    public int EmpresaID { get; set; }

    public int CuentaID { get; set; }

    public DateOnly FechaApertura { get; set; }

    public DateOnly FechaCierre { get; set; }

    public int EstadoID { get; set; }

    public int Entradas { get; set; }

    public int Salidas { get; set; }

    public int Saldo { get; set; }

    public decimal EntradaValor { get; set; }

    public decimal SalidaValor { get; set; }

    public decimal SaldoValor { get; set; }

    public DateTime? FechaGrabado { get; set; }

    public int? UsuarioGrabaID { get; set; }

    public virtual PlanCuenta Cuenta { get; set; } = null!;

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;
}
