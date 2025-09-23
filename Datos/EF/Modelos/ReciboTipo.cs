using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ReciboTipo
{
    public int ReciboTipoID { get; set; }

    public int nTipoRecibo { get; set; }

    public virtual ICollection<Recibos> Recibos { get; set; } = new List<Recibos>();
}
