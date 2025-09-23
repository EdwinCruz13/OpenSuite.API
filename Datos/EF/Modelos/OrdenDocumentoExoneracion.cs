using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class OrdenDocumentoExoneracion
{
    public long DocumentoExoneraID { get; set; }

    public long? nOrdenID { get; set; }

    public int? EmpresaID { get; set; }

    public byte[]? Documento { get; set; }

    public DateTime? FechaEmision { get; set; }

    public DateTime? FechaFin { get; set; }

    public string? Observacion { get; set; }

    public virtual Orden? Orden { get; set; }
}
