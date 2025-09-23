using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ReciboDetalle
{
    public int ReciboDetalleID { get; set; }

    public int ReciboID { get; set; }

    public decimal MontoAplicado { get; set; }

    public string? DocumentoReferencia { get; set; }

    public virtual Recibos Recibo { get; set; } = null!;
}
