using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Usuario
{
    public int UsuarioID { get; set; }

    public int PersonaID { get; set; }

    public int EstadoID { get; set; }

    public string Login { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public DateTime? FechaGrabado { get; set; }

    public virtual ICollection<Caja> Caja { get; set; } = new List<Caja>();

    public virtual ICollection<CajaArqueo> CajaArqueo { get; set; } = new List<CajaArqueo>();

    public virtual ICollection<CajaMovimiento> CajaMovimiento { get; set; } = new List<CajaMovimiento>();

    public virtual ICollection<ChequeEstado> ChequeEstado { get; set; } = new List<ChequeEstado>();

    public virtual Estado Estado { get; set; } = null!;

    public virtual Persona Persona { get; set; } = null!;

    public virtual ICollection<ReciboEstado> ReciboEstado { get; set; } = new List<ReciboEstado>();

    public virtual ICollection<TransferenciaEstado> TransferenciaEstado { get; set; } = new List<TransferenciaEstado>();

    public virtual ICollection<UsuarioEmpresa> UsuarioEmpresa { get; set; } = new List<UsuarioEmpresa>();

    public virtual ICollection<UsuarioPerfil> UsuarioPerfil { get; set; } = new List<UsuarioPerfil>();
}
