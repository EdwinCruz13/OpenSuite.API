using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Acciones
{
    public int AccionesID { get; set; }

    public int SubModuloID { get; set; }

    public int ModuloID { get; set; }

    public string nAccion { get; set; } = null!;

    public string? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public string? Icon { get; set; }

    public string? Route { get; set; }

    public DateTime? FechaGrabado { get; set; }

    public virtual ICollection<Permiso> Permiso { get; set; } = new List<Permiso>();

    public virtual SubModulo SubModulo { get; set; } = null!;
}
