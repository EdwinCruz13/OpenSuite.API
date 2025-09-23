using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class FacturaCompraPagos
{
    public int PagoAplicacion { get; set; }

    public int EmpresaID { get; set; }

    public int? PagoProveedorID { get; set; }

    public int? FacturaCompraID { get; set; }

    public DateTime? FechaAbono { get; set; }

    public decimal? MontoAplicado { get; set; }

    public int? FormaPagoID { get; set; }

    public int? MonedaID { get; set; }

    public int? ChequeID { get; set; }

    public int? TransferenciaID { get; set; }

    public string? Observaciones { get; set; }

    public virtual Cheque? Cheque { get; set; }

    public virtual FacturaCompra? FacturaCompra { get; set; }

    public virtual Transferencia? Transferencia { get; set; }
}
