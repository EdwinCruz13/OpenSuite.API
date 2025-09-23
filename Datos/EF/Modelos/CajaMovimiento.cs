using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class CajaMovimiento
{
    public int CajaMovimientoID { get; set; }

    public int CajaID { get; set; }

    public int CajaTipoMovimientoID { get; set; }

    public int MonedaID { get; set; }

    public int UsuarioID { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Monto { get; set; }

    public string? Concepto { get; set; }

    public string? DocumentoReferencia { get; set; }

    public string? MAC { get; set; }

    public virtual Caja Caja { get; set; } = null!;

    public virtual CajaTipoMovimiento CajaTipoMovimiento { get; set; } = null!;

    public virtual Moneda Moneda { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
