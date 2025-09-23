using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class DocumentoMadre
{
    public int DocumentoID { get; set; }

    public string nDocumento { get; set; } = null!;

    public int ModuloID { get; set; }

    public virtual ICollection<ComprobanteDocumento> ComprobanteDocumento { get; set; } = new List<ComprobanteDocumento>();
}
