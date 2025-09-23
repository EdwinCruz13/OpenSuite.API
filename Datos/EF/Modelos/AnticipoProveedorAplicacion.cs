using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class AnticipoProveedorAplicacion
{
    public int AnticipoProveedorAplicacionID { get; set; }

    public int EmpresaID { get; set; }

    public int? AnticipoProveedorID { get; set; }

    public int? FacturaCompraID { get; set; }

    public decimal? MontoAplicado { get; set; }

    public DateOnly? FechaAplicacion { get; set; }

    public virtual AnticipoProveedor? AnticipoProveedor { get; set; }

    public virtual FacturaCompra? FacturaCompra { get; set; }
}
