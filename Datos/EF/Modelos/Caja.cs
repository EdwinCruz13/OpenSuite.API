using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Caja
{
    public int CajaID { get; set; }

    public string CodCaja { get; set; } = null!;

    public int CuentaID { get; set; }

    public int CentroCostoID { get; set; }

    public int EmpresaID { get; set; }

    public string nCaja { get; set; } = null!;

    public bool Activo { get; set; }

    public int ResposanbleID { get; set; }

    public virtual ICollection<CajaArqueo> CajaArqueo { get; set; } = new List<CajaArqueo>();

    public virtual ICollection<CajaMovimiento> CajaMovimiento { get; set; } = new List<CajaMovimiento>();

    public virtual CentroCosto CentroCosto { get; set; } = null!;

    public virtual ICollection<ChequeEstado> ChequeEstado { get; set; } = new List<ChequeEstado>();

    public virtual PlanCuenta Cuenta { get; set; } = null!;

    public virtual ICollection<ReciboEstado> ReciboEstado { get; set; } = new List<ReciboEstado>();

    public virtual Usuario Resposanble { get; set; } = null!;

    public virtual ICollection<TransferenciaEstado> TransferenciaEstado { get; set; } = new List<TransferenciaEstado>();
}
