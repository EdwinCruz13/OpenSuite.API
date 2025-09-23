using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class CajaArqueoTipo
{
    public int ArqueoTipoID { get; set; }

    public int nCajaTipo { get; set; }

    public virtual ICollection<CajaArqueo> CajaArqueo { get; set; } = new List<CajaArqueo>();
}
