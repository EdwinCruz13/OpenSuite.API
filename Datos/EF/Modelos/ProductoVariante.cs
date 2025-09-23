using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ProductoVariante
{
    public int ProductoVarianteID { get; set; }

    public int? ProductoID { get; set; }

    public string? SkuID { get; set; }

    public int EmpresaID { get; set; }

    public int? ColorID { get; set; }

    public int? VolumenID { get; set; }

    public int? EmpaqueID { get; set; }

    public decimal? CostoVenta { get; set; }

    public decimal? PrecioVenta { get; set; }

    public int? UnidadesDisponible { get; set; }

    public int? UnidadMedidaID { get; set; }

    public int? GeneroID { get; set; }

    public string? CodigoBarra1 { get; set; }

    public string? CodigoBarra2 { get; set; }

    public string? CodigoBarraExtra { get; set; }

    public decimal? DescuentoCupon { get; set; }

    public int? TamañoID { get; set; }

    public virtual ProductoColor? Color { get; set; }

    public virtual ICollection<DevolucionMercanciaDetalle> DevolucionMercanciaDetalle { get; set; } = new List<DevolucionMercanciaDetalle>();

    public virtual ProductoEmpaque? Empaque { get; set; }

    public virtual ProductoUnidadMedida? Genero { get; set; }

    public virtual ICollection<KardexMovimiento> KardexMovimiento { get; set; } = new List<KardexMovimiento>();

    public virtual ICollection<OfertaCompraProveedorDetalle> OfertaCompraProveedorDetalle { get; set; } = new List<OfertaCompraProveedorDetalle>();

    public virtual ICollection<OrdenDetalle> OrdenDetalle { get; set; } = new List<OrdenDetalle>();

    public virtual ICollection<OrdenPedidoDetalle> OrdenPedidoDetalle { get; set; } = new List<OrdenPedidoDetalle>();

    public virtual ICollection<PedidoEntradaMercanciaDetalle> PedidoEntradaMercanciaDetalle { get; set; } = new List<PedidoEntradaMercanciaDetalle>();

    public virtual Producto? Producto { get; set; }

    public virtual ICollection<ProductoImagen> ProductoImagen { get; set; } = new List<ProductoImagen>();

    public virtual ICollection<SolicitudCompraDetalle> SolicitudCompraDetalle { get; set; } = new List<SolicitudCompraDetalle>();

    public virtual ProductoTamaño? Tamaño { get; set; }

    public virtual ProductoGenero? UnidadMedida { get; set; }

    public virtual ProductoVolumen? Volumen { get; set; }
}
