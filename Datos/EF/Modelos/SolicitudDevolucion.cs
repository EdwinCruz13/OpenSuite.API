using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class SolicitudDevolucion
{
    public int SolicitudDevolucionID { get; set; }

    public int? OrdenPedidoID { get; set; }

    public int EmpresaID { get; set; }

    public DateOnly FechaSolicitud { get; set; }

    public string? Motivo { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<DevolucionMercancia> DevolucionMercancia { get; set; } = new List<DevolucionMercancia>();

    public virtual OrdenPedido? OrdenPedido { get; set; }
}
