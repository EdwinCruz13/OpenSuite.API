using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class CentroCosto
{
    public int CentroCostoID { get; set; }

    public int EmpresaID { get; set; }

    public int CiudadID { get; set; }

    public int PaisID { get; set; }

    public string Serie { get; set; } = null!;

    public int Consecutivo { get; set; }

    public string nCentroCosto { get; set; } = null!;

    public string CodigoCentroCosto { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public bool esPrincipal { get; set; }

    public virtual ICollection<Almacen> Almacen { get; set; } = new List<Almacen>();

    public virtual ICollection<Caja> Caja { get; set; } = new List<Caja>();

    public virtual Ciudad Ciudad { get; set; } = null!;

    public virtual ICollection<ComprobanteTipo> ComprobanteTipo { get; set; } = new List<ComprobanteTipo>();

    public virtual ICollection<CuentaBancaria> CuentaBancaria { get; set; } = new List<CuentaBancaria>();

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual ICollection<Orden> Orden { get; set; } = new List<Orden>();

    public virtual ICollection<Recibos> Recibos { get; set; } = new List<Recibos>();
}
