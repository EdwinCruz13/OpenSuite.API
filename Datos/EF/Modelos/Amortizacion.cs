using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Amortizacion
{
    public long nOrdenID { get; set; }

    public int EmpresaID { get; set; }

    public int Consecutivo { get; set; }

    public DateTime? Fecha { get; set; }

    public string? MovimientoID { get; set; }

    public decimal? Debito { get; set; }

    public decimal? Credito { get; set; }

    public decimal? Principal { get; set; }

    public decimal? Saldo { get; set; }

    public virtual Orden Orden { get; set; } = null!;

    public virtual Transaccion? Transaccion { get; set; }
}
