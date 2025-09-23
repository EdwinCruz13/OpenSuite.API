using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class PersonaEmail
{
    public long IdHistorico { get; set; }

    public int PersonaID { get; set; }

    public string Email { get; set; } = null!;

    public DateTime? FechaGrabado { get; set; }

    public virtual Persona Persona { get; set; } = null!;
}
