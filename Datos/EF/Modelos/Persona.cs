using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Persona
{
    public int PersonaID { get; set; }

    public int PersonaTipoID { get; set; }

    public int EntidadTipoID { get; set; }

    public string Identificacion { get; set; } = null!;

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? nPersona { get; set; }

    public string? FirmaUrl { get; set; }

    public DateTime? FechaGrabado { get; set; }

    public virtual ICollection<EmpresaDueno> EmpresaDueno { get; set; } = new List<EmpresaDueno>();

    public virtual Concepto EntidadTipo { get; set; } = null!;

    public virtual ICollection<OfertaVenta> OfertaVenta { get; set; } = new List<OfertaVenta>();

    public virtual ICollection<Orden> OrdenCliente { get; set; } = new List<Orden>();

    public virtual ICollection<OrdenDetalleEstado> OrdenDetalleEstado { get; set; } = new List<OrdenDetalleEstado>();

    public virtual ICollection<Orden> OrdenVendedor { get; set; } = new List<Orden>();

    public virtual ICollection<PersonaEmail> PersonaEmail { get; set; } = new List<PersonaEmail>();

    public virtual ICollection<PersonaTelefono> PersonaTelefono { get; set; } = new List<PersonaTelefono>();

    public virtual Concepto PersonaTipo { get; set; } = null!;

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
