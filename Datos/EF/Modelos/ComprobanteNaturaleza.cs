using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ComprobanteNaturaleza
{
    public int ComprobanteNaturalezaID { get; set; }

    public string nComprobanteNaturaleza { get; set; } = null!;

    public string? Abreviacion { get; set; }

    public virtual ICollection<ComprobanteTipo> ComprobanteTipo { get; set; } = new List<ComprobanteTipo>();
}
