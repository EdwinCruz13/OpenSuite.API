using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class EmpresaDueno
{
    public int EmpresaID { get; set; }

    public int DuenoID { get; set; }

    public DateTime FechaGrabado { get; set; }

    public virtual Persona Dueno { get; set; } = null!;

    public virtual Empresa Empresa { get; set; } = null!;
}
