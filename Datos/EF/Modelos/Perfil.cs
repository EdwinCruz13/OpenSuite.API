using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Perfil
{
    public int PerfilID { get; set; }

    public int EmpresaID { get; set; }

    public string nPerfil { get; set; } = null!;

    public string? Codigo { get; set; }

    public string? Abreviatura { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaGrabado { get; set; }

    public virtual ICollection<Permiso> Permiso { get; set; } = new List<Permiso>();

    public virtual ICollection<UsuarioPerfil> UsuarioPerfil { get; set; } = new List<UsuarioPerfil>();
}
