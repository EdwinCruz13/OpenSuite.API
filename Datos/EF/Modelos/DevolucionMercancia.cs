using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class DevolucionMercancia
{
    public int DevolucionMercanciaID { get; set; }

    public int EmpresaID { get; set; }

    public int? SolicitudDevolucionID { get; set; }

    public DateOnly Fecha { get; set; }

    public string? Observaciones { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<DevolucionMercanciaDetalle> DevolucionMercanciaDetalle { get; set; } = new List<DevolucionMercanciaDetalle>();

    public virtual SolicitudDevolucion? SolicitudDevolucion { get; set; }
}
