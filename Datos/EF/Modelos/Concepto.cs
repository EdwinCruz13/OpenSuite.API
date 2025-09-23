using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Concepto
{
    public int ConceptoID { get; set; }

    public int ConceptoTipoID { get; set; }

    public string nConcepto { get; set; } = null!;

    public string? Siglas { get; set; }

    public bool Estado { get; set; }

    public virtual ConceptoTipo ConceptoTipo { get; set; } = null!;

    public virtual ICollection<CuentaBancaria> CuentaBancaria { get; set; } = new List<CuentaBancaria>();

    public virtual ICollection<EmpresaContacto> EmpresaContacto { get; set; } = new List<EmpresaContacto>();

    public virtual ICollection<EmpresaGiroEconomico> EmpresaGiroEconomico { get; set; } = new List<EmpresaGiroEconomico>();

    public virtual ICollection<OrdenCatalogoPago> OrdenCatalogoPago { get; set; } = new List<OrdenCatalogoPago>();

    public virtual ICollection<Persona> PersonaEntidadTipo { get; set; } = new List<Persona>();

    public virtual ICollection<Persona> PersonaPersonaTipo { get; set; } = new List<Persona>();

    public virtual ICollection<Recibos> Recibos { get; set; } = new List<Recibos>();
}
