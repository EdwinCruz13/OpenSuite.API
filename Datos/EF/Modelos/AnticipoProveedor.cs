using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class AnticipoProveedor
{
    public int AnticipoProveedorID { get; set; }

    public int EmpresaID { get; set; }

    public int? ProveedorID { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? FormaPagoID { get; set; }

    public string? NumeroDocumento { get; set; }

    public decimal? Monto { get; set; }

    public string? Estado { get; set; }

    public string? Observaciones { get; set; }

    public virtual ICollection<AnticipoProveedorAplicacion> AnticipoProveedorAplicacion { get; set; } = new List<AnticipoProveedorAplicacion>();
}
