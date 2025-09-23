using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Empresa
{
    public int EmpresaID { get; set; }

    public int PaisID { get; set; }

    public string nEmpresa { get; set; } = null!;

    public string? Abreviacion { get; set; }

    public string CodigoEmpresa { get; set; } = null!;

    public string CodigoFiscal { get; set; } = null!;

    public string? RLogo { get; set; }

    public string? LLogo { get; set; }

    public string? PrimaryHeader { get; set; }

    public string? SecondaryHeader { get; set; }

    public string? PrimaryFooter { get; set; }

    public string? SecondaryFooter { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public DateTime? UTC_CreateAT { get; set; }

    public DateTime? GTMM6_CreateAT { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<CentroCosto> CentroCosto { get; set; } = new List<CentroCosto>();

    public virtual ICollection<ChequeSerie> ChequeSerie { get; set; } = new List<ChequeSerie>();

    public virtual ICollection<EmpresaContacto> EmpresaContacto { get; set; } = new List<EmpresaContacto>();

    public virtual ICollection<EmpresaDueno> EmpresaDueno { get; set; } = new List<EmpresaDueno>();

    public virtual ICollection<EmpresaGiroEconomico> EmpresaGiroEconomico { get; set; } = new List<EmpresaGiroEconomico>();

    public virtual ICollection<EmpresaMoneda> EmpresaMoneda { get; set; } = new List<EmpresaMoneda>();

    public virtual ICollection<OfertaVenta> OfertaVenta { get; set; } = new List<OfertaVenta>();

    public virtual ICollection<OfertaVentaDetalle> OfertaVentaDetalle { get; set; } = new List<OfertaVentaDetalle>();

    public virtual ICollection<Orden> Orden { get; set; } = new List<Orden>();

    public virtual ICollection<OrdenCatalogoPago> OrdenCatalogoPago { get; set; } = new List<OrdenCatalogoPago>();

    public virtual ICollection<OrdenDetalle> OrdenDetalle { get; set; } = new List<OrdenDetalle>();

    public virtual ICollection<OrdenDetalleEstado> OrdenDetalleEstado { get; set; } = new List<OrdenDetalleEstado>();

    public virtual Pais Pais { get; set; } = null!;

    public virtual ICollection<Periodo> Periodo { get; set; } = new List<Periodo>();

    public virtual ICollection<PeriodoFactura> PeriodoFactura { get; set; } = new List<PeriodoFactura>();

    public virtual ICollection<PeriodoInventario> PeriodoInventario { get; set; } = new List<PeriodoInventario>();

    public virtual ICollection<PlanCuenta> PlanCuenta { get; set; } = new List<PlanCuenta>();

    public virtual ICollection<Transferencia> Transferencia { get; set; } = new List<Transferencia>();

    public virtual ICollection<UsuarioEmpresa> UsuarioEmpresa { get; set; } = new List<UsuarioEmpresa>();
}
