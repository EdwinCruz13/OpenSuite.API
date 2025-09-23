using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ArqueoDetalleDocumentos
{
    public int ArqueoChequeID { get; set; }

    public int CajaArqueoID { get; set; }

    public string DocumentoReferencia { get; set; } = null!;

    public decimal Monto { get; set; }

    public string? Observaciones { get; set; }

    public virtual CajaArqueo CajaArqueo { get; set; } = null!;
}
