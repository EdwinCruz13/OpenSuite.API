using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ChequeSerie
{
    public int SerieID { get; set; }

    public int EmpresaID { get; set; }

    public int CuentaBancariaID { get; set; }

    public string? NumeroCheque { get; set; }

    public virtual ICollection<Cheque> Cheque { get; set; } = new List<Cheque>();

    public virtual CuentaBancaria CuentaBancaria { get; set; } = null!;

    public virtual Empresa Empresa { get; set; } = null!;
}
