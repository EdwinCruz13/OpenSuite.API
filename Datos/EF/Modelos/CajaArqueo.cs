using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class CajaArqueo
{
    public int CajaArqueoID { get; set; }

    public int CajaID { get; set; }

    public int UsuarioID { get; set; }

    public int ArqueoMetodoID { get; set; }

    public int ArqueoTipoID { get; set; }

    public DateTime Fecha { get; set; }

    public decimal SaldoTeorico { get; set; }

    public decimal Recaudacion { get; set; }

    public decimal Diferencia { get; set; }

    public string? Observaciones { get; set; }

    public string? MAC { get; set; }

    public virtual ICollection<ArqueoDetalleDocumentos> ArqueoDetalleDocumentos { get; set; } = new List<ArqueoDetalleDocumentos>();

    public virtual ICollection<ArqueoDetalleEfectivo> ArqueoDetalleEfectivo { get; set; } = new List<ArqueoDetalleEfectivo>();

    public virtual CajaArqueoMetodoIngreso ArqueoMetodo { get; set; } = null!;

    public virtual CajaArqueoTipo ArqueoTipo { get; set; } = null!;

    public virtual Caja Caja { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
