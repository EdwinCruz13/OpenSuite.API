using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class TipoMovimiento
{
    public string TipoMovimientoID { get; set; } = null!;

    public int EmpresaID { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Siglas { get; set; }

    public string? Consecutivo { get; set; }

    public int? NaturalezID { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<TipoMovimientoConceptos> TipoMovimientoConceptos { get; set; } = new List<TipoMovimientoConceptos>();

    public virtual ICollection<Transaccion> Transaccion { get; set; } = new List<Transaccion>();
}
