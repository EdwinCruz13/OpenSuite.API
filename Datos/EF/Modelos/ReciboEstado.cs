using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ReciboEstado
{
    public int ReciboID { get; set; }

    public int EstadoID { get; set; }

    public DateTime Fecha { get; set; }

    public bool Activo { get; set; }

    public int CajaID { get; set; }

    public string? Observaciones { get; set; }

    public string? MAC { get; set; }

    public int UsuarioGrabaID { get; set; }

    public virtual Caja Caja { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;

    public virtual Recibos Recibo { get; set; } = null!;

    public virtual Usuario UsuarioGraba { get; set; } = null!;
}
