using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class SubModulo
{
    public int SubModuloID { get; set; }

    public int ModuloID { get; set; }

    public string nSubModulo { get; set; } = null!;

    public string? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public string? Icon { get; set; }

    public string? Route { get; set; }

    public DateTime FechaGrabado { get; set; }

    public virtual ICollection<Acciones> Acciones { get; set; } = new List<Acciones>();

    public virtual Modulo Modulo { get; set; } = null!;
}
