using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class OfertaVenta
{
    public long OfertaVentaID { get; set; }

    public int? ClienteID { get; set; }

    public int EmpresaID { get; set; }

    public DateTime? FechaEmision { get; set; }

    public DateTime? FechaValidez { get; set; }

    public string? Comentario { get; set; }

    public bool? EstadoID { get; set; }

    public virtual Persona? Cliente { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual ICollection<OfertaVentaDetalle> OfertaVentaDetalle { get; set; } = new List<OfertaVentaDetalle>();

    public virtual ICollection<Orden> Orden { get; set; } = new List<Orden>();
}
