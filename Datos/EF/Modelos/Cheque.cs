using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Cheque
{
    public int ChequeID { get; set; }

    public int MonedaID { get; set; }

    public int SerieID { get; set; }

    public string NumeroCheque { get; set; } = null!;

    public int Beneficiario { get; set; }

    public decimal Monto { get; set; }

    public string? DocumentoReferencia { get; set; }

    public virtual ICollection<FacturaCompraPagos> FacturaCompraPagos { get; set; } = new List<FacturaCompraPagos>();

    public virtual Moneda Moneda { get; set; } = null!;

    public virtual ChequeSerie Serie { get; set; } = null!;
}
