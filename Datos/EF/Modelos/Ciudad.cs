using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Ciudad
{
    public int CiudadID { get; set; }

    public int PaisID { get; set; }

    public string nCiudad { get; set; } = null!;

    public string CodigoEstado { get; set; } = null!;

    public string ZonaHoraria { get; set; } = null!;

    public virtual ICollection<Almacen> Almacen { get; set; } = new List<Almacen>();

    public virtual ICollection<CentroCosto> CentroCosto { get; set; } = new List<CentroCosto>();

    public virtual Pais Pais { get; set; } = null!;
}
