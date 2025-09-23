using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class UsuarioPerfil
{
    public int UsuarioID { get; set; }

    public int PerfilID { get; set; }

    public int EmpresaID { get; set; }

    public int EstadoID { get; set; }

    public DateTime FechaDesde { get; set; }

    public DateTime? FechaHasta { get; set; }

    public bool esTemporal { get; set; }

    public DateTime? FechaGrabado { get; set; }

    public virtual Perfil Perfil { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
