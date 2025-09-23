using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Pais
{
    public int PaisID { get; set; }

    public string nPais { get; set; } = null!;

    public string? CodigoPostal { get; set; }

    public string CodigoTelefonico { get; set; } = null!;

    public string Abreviatura { get; set; } = null!;

    public string Flag_Url { get; set; } = null!;

    public string Region { get; set; } = null!;

    public virtual ICollection<Ciudad> Ciudad { get; set; } = new List<Ciudad>();

    public virtual ICollection<Empresa> Empresa { get; set; } = new List<Empresa>();

    public virtual ICollection<Moneda> Moneda { get; set; } = new List<Moneda>();
}
