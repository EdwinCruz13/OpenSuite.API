using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ComprobanteDocumento
{
    public int DocumentoID { get; set; }

    public int DetalleID { get; set; }

    public string DocReferencia { get; set; } = null!;

    public int TipoDocumentoID { get; set; }

    public virtual ComprobanteDetalle Detalle { get; set; } = null!;

    public virtual DocumentoMadre TipoDocumento { get; set; } = null!;
}
