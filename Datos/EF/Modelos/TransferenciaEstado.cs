using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class TransferenciaEstado
{
    public int TransferenciaID { get; set; }

    public int EstadoID { get; set; }

    public DateTime Fecha { get; set; }

    public bool Activo { get; set; }

    public int? CajaID { get; set; }

    public string? Observaciones { get; set; }

    public string? MAC { get; set; }

    public int UsuarioGrabaID { get; set; }

    public virtual Caja? Caja { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual Transferencia Transferencia { get; set; } = null!;

    public virtual Usuario UsuarioGraba { get; set; } = null!;
}
