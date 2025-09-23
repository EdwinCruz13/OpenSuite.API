using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Estado
{
    public int EstadoID { get; set; }

    public int Consecutivo { get; set; }

    public int EmpresaID { get; set; }

    public int ModuloID { get; set; }

    public int SubModuloID { get; set; }

    public int Orden { get; set; }

    public int AfectaContabilidad { get; set; }

    public int AfectaInventario { get; set; }

    public string nEstado { get; set; } = null!;

    public string? Abreviatura { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<ChequeEstado> ChequeEstado { get; set; } = new List<ChequeEstado>();

    public virtual ICollection<ComprobanteEstado> ComprobanteEstado { get; set; } = new List<ComprobanteEstado>();

    public virtual ICollection<OrdenDetalleEstado> OrdenDetalleEstado { get; set; } = new List<OrdenDetalleEstado>();

    public virtual ICollection<Periodo> Periodo { get; set; } = new List<Periodo>();

    public virtual ICollection<PeriodoFactura> PeriodoFactura { get; set; } = new List<PeriodoFactura>();

    public virtual ICollection<PeriodoInventario> PeriodoInventario { get; set; } = new List<PeriodoInventario>();

    public virtual ICollection<Permiso> Permiso { get; set; } = new List<Permiso>();

    public virtual ICollection<PlanCuenta> PlanCuenta { get; set; } = new List<PlanCuenta>();

    public virtual ICollection<ReciboEstado> ReciboEstado { get; set; } = new List<ReciboEstado>();

    public virtual ICollection<TransferenciaEstado> TransferenciaEstado { get; set; } = new List<TransferenciaEstado>();

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
