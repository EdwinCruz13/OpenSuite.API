using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class EmpresaGiroEconomico
{
    public int EmpresaID { get; set; }

    public int TipoGiroID { get; set; }

    public DateTime FechaGrabado { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual Concepto TipoGiro { get; set; } = null!;
}
