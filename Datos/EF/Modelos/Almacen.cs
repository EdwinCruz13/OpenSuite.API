using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Almacen
{
    public int AlmacenID { get; set; }

    public int CentroCostoID { get; set; }

    public int EmpresaID { get; set; }

    public int CiudadID { get; set; }

    public int PaisID { get; set; }

    public int Descripcion { get; set; }

    public virtual CentroCosto CentroCosto { get; set; } = null!;

    public virtual Ciudad Ciudad { get; set; } = null!;

    public virtual ICollection<KardexMovimiento> KardexMovimiento { get; set; } = new List<KardexMovimiento>();
}
