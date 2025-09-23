using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ComprobanteEstado
{
    public int ComprobanteID { get; set; }

    public int EstadoID { get; set; }

    public DateTime Fecha { get; set; }

    public int UsuarioID { get; set; }

    public bool Activo { get; set; }

    public string? Observaciones { get; set; }

    public string? MAC { get; set; }

    public virtual Comprobante Comprobante { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;
}
