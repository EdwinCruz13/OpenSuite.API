using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Modulo
{
    public int ModuloID { get; set; }

    public string nModulo { get; set; } = null!;

    public string? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public string? Icon { get; set; }

    public string? Route { get; set; }

    public DateTime? FechaGrabado { get; set; }

    public virtual ICollection<SubModulo> SubModulo { get; set; } = new List<SubModulo>();
}
