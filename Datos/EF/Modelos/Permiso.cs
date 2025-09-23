using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Permiso
{
    public int PerfilID { get; set; }

    public int EmpresaID { get; set; }

    public int AccionesID { get; set; }

    public int SubModuloID { get; set; }

    public int ModuloID { get; set; }

    public int EstadoID { get; set; }

    public DateTime FechaDesde { get; set; }

    public DateTime? FechaHasta { get; set; }

    public DateTime? FechaGrabado { get; set; }

    public virtual Acciones Acciones { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;

    public virtual Perfil Perfil { get; set; } = null!;
}
