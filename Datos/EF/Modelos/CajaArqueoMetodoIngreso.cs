using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class CajaArqueoMetodoIngreso
{
    public int ArqueoMetodoID { get; set; }

    public int nCajaMetodo { get; set; }

    public virtual ICollection<CajaArqueo> CajaArqueo { get; set; } = new List<CajaArqueo>();
}
