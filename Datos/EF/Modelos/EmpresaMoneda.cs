using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class EmpresaMoneda
{
    public int EmpresaMonedaID { get; set; }

    public int EmpresaID { get; set; }

    public int MonedaID { get; set; }

    public bool esRegistro { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual Moneda Moneda { get; set; } = null!;
}
