using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Orden
{
    public long nOrdenID { get; set; }

    public long OrdenVentaID { get; set; }

    public int ClienteID { get; set; }

    public int? VendedorID { get; set; }

    public int CentroCostoID { get; set; }

    public int TasaCambioID { get; set; }

    public int EmpresaID { get; set; }

    public string? Comentario { get; set; }

    public long? OfertaVentaID { get; set; }

    public virtual ICollection<Amortizacion> Amortizacion { get; set; } = new List<Amortizacion>();

    public virtual CentroCosto CentroCosto { get; set; } = null!;

    public virtual Persona Cliente { get; set; } = null!;

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual OfertaVenta? OfertaVenta { get; set; }

    public virtual ICollection<OrdenDetalle> OrdenDetalle { get; set; } = new List<OrdenDetalle>();

    public virtual ICollection<OrdenDetalleEstado> OrdenDetalleEstado { get; set; } = new List<OrdenDetalleEstado>();

    public virtual ICollection<OrdenDocumentoExoneracion> OrdenDocumentoExoneracion { get; set; } = new List<OrdenDocumentoExoneracion>();

    public virtual ICollection<OrdenFormaPago> OrdenFormaPago { get; set; } = new List<OrdenFormaPago>();

    public virtual TasaCambio TasaCambio { get; set; } = null!;

    public virtual Persona? Vendedor { get; set; }
}
