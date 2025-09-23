using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Transaccion
{
    public string MovimientoID { get; set; } = null!;

    public int EmpresaID { get; set; }

    public string? TipoMovimientoID { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Monto { get; set; }

    public string? Referencia { get; set; }

    public string? TipoConcepto { get; set; }

    public int? ComprobanteID { get; set; }

    public DateTime? Modificado { get; set; }

    public virtual ICollection<Amortizacion> Amortizacion { get; set; } = new List<Amortizacion>();

    public virtual TipoMovimiento? TipoMovimiento { get; set; }
}
