using System;
using System.Collections.Generic;
using Datos.EF.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Datos.EF.Context;

public partial class OpenSuiteDbContext : DbContext
{
    public OpenSuiteDbContext(DbContextOptions<OpenSuiteDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acciones> Acciones { get; set; }

    public virtual DbSet<Almacen> Almacen { get; set; }

    public virtual DbSet<Amortizacion> Amortizacion { get; set; }

    public virtual DbSet<Amortizacion_Auditoria> Amortizacion_Auditoria { get; set; }

    public virtual DbSet<AnticipoProveedor> AnticipoProveedor { get; set; }

    public virtual DbSet<AnticipoProveedorAplicacion> AnticipoProveedorAplicacion { get; set; }

    public virtual DbSet<ArqueoDetalleDocumentos> ArqueoDetalleDocumentos { get; set; }

    public virtual DbSet<ArqueoDetalleEfectivo> ArqueoDetalleEfectivo { get; set; }

    public virtual DbSet<Audit_Comprobante> Audit_Comprobante { get; set; }

    public virtual DbSet<Banco> Banco { get; set; }

    public virtual DbSet<Caja> Caja { get; set; }

    public virtual DbSet<CajaArqueo> CajaArqueo { get; set; }

    public virtual DbSet<CajaArqueoMetodoIngreso> CajaArqueoMetodoIngreso { get; set; }

    public virtual DbSet<CajaArqueoTipo> CajaArqueoTipo { get; set; }

    public virtual DbSet<CajaMovimiento> CajaMovimiento { get; set; }

    public virtual DbSet<CajaTipoMovimiento> CajaTipoMovimiento { get; set; }

    public virtual DbSet<CentroCosto> CentroCosto { get; set; }

    public virtual DbSet<Cheque> Cheque { get; set; }

    public virtual DbSet<ChequeEstado> ChequeEstado { get; set; }

    public virtual DbSet<ChequeSerie> ChequeSerie { get; set; }

    public virtual DbSet<Ciudad> Ciudad { get; set; }

    public virtual DbSet<Comprobante> Comprobante { get; set; }

    public virtual DbSet<ComprobanteDetalle> ComprobanteDetalle { get; set; }

    public virtual DbSet<ComprobanteDocumento> ComprobanteDocumento { get; set; }

    public virtual DbSet<ComprobanteEstado> ComprobanteEstado { get; set; }

    public virtual DbSet<ComprobanteNaturaleza> ComprobanteNaturaleza { get; set; }

    public virtual DbSet<ComprobanteSecuencia> ComprobanteSecuencia { get; set; }

    public virtual DbSet<ComprobanteTipo> ComprobanteTipo { get; set; }

    public virtual DbSet<Concepto> Concepto { get; set; }

    public virtual DbSet<ConceptoTipo> ConceptoTipo { get; set; }

    public virtual DbSet<CuentaBancaria> CuentaBancaria { get; set; }

    public virtual DbSet<DevolucionMercancia> DevolucionMercancia { get; set; }

    public virtual DbSet<DevolucionMercanciaDetalle> DevolucionMercanciaDetalle { get; set; }

    public virtual DbSet<DocumentoMadre> DocumentoMadre { get; set; }

    public virtual DbSet<Empresa> Empresa { get; set; }

    public virtual DbSet<EmpresaContacto> EmpresaContacto { get; set; }

    public virtual DbSet<EmpresaDueno> EmpresaDueno { get; set; }

    public virtual DbSet<EmpresaGiroEconomico> EmpresaGiroEconomico { get; set; }

    public virtual DbSet<EmpresaMoneda> EmpresaMoneda { get; set; }

    public virtual DbSet<Estado> Estado { get; set; }

    public virtual DbSet<FacturaCompra> FacturaCompra { get; set; }

    public virtual DbSet<FacturaCompraPagos> FacturaCompraPagos { get; set; }

    public virtual DbSet<Impuestos> Impuestos { get; set; }

    public virtual DbSet<KardexMovimiento> KardexMovimiento { get; set; }

    public virtual DbSet<Modulo> Modulo { get; set; }

    public virtual DbSet<Moneda> Moneda { get; set; }

    public virtual DbSet<MonedaDenominacion> MonedaDenominacion { get; set; }

    public virtual DbSet<OfertaCompraProveedor> OfertaCompraProveedor { get; set; }

    public virtual DbSet<OfertaCompraProveedorDetalle> OfertaCompraProveedorDetalle { get; set; }

    public virtual DbSet<OfertaVenta> OfertaVenta { get; set; }

    public virtual DbSet<OfertaVentaDetalle> OfertaVentaDetalle { get; set; }

    public virtual DbSet<Orden> Orden { get; set; }

    public virtual DbSet<OrdenCatalogoPago> OrdenCatalogoPago { get; set; }

    public virtual DbSet<OrdenDetalle> OrdenDetalle { get; set; }

    public virtual DbSet<OrdenDetalleEstado> OrdenDetalleEstado { get; set; }

    public virtual DbSet<OrdenDocumentoExoneracion> OrdenDocumentoExoneracion { get; set; }

    public virtual DbSet<OrdenFormaPago> OrdenFormaPago { get; set; }

    public virtual DbSet<OrdenPedido> OrdenPedido { get; set; }

    public virtual DbSet<OrdenPedidoDetalle> OrdenPedidoDetalle { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<PedidoEntradaMercancia> PedidoEntradaMercancia { get; set; }

    public virtual DbSet<PedidoEntradaMercanciaDetalle> PedidoEntradaMercanciaDetalle { get; set; }

    public virtual DbSet<Perfil> Perfil { get; set; }

    public virtual DbSet<Periodo> Periodo { get; set; }

    public virtual DbSet<PeriodoDetalle> PeriodoDetalle { get; set; }

    public virtual DbSet<PeriodoFactura> PeriodoFactura { get; set; }

    public virtual DbSet<PeriodoInventario> PeriodoInventario { get; set; }

    public virtual DbSet<Permiso> Permiso { get; set; }

    public virtual DbSet<Persona> Persona { get; set; }

    public virtual DbSet<PersonaEmail> PersonaEmail { get; set; }

    public virtual DbSet<PersonaTelefono> PersonaTelefono { get; set; }

    public virtual DbSet<PlanCuenta> PlanCuenta { get; set; }

    public virtual DbSet<PlanCuentaNaturaleza> PlanCuentaNaturaleza { get; set; }

    public virtual DbSet<PlanCuentaNivel> PlanCuentaNivel { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<ProductoCategoria> ProductoCategoria { get; set; }

    public virtual DbSet<ProductoColor> ProductoColor { get; set; }

    public virtual DbSet<ProductoEmpaque> ProductoEmpaque { get; set; }

    public virtual DbSet<ProductoGenero> ProductoGenero { get; set; }

    public virtual DbSet<ProductoImagen> ProductoImagen { get; set; }

    public virtual DbSet<ProductoMarca> ProductoMarca { get; set; }

    public virtual DbSet<ProductoSubCategoria> ProductoSubCategoria { get; set; }

    public virtual DbSet<ProductoTamaño> ProductoTamaño { get; set; }

    public virtual DbSet<ProductoTipo> ProductoTipo { get; set; }

    public virtual DbSet<ProductoUnidadMedida> ProductoUnidadMedida { get; set; }

    public virtual DbSet<ProductoVariante> ProductoVariante { get; set; }

    public virtual DbSet<ProductoVolumen> ProductoVolumen { get; set; }

    public virtual DbSet<ReciboDetalle> ReciboDetalle { get; set; }

    public virtual DbSet<ReciboEstado> ReciboEstado { get; set; }

    public virtual DbSet<ReciboTipo> ReciboTipo { get; set; }

    public virtual DbSet<Recibos> Recibos { get; set; }

    public virtual DbSet<SolicitudCompra> SolicitudCompra { get; set; }

    public virtual DbSet<SolicitudCompraDetalle> SolicitudCompraDetalle { get; set; }

    public virtual DbSet<SolicitudDevolucion> SolicitudDevolucion { get; set; }

    public virtual DbSet<SubModulo> SubModulo { get; set; }

    public virtual DbSet<TasaCambio> TasaCambio { get; set; }

    public virtual DbSet<TipoDocumentoMovimiento> TipoDocumentoMovimiento { get; set; }

    public virtual DbSet<TipoMovimiento> TipoMovimiento { get; set; }

    public virtual DbSet<TipoMovimiento1> TipoMovimiento1 { get; set; }

    public virtual DbSet<TipoMovimientoConceptos> TipoMovimientoConceptos { get; set; }

    public virtual DbSet<Transaccion> Transaccion { get; set; }

    public virtual DbSet<Transaccion_Auditoria> Transaccion_Auditoria { get; set; }

    public virtual DbSet<Transferencia> Transferencia { get; set; }

    public virtual DbSet<TransferenciaEstado> TransferenciaEstado { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<UsuarioEmpresa> UsuarioEmpresa { get; set; }

    public virtual DbSet<UsuarioPerfil> UsuarioPerfil { get; set; }

    public virtual DbSet<vwPlanCuentas> vwPlanCuentas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acciones>(entity =>
        {
            entity.HasKey(e => new { e.AccionesID, e.SubModuloID, e.ModuloID }).HasName("PK_Acciones_AccionesID");

            entity.ToTable("Acciones", "Seguridad");

            entity.Property(e => e.Codigo).HasMaxLength(8);
            entity.Property(e => e.Descripcion).HasMaxLength(150);
            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Icon).HasMaxLength(150);
            entity.Property(e => e.MethodType).HasMaxLength(10);
            entity.Property(e => e.Permiso).HasMaxLength(50);
            entity.Property(e => e.RouterLink).HasMaxLength(150);
            entity.Property(e => e.nAccion).HasMaxLength(50);
            entity.Property(e => e.urlApi).HasMaxLength(150);

            entity.HasOne(d => d.SubModulo).WithMany(p => p.Acciones)
                .HasForeignKey(d => new { d.SubModuloID, d.ModuloID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Acciones_ModuloIDSubModuloID");
        });

        modelBuilder.Entity<Almacen>(entity =>
        {
            entity.HasKey(e => e.AlmacenID).HasName("PK_Almacen_AlmacenID");

            entity.ToTable("Almacen", "Configuraciones");

            entity.Property(e => e.AlmacenID).ValueGeneratedNever();

            entity.HasOne(d => d.CentroCosto).WithMany(p => p.Almacen)
                .HasForeignKey(d => new { d.CentroCostoID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Almacen_AlmacenID_EmpresaIDCentroCostoID");

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Almacen)
                .HasForeignKey(d => new { d.CiudadID, d.PaisID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Almacen_CiudadIDPaisID");
        });

        modelBuilder.Entity<Amortizacion>(entity =>
        {
            entity.HasKey(e => new { e.nOrdenID, e.EmpresaID, e.Consecutivo }).HasName("PK_CuentasCobrar_Amortizacion");

            entity.ToTable("Amortizacion", "CuentasCobrar");

            entity.Property(e => e.Credito).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Debito).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.MovimientoID)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.Principal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Transaccion).WithMany(p => p.Amortizacion)
                .HasForeignKey(d => new { d.MovimientoID, d.EmpresaID })
                .HasConstraintName("FK_CuentasCobrar_Amortizacion_CuentasCobrar_Transaccion_MovimientoID");

            entity.HasOne(d => d.Orden).WithMany(p => p.Amortizacion)
                .HasForeignKey(d => new { d.nOrdenID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CuentasCobrar_Amortizacion_Ventas_Orden_nOrdenID");
        });

        modelBuilder.Entity<Amortizacion_Auditoria>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Amortizacion_Auditoria", "CuentasCobrar");

            entity.Property(e => e.Credito).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreditoNuevo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Debito).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DebitoNuevo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaModificado).HasColumnType("datetime");
            entity.Property(e => e.FechaNueva).HasColumnType("datetime");
            entity.Property(e => e.MovimientoID)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.Principal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PrincipalNuevo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SaldoNUevo).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<AnticipoProveedor>(entity =>
        {
            entity.HasKey(e => new { e.AnticipoProveedorID, e.EmpresaID }).HasName("PK_CuentasPagar_AnticipoProveedor");

            entity.ToTable("AnticipoProveedor", "CuentasPagar");

            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Disponible");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NumeroDocumento).HasMaxLength(50);
            entity.Property(e => e.Observaciones).HasMaxLength(500);
        });

        modelBuilder.Entity<AnticipoProveedorAplicacion>(entity =>
        {
            entity.HasKey(e => new { e.AnticipoProveedorAplicacionID, e.EmpresaID }).HasName("PK_CuentasPagar_AnticipoProveedorAplicacion");

            entity.ToTable("AnticipoProveedorAplicacion", "CuentasPagar");

            entity.Property(e => e.MontoAplicado).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.AnticipoProveedor).WithMany(p => p.AnticipoProveedorAplicacion)
                .HasForeignKey(d => new { d.AnticipoProveedorID, d.EmpresaID })
                .HasConstraintName("FK_CuentasPagar_AnticipoProveedorAplicacion_CuentasPagar_AnticipoProveedor");

            entity.HasOne(d => d.FacturaCompra).WithMany(p => p.AnticipoProveedorAplicacion)
                .HasForeignKey(d => new { d.FacturaCompraID, d.EmpresaID })
                .HasConstraintName("FK_CuentasPagar_AnticipoProveedorAplicacion_CuentasPagar_FacturaCompra");
        });

        modelBuilder.Entity<ArqueoDetalleDocumentos>(entity =>
        {
            entity.HasKey(e => e.ArqueoChequeID).HasName("PKc_ArqueoDetalleDocumentos_ArqueoEfectivoID");

            entity.ToTable("ArqueoDetalleDocumentos", "Tesoreria");

            entity.HasIndex(e => e.CajaArqueoID, "nIX_ArqueoDetalleDocumentos_CajaArqueoID");

            entity.HasIndex(e => e.DocumentoReferencia, "nIX_ArqueoDetalleDocumentos_DenominacionID");

            entity.HasIndex(e => new { e.CajaArqueoID, e.DocumentoReferencia }, "nIX_ArqueoDetalleDocumentoso_Caja_Denominacion");

            entity.Property(e => e.DocumentoReferencia).HasMaxLength(50);
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Observaciones).HasMaxLength(300);

            entity.HasOne(d => d.CajaArqueo).WithMany(p => p.ArqueoDetalleDocumentos)
                .HasForeignKey(d => d.CajaArqueoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArqueoDetalleDocumentos_CajaArqueoID");
        });

        modelBuilder.Entity<ArqueoDetalleEfectivo>(entity =>
        {
            entity.HasKey(e => e.ArqueoEfectivoID).HasName("PKc_ArqueoDetalleEfectivo_ArqueoEfectivoID");

            entity.ToTable("ArqueoDetalleEfectivo", "Tesoreria");

            entity.HasIndex(e => e.CajaArqueoID, "nIX_ArqueoDetalleEfectivo_CajaArqueoID");

            entity.HasIndex(e => new { e.CajaArqueoID, e.DenominacionID }, "nIX_ArqueoDetalleEfectivo_Caja_Denominacion");

            entity.HasIndex(e => e.DenominacionID, "nIX_ArqueoDetalleEfectivo_DenominacionID");

            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CajaArqueo).WithMany(p => p.ArqueoDetalleEfectivo)
                .HasForeignKey(d => d.CajaArqueoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArqueoDetalleEfectivo_CajaArqueoID");

            entity.HasOne(d => d.Denominacion).WithMany(p => p.ArqueoDetalleEfectivo)
                .HasForeignKey(d => d.DenominacionID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArqueoDetalleEfectivo_DenominacionID");
        });

        modelBuilder.Entity<Audit_Comprobante>(entity =>
        {
            entity.HasKey(e => e.ComprobanteID).HasName("PKc_ComprobanteAuditoria_ComprobanteID");

            entity.ToTable("Audit_Comprobante", "Auditoria");

            entity.Property(e => e.ComprobanteID).ValueGeneratedNever();
            entity.Property(e => e.CentroCostoID)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.ComprobanteTipoID)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Concepto).HasMaxLength(2000);
            entity.Property(e => e.Debe).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EmpresaID)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Haber).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Banco>(entity =>
        {
            entity.HasKey(e => e.BancoID).HasName("PKc_Banco_BancoID");

            entity.ToTable("Banco", "Tesoreria");

            entity.Property(e => e.BancoID).ValueGeneratedNever();
            entity.Property(e => e.Siglas).HasMaxLength(15);
        });

        modelBuilder.Entity<Caja>(entity =>
        {
            entity.HasKey(e => e.CajaID).HasName("PKc_Caja_CajaID");

            entity.ToTable("Caja", "Tesoreria");

            entity.HasIndex(e => e.CodCaja, "UQ_Caja_CodCaja").IsUnique();

            entity.Property(e => e.CodCaja).HasMaxLength(10);
            entity.Property(e => e.nCaja).HasMaxLength(50);

            entity.HasOne(d => d.Cuenta).WithMany(p => p.Caja)
                .HasForeignKey(d => d.CuentaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Caja_CuentaID");

            entity.HasOne(d => d.Resposanble).WithMany(p => p.Caja)
                .HasForeignKey(d => d.ResposanbleID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Caja_ResposanbleID");

            entity.HasOne(d => d.CentroCosto).WithMany(p => p.Caja)
                .HasForeignKey(d => new { d.CentroCostoID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Caja_CentroCostoIDEmpresaID");
        });

        modelBuilder.Entity<CajaArqueo>(entity =>
        {
            entity.HasKey(e => e.CajaArqueoID).HasName("PKc_CajaArqueo_CajaArqueoID");

            entity.ToTable("CajaArqueo", "Tesoreria");

            entity.HasIndex(e => new { e.CajaID, e.Fecha }, "IX_CajaArqueo_CajaID_Fecha");

            entity.HasIndex(e => e.ArqueoMetodoID, "nIX_CajaArqueo_ArqueoMetodoID");

            entity.HasIndex(e => e.ArqueoTipoID, "nIX_CajaArqueo_ArqueoTipoID");

            entity.HasIndex(e => e.CajaID, "nIX_CajaArqueo_CajaID");

            entity.HasIndex(e => e.Fecha, "nIX_CajaArqueo_Fecha");

            entity.HasIndex(e => e.UsuarioID, "nIX_CajaArqueo_UsuarioID");

            entity.Property(e => e.Diferencia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MAC).HasMaxLength(100);
            entity.Property(e => e.Observaciones).HasMaxLength(250);
            entity.Property(e => e.Recaudacion).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SaldoTeorico).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ArqueoMetodo).WithMany(p => p.CajaArqueo)
                .HasForeignKey(d => d.ArqueoMetodoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CajaArqueo_ArqueoMetodoID");

            entity.HasOne(d => d.ArqueoTipo).WithMany(p => p.CajaArqueo)
                .HasForeignKey(d => d.ArqueoTipoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CajaArqueo_ArqueoTipoID");

            entity.HasOne(d => d.Caja).WithMany(p => p.CajaArqueo)
                .HasForeignKey(d => d.CajaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CajaArqueo_CajaID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.CajaArqueo)
                .HasForeignKey(d => d.UsuarioID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CajaArqueo_UsuarioID");
        });

        modelBuilder.Entity<CajaArqueoMetodoIngreso>(entity =>
        {
            entity.HasKey(e => e.ArqueoMetodoID).HasName("PKc_CajaArqueoMetodoIngreso_ArqueoMetodoID");

            entity.ToTable("CajaArqueoMetodoIngreso", "Tesoreria");
        });

        modelBuilder.Entity<CajaArqueoTipo>(entity =>
        {
            entity.HasKey(e => e.ArqueoTipoID).HasName("PKc_CajaArqueoTipo_ArqueoTipoID");

            entity.ToTable("CajaArqueoTipo", "Tesoreria");
        });

        modelBuilder.Entity<CajaMovimiento>(entity =>
        {
            entity.HasKey(e => e.CajaMovimientoID).HasName("PKc_CajaMovimiento_CajaID");

            entity.ToTable("CajaMovimiento", "Tesoreria");

            entity.HasIndex(e => new { e.CajaID, e.Fecha }, "IX_CajaMovimiento_CajaID_Fecha");

            entity.HasIndex(e => e.CajaID, "nIX_CajaMovimiento_CajaID");

            entity.HasIndex(e => e.CajaTipoMovimientoID, "nIX_CajaMovimiento_CajaTipoMovimientoID");

            entity.HasIndex(e => e.Fecha, "nIX_CajaMovimiento_Fecha");

            entity.HasIndex(e => e.MonedaID, "nIX_CajaMovimiento_MonedaID");

            entity.HasIndex(e => e.UsuarioID, "nIX_CajaMovimiento_UsuarioID");

            entity.Property(e => e.Concepto).HasMaxLength(250);
            entity.Property(e => e.DocumentoReferencia).HasMaxLength(50);
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MAC).HasMaxLength(100);
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Caja).WithMany(p => p.CajaMovimiento)
                .HasForeignKey(d => d.CajaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CajaMovimiento_CajaID");

            entity.HasOne(d => d.CajaTipoMovimiento).WithMany(p => p.CajaMovimiento)
                .HasForeignKey(d => d.CajaTipoMovimientoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CajaMovimiento_CajaTipoMovimientoID");

            entity.HasOne(d => d.Moneda).WithMany(p => p.CajaMovimiento)
                .HasForeignKey(d => d.MonedaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CajaMovimiento_MonedaID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.CajaMovimiento)
                .HasForeignKey(d => d.UsuarioID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CajaMovimiento_UsuarioID");
        });

        modelBuilder.Entity<CajaTipoMovimiento>(entity =>
        {
            entity.HasKey(e => e.CajaTipoMovimientoID).HasName("PKc_CajaTipoMovimiento_CajaTipoMovimientoID");

            entity.ToTable("CajaTipoMovimiento", "Tesoreria");
        });

        modelBuilder.Entity<CentroCosto>(entity =>
        {
            entity.HasKey(e => new { e.CentroCostoID, e.EmpresaID }).HasName("PKc_CentroCosto_EmpresaIDCentroCostoID");

            entity.ToTable("CentroCosto", "Configuraciones");

            entity.Property(e => e.CodigoCentroCosto)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Direccion).HasMaxLength(150);
            entity.Property(e => e.Serie)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Telefono).HasMaxLength(30);
            entity.Property(e => e.nCentroCosto)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Empresa).WithMany(p => p.CentroCosto)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CentroCosto_EmpresaID");

            entity.HasOne(d => d.Ciudad).WithMany(p => p.CentroCosto)
                .HasForeignKey(d => new { d.CiudadID, d.PaisID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CentroCosto_CiudadIDPaisID");
        });

        modelBuilder.Entity<Cheque>(entity =>
        {
            entity.HasKey(e => e.ChequeID).HasName("PKc_Cheque_ChequeID");

            entity.ToTable("Cheque", "Tesoreria");

            entity.HasIndex(e => e.NumeroCheque, "UQ_Cheque_NumeroCheque").IsUnique();

            entity.Property(e => e.ChequeID).ValueGeneratedNever();
            entity.Property(e => e.DocumentoReferencia).HasMaxLength(30);
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NumeroCheque).HasMaxLength(30);

            entity.HasOne(d => d.Moneda).WithMany(p => p.Cheque)
                .HasForeignKey(d => d.MonedaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cheque_MonedaID");

            entity.HasOne(d => d.Serie).WithMany(p => p.Cheque)
                .HasForeignKey(d => d.SerieID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cheque_SerieID");
        });

        modelBuilder.Entity<ChequeEstado>(entity =>
        {
            entity.HasKey(e => new { e.ChequeID, e.EstadoID, e.Fecha }).HasName("PKc_ChequeEstado_ChequeID");

            entity.ToTable("ChequeEstado", "Tesoreria");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.MAC).HasMaxLength(50);
            entity.Property(e => e.Observaciones).HasMaxLength(150);

            entity.HasOne(d => d.Caja).WithMany(p => p.ChequeEstado)
                .HasForeignKey(d => d.CajaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChequeEstado_CajaID");

            entity.HasOne(d => d.Estado).WithMany(p => p.ChequeEstado)
                .HasForeignKey(d => d.EstadoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChequeEstado_EstadoID");

            entity.HasOne(d => d.UsuarioGraba).WithMany(p => p.ChequeEstado)
                .HasForeignKey(d => d.UsuarioGrabaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChequeEstado_UsuarioGrabaID");
        });

        modelBuilder.Entity<ChequeSerie>(entity =>
        {
            entity.HasKey(e => e.SerieID).HasName("PKc_ChequeSerie_ChequeID");

            entity.ToTable("ChequeSerie", "Tesoreria");

            entity.HasIndex(e => e.NumeroCheque, "UQ_ChequeSerie_NumeroCheque").IsUnique();

            entity.Property(e => e.NumeroCheque).HasMaxLength(30);

            entity.HasOne(d => d.CuentaBancaria).WithMany(p => p.ChequeSerie)
                .HasForeignKey(d => d.CuentaBancariaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChequeSerie_CuentaBancariaID");

            entity.HasOne(d => d.Empresa).WithMany(p => p.ChequeSerie)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChequeSerie_EmpresaID");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => new { e.CiudadID, e.PaisID }).HasName("PKc_Ciudad_CiudadIDPaisID");

            entity.ToTable("Ciudad", "Catalogos");

            entity.Property(e => e.CodigoEstado)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ZonaHoraria)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.nCiudad)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.Pais).WithMany(p => p.Ciudad)
                .HasForeignKey(d => d.PaisID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ciudad_PaisID");
        });

        modelBuilder.Entity<Comprobante>(entity =>
        {
            entity.HasKey(e => e.ComprobanteID).HasName("PKc_Comprobante_ComprobanteID");

            entity.ToTable("Comprobante", "Finanzas");

            entity.HasIndex(e => e.CodigoComprobante, "UQ_Comprobante_CodigoComprobante").IsUnique();

            entity.HasIndex(e => new { e.EmpresaID, e.CentroCostoID }, "nIX_Comprobante_CentroCostoID");

            entity.HasIndex(e => e.CodigoComprobante, "nIX_Comprobante_CodigoComprobante");

            entity.HasIndex(e => e.ComprobanteTipoID, "nIX_Comprobante_PadreID");

            entity.Property(e => e.ComprobanteID).ValueGeneratedNever();
            entity.Property(e => e.CodigoComprobante).HasMaxLength(30);
            entity.Property(e => e.ComprobanteTipoID)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Concepto).HasMaxLength(2000);
            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.ComprobanteTipo).WithMany(p => p.Comprobante)
                .HasForeignKey(d => new { d.ComprobanteTipoID, d.EmpresaID, d.CentroCostoID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comprobante_ComprobanteTipoIDCentroCostoIDEmpresaID");
        });

        modelBuilder.Entity<ComprobanteDetalle>(entity =>
        {
            entity.HasKey(e => e.DetalleID).HasName("PKc_ComprobanteDetalle_DetalleID");

            entity.ToTable("ComprobanteDetalle", "Finanzas");

            entity.HasIndex(e => e.ComprobanteID, "nIX_ComprobanteDetalle_ComprobanteID");

            entity.HasIndex(e => new { e.ComprobanteID, e.Orden }, "nIX_ComprobanteDetalle_ComprobanteID_Orden");

            entity.HasIndex(e => e.CuentaID, "nIX_ComprobanteDetalle_CuentaID");

            entity.Property(e => e.Debe).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Haber).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Comprobante).WithMany(p => p.ComprobanteDetalle)
                .HasForeignKey(d => d.ComprobanteID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComprobanteDetalle_ComprobanteID");

            entity.HasOne(d => d.Cuenta).WithMany(p => p.ComprobanteDetalle)
                .HasForeignKey(d => d.CuentaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComprobanteDetalle_CuentaID");
        });

        modelBuilder.Entity<ComprobanteDocumento>(entity =>
        {
            entity.HasKey(e => e.DocumentoID).HasName("PKc_ComprobanteDocumento_DocumentoID");

            entity.ToTable("ComprobanteDocumento", "Finanzas");

            entity.Property(e => e.DocReferencia).HasMaxLength(25);

            entity.HasOne(d => d.Detalle).WithMany(p => p.ComprobanteDocumento)
                .HasForeignKey(d => d.DetalleID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComprobanteDocumento_DetalleID");

            entity.HasOne(d => d.TipoDocumento).WithMany(p => p.ComprobanteDocumento)
                .HasForeignKey(d => d.TipoDocumentoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComprobanteDocumento_TipoDocumentoID");
        });

        modelBuilder.Entity<ComprobanteEstado>(entity =>
        {
            entity.HasKey(e => new { e.ComprobanteID, e.EstadoID, e.Fecha }).HasName("PKc_ComprobanteEstado_ComprobanteIDEstadoIDFecha");

            entity.ToTable("ComprobanteEstado", "Finanzas");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.MAC).HasMaxLength(250);
            entity.Property(e => e.Observaciones).HasMaxLength(150);

            entity.HasOne(d => d.Comprobante).WithMany(p => p.ComprobanteEstado)
                .HasForeignKey(d => d.ComprobanteID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComprobanteEstado_ComprobanteID");

            entity.HasOne(d => d.Estado).WithMany(p => p.ComprobanteEstado)
                .HasForeignKey(d => d.EstadoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComprobanteEstado_EstadoID");
        });

        modelBuilder.Entity<ComprobanteNaturaleza>(entity =>
        {
            entity.HasKey(e => e.ComprobanteNaturalezaID).HasName("PKc_ComprobanteNaturaleza_ComprobanteNaturalezaID");

            entity.ToTable("ComprobanteNaturaleza", "Finanzas");

            entity.Property(e => e.ComprobanteNaturalezaID).ValueGeneratedNever();
            entity.Property(e => e.Abreviacion)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.nComprobanteNaturaleza).HasMaxLength(15);
        });

        modelBuilder.Entity<ComprobanteSecuencia>(entity =>
        {
            entity.HasKey(e => e.SecuenciaID)
                .HasName("PKc_ComprobanteSecuencia_SecuenciaID")
                .IsClustered(false);

            entity.ToTable("ComprobanteSecuencia", "Finanzas");

            entity.HasIndex(e => new { e.ComprobanteTipoID, e.EmpresaID, e.CentroCostoID }, "IX_ComprobanteSecuencia_ComprobanteTipoIDCentroCostoIDEmpresaID").IsClustered();

            entity.HasIndex(e => e.CodigoComprobante, "UQ_ComprobanteSecuencia_CodigoComprobante").IsUnique();

            entity.Property(e => e.SecuenciaID).ValueGeneratedNever();
            entity.Property(e => e.CodigoComprobante).HasMaxLength(30);
            entity.Property(e => e.ComprobanteTipoID)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.FechaGrabado).HasColumnType("datetime");

            entity.HasOne(d => d.ComprobanteTipo).WithMany(p => p.ComprobanteSecuencia)
                .HasForeignKey(d => new { d.ComprobanteTipoID, d.EmpresaID, d.CentroCostoID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComprobanteSecuencia_ComprobanteTipoIDCentroCostoIDEmpresaID");
        });

        modelBuilder.Entity<ComprobanteTipo>(entity =>
        {
            entity.HasKey(e => new { e.ComprobanteTipoID, e.EmpresaID, e.CentroCostoID }).HasName("PKc_ComprobanteTipo_ComprobanteTipoID");

            entity.ToTable("ComprobanteTipo", "Finanzas");

            entity.Property(e => e.ComprobanteTipoID)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CodigoTipo).HasMaxLength(5);
            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.nTipoComprobante).HasMaxLength(25);

            entity.HasOne(d => d.ComprobanteNaturaleza).WithMany(p => p.ComprobanteTipo)
                .HasForeignKey(d => d.ComprobanteNaturalezaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComprobanteTipo_ComprobanteNaturalezaID");

            entity.HasOne(d => d.CentroCosto).WithMany(p => p.ComprobanteTipo)
                .HasForeignKey(d => new { d.CentroCostoID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComprobanteTipo_CentroCostoIDEmpresaID");
        });

        modelBuilder.Entity<Concepto>(entity =>
        {
            entity.HasKey(e => e.ConceptoID).HasName("PKc_Concepto_ConceptoID");

            entity.ToTable("Concepto", "Catalogos");

            entity.Property(e => e.ConceptoID).ValueGeneratedNever();
            entity.Property(e => e.Siglas).HasMaxLength(10);
            entity.Property(e => e.nConcepto).HasMaxLength(50);

            entity.HasOne(d => d.ConceptoTipo).WithMany(p => p.Concepto)
                .HasForeignKey(d => d.ConceptoTipoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConceptoTipo_ConceptoTipoID");
        });

        modelBuilder.Entity<ConceptoTipo>(entity =>
        {
            entity.HasKey(e => e.ConceptoTipoID).HasName("PKc_ConceptoTipo_ConceptoTipoID");

            entity.ToTable("ConceptoTipo", "Catalogos");

            entity.Property(e => e.ConceptoTipoID).ValueGeneratedNever();
            entity.Property(e => e.Abreviatura).HasMaxLength(10);
            entity.Property(e => e.nConceptoTipo).HasMaxLength(30);
        });

        modelBuilder.Entity<CuentaBancaria>(entity =>
        {
            entity.HasKey(e => e.CuentaBancariaID).HasName("PKc_CuentaBancaria_CuentaBancariaID");

            entity.ToTable("CuentaBancaria", "Tesoreria");

            entity.HasIndex(e => e.CodigoCuentaBancaria, "UQ_CuentaBancaria_CodigoCuentaBancaria").IsUnique();

            entity.Property(e => e.CuentaBancariaID).ValueGeneratedNever();
            entity.Property(e => e.CodigoCuentaBancaria).HasMaxLength(30);
            entity.Property(e => e.nCuentaBancaria).HasMaxLength(30);
            entity.Property(e => e.nPropietario).HasMaxLength(100);

            entity.HasOne(d => d.Banco).WithMany(p => p.CuentaBancaria)
                .HasForeignKey(d => d.BancoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CuentaBancaria_BancoID");

            entity.HasOne(d => d.Cuenta).WithMany(p => p.CuentaBancaria)
                .HasForeignKey(d => d.CuentaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CuentaBancaria_CuentaID");

            entity.HasOne(d => d.Moneda).WithMany(p => p.CuentaBancaria)
                .HasForeignKey(d => d.MonedaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CuentaBancaria_MonedaID");

            entity.HasOne(d => d.TipoCuentaBancaria).WithMany(p => p.CuentaBancaria)
                .HasForeignKey(d => d.TipoCuentaBancariaID)
                .HasConstraintName("FK_CuentaBancaria_TipoCuentaBancariaID");

            entity.HasOne(d => d.CentroCosto).WithMany(p => p.CuentaBancaria)
                .HasForeignKey(d => new { d.CentroCostoID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CuentaBancaria_CentroCostoIDEmpresaID");
        });

        modelBuilder.Entity<DevolucionMercancia>(entity =>
        {
            entity.HasKey(e => new { e.DevolucionMercanciaID, e.EmpresaID }).HasName("PK_Compras_DevolucionMercancia");

            entity.ToTable("DevolucionMercancia", "Compras");

            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Emitida");
            entity.Property(e => e.Observaciones).HasMaxLength(500);

            entity.HasOne(d => d.SolicitudDevolucion).WithMany(p => p.DevolucionMercancia)
                .HasForeignKey(d => new { d.SolicitudDevolucionID, d.EmpresaID })
                .HasConstraintName("FK_Compras_DevolucionMercancia_Compras_SolicitudDevolucion");
        });

        modelBuilder.Entity<DevolucionMercanciaDetalle>(entity =>
        {
            entity.HasKey(e => new { e.DevolucionDetalleID, e.EmpresaID }).HasName("PK_compras_DevolucionMercanciaDetalle");

            entity.ToTable("DevolucionMercanciaDetalle", "Compras");

            entity.Property(e => e.CantidadDevuelta)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CostoUnitario)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.DevolucionMercancia).WithMany(p => p.DevolucionMercanciaDetalle)
                .HasForeignKey(d => new { d.DevolucionMercanciaID, d.EmpresaID })
                .HasConstraintName("FK_compras_DevolucionMercanciaDetalle_Compras_DevolucionMercancia");

            entity.HasOne(d => d.ProductoVariante).WithMany(p => p.DevolucionMercanciaDetalle)
                .HasForeignKey(d => new { d.ProductoVarianteID, d.EmpresaID })
                .HasConstraintName("FK_Compras_DevolucionMercanciaDetalle_Inventario_ProductoVariante");
        });

        modelBuilder.Entity<DocumentoMadre>(entity =>
        {
            entity.HasKey(e => e.DocumentoID).HasName("PKc_TipoDocumento_TipoDocumentoID");

            entity.ToTable("DocumentoMadre", "Catalogos");

            entity.Property(e => e.nDocumento).HasMaxLength(25);
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.EmpresaID).HasName("PKc_Empresa_EmpresaID");

            entity.ToTable("Empresa", "Configuraciones");

            entity.Property(e => e.EmpresaID).ValueGeneratedNever();
            entity.Property(e => e.Abreviacion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CodigoEmpresa)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.CodigoFiscal)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Correo).HasMaxLength(300);
            entity.Property(e => e.Direccion).HasMaxLength(300);
            entity.Property(e => e.GTMM6_CreateAT)
                .HasDefaultValueSql("(switchoffset(CONVERT([datetimeoffset],getutcdate()),'-06:00'))")
                .HasColumnType("datetime");
            entity.Property(e => e.PrimaryFooter)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.PrimaryHeader)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.SecondaryFooter)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.SecondaryHeader)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Telefono).HasMaxLength(25);
            entity.Property(e => e.UTC_CreateAT)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.nEmpresa)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Pais).WithMany(p => p.Empresa)
                .HasForeignKey(d => d.PaisID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_PaisID");
        });

        modelBuilder.Entity<EmpresaContacto>(entity =>
        {
            entity.HasKey(e => e.ContactoID)
                .HasName("PKc_EmpresaContacto_ContactoID")
                .IsClustered(false);

            entity.ToTable("EmpresaContacto", "Configuraciones");

            entity.HasIndex(e => e.EmpresaID, "IX_EmpresaContacto_EmpresaID").IsClustered();

            entity.Property(e => e.Valor).HasMaxLength(150);

            entity.HasOne(d => d.Empresa).WithMany(p => p.EmpresaContacto)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpresaContacto_EmpresaID");

            entity.HasOne(d => d.MedioContacto).WithMany(p => p.EmpresaContacto)
                .HasForeignKey(d => d.MedioContactoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpresaContacto_MediContactoID");
        });

        modelBuilder.Entity<EmpresaDueno>(entity =>
        {
            entity.HasKey(e => new { e.EmpresaID, e.DuenoID }).HasName("PKc_EmpresaDueno_DuenoIDEmpresaID");

            entity.ToTable("EmpresaDueno", "Configuraciones");

            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Dueno).WithMany(p => p.EmpresaDueno)
                .HasForeignKey(d => d.DuenoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpresaDueno_Persona");

            entity.HasOne(d => d.Empresa).WithMany(p => p.EmpresaDueno)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpresaDueno_EmpresaID");
        });

        modelBuilder.Entity<EmpresaGiroEconomico>(entity =>
        {
            entity.HasKey(e => new { e.EmpresaID, e.TipoGiroID }).HasName("PKc_EmpresaGiroEconomico_EmpresaGiroEconomicoID");

            entity.ToTable("EmpresaGiroEconomico", "Configuraciones");

            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Empresa).WithMany(p => p.EmpresaGiroEconomico)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpresaGiroEconomico_EmpresaID");

            entity.HasOne(d => d.TipoGiro).WithMany(p => p.EmpresaGiroEconomico)
                .HasForeignKey(d => d.TipoGiroID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpresaGiroEconomico_TipoGiroID");
        });

        modelBuilder.Entity<EmpresaMoneda>(entity =>
        {
            entity.HasKey(e => e.EmpresaMonedaID)
                .HasName("PKc_EmpresaMoneda_MonedaEmpresaID")
                .IsClustered(false);

            entity.ToTable("EmpresaMoneda", "Configuraciones");

            entity.HasIndex(e => new { e.EmpresaID, e.MonedaID }, "IX_EmpresaMoneda_MonedaIDEmpresaID").IsClustered();

            entity.HasIndex(e => new { e.EmpresaID, e.MonedaID }, "IX_EmpresaMoneda_MonedaIDEmpresaID_EsRegistro");

            entity.HasOne(d => d.Empresa).WithMany(p => p.EmpresaMoneda)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpresaMoneda_EmpresaID");

            entity.HasOne(d => d.Moneda).WithMany(p => p.EmpresaMoneda)
                .HasForeignKey(d => d.MonedaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpresaMoneda_MonedaID");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoID).HasName("PKc_Estado_EstadoID");

            entity.ToTable("Estado", "Catalogos");

            entity.Property(e => e.EstadoID).ValueGeneratedNever();
            entity.Property(e => e.Abreviatura)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.nEstado)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FacturaCompra>(entity =>
        {
            entity.HasKey(e => new { e.FacturaCompraID, e.EmpresaID }).HasName("PK_CuentasPagar_FacturaCompra");

            entity.ToTable("FacturaCompra", "CuentasPagar");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.MontoFactura).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NumeroFactura).HasMaxLength(50);
            entity.Property(e => e.Observaciones).HasMaxLength(200);

            entity.HasOne(d => d.OrdenPedido).WithMany(p => p.FacturaCompra)
                .HasForeignKey(d => new { d.OrdenPedidoID, d.EmpresaID })
                .HasConstraintName("FK_CuentasPagar_FacturaCompra_Compras_OrdenPedido");
        });

        modelBuilder.Entity<FacturaCompraPagos>(entity =>
        {
            entity.HasKey(e => new { e.PagoAplicacion, e.EmpresaID }).HasName("PK_CuentasPagar_FacturaCompraPagos");

            entity.ToTable("FacturaCompraPagos", "CuentasPagar");

            entity.Property(e => e.FechaAbono).HasColumnType("datetime");
            entity.Property(e => e.MontoAplicado).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Observaciones).HasMaxLength(500);

            entity.HasOne(d => d.Cheque).WithMany(p => p.FacturaCompraPagos)
                .HasForeignKey(d => d.ChequeID)
                .HasConstraintName("FK_CuentasPagar_FacturaCompraPagos_Tesoreria_Cheque");

            entity.HasOne(d => d.Transferencia).WithMany(p => p.FacturaCompraPagos)
                .HasForeignKey(d => d.TransferenciaID)
                .HasConstraintName("FK_CuentasPagar_FacturaCompraPagos_Tesoreria_Transferencia");

            entity.HasOne(d => d.FacturaCompra).WithMany(p => p.FacturaCompraPagos)
                .HasForeignKey(d => new { d.FacturaCompraID, d.EmpresaID })
                .HasConstraintName("FK_CuentasPagar_FacturaCompraPagos_CuentasPagar_FacturaCompra");
        });

        modelBuilder.Entity<Impuestos>(entity =>
        {
            entity.HasKey(e => e.ImpuestoID).HasName("PK_Catalogos_Impuestos");

            entity.ToTable("Impuestos", "Catalogos");

            entity.Property(e => e.ImpuestoID).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaGrabado).HasColumnType("datetime");
            entity.Property(e => e.FechaInicia).HasColumnType("datetime");
            entity.Property(e => e.Siglas).HasMaxLength(10);
            entity.Property(e => e.Valor).HasColumnType("decimal(3, 2)");
        });

        modelBuilder.Entity<KardexMovimiento>(entity =>
        {
            entity.HasKey(e => new { e.KardeMovimientoID, e.EmpresaID, e.ProductoVarianteID });

            entity.ToTable("KardexMovimiento", "Inventario");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CostoUnitarioID).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Descripcion).HasMaxLength(300);
            entity.Property(e => e.DocumentoReferencia).HasMaxLength(50);
            entity.Property(e => e.Fecha).HasColumnType("datetime");

            entity.HasOne(d => d.AlmacenOrigen).WithMany(p => p.KardexMovimiento)
                .HasForeignKey(d => d.AlmacenOrigenID)
                .HasConstraintName("FK_KardexMovimiento_AlmacenDestinoID");

            entity.HasOne(d => d.ProductoVariante).WithMany(p => p.KardexMovimiento)
                .HasForeignKey(d => new { d.ProductoVarianteID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KardexMovimiento_ProductoVariante");

            entity.HasOne(d => d.TipoDocumentoMovimiento).WithMany(p => p.KardexMovimiento)
                .HasForeignKey(d => new { d.TipoMovimientoID, d.EmpresaID })
                .HasConstraintName("FK_KardexMovimiento_TipoMovimientoID");
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.ModuloID).HasName("PK_Modulo_ModuloID");

            entity.ToTable("Modulo", "Seguridad");

            entity.Property(e => e.ModuloID).ValueGeneratedNever();
            entity.Property(e => e.Codigo).HasMaxLength(2);
            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Icon).HasMaxLength(150);
            entity.Property(e => e.RouterLink).HasMaxLength(150);
            entity.Property(e => e.nModulo).HasMaxLength(25);
        });

        modelBuilder.Entity<Moneda>(entity =>
        {
            entity.HasKey(e => e.MonedaID).HasName("PKc_Moneda_MonedaID");

            entity.ToTable("Moneda", "Catalogos");

            entity.Property(e => e.MonedaID).ValueGeneratedNever();
            entity.Property(e => e.Codigo)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.Siglas)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.nMoneda)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Pais).WithMany(p => p.Moneda)
                .HasForeignKey(d => d.PaisID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Moneda_PaisID");
        });

        modelBuilder.Entity<MonedaDenominacion>(entity =>
        {
            entity.HasKey(e => e.DenominacionID).HasName("PKc_MonedaDenominacion_DenominacionID");

            entity.ToTable("MonedaDenominacion", "Catalogos");

            entity.Property(e => e.TipoMoneda)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.nDenominacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Moneda).WithMany(p => p.MonedaDenominacion)
                .HasForeignKey(d => d.MonedaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MonedaDenominacion_MonedaID");
        });

        modelBuilder.Entity<OfertaCompraProveedor>(entity =>
        {
            entity.HasKey(e => new { e.OfertaCompraProveedorID, e.EmpresaID }).HasName("PK_Compras_OfertaCompraProveedor");

            entity.ToTable("OfertaCompraProveedor", "Compras");

            entity.Property(e => e.FechaOferta).HasColumnType("datetime");
            entity.Property(e => e.Observaciones).HasMaxLength(250);

            entity.HasOne(d => d.SolicitudCompra).WithMany(p => p.OfertaCompraProveedor)
                .HasForeignKey(d => new { d.SolicitudCompraID, d.EmpresaID })
                .HasConstraintName("FK_Compras_OfertaCompraProveedor_Compras_SolicitudCompra");
        });

        modelBuilder.Entity<OfertaCompraProveedorDetalle>(entity =>
        {
            entity.HasKey(e => new { e.OfertaCompraProveedorDetalleID, e.EmpresaID }).HasName("PK_Compras_OfertaCompraProveedorDetalle");

            entity.ToTable("OfertaCompraProveedorDetalle", "Compras");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.OfertaCompraProveedor).WithMany(p => p.OfertaCompraProveedorDetalle)
                .HasForeignKey(d => new { d.OfertaCompraProveedorID, d.EmpresaID })
                .HasConstraintName("FK_Compras_OfertaCompraProveedorDetalle_Compras_OfertaCompraProveedor");

            entity.HasOne(d => d.ProductoVariante).WithMany(p => p.OfertaCompraProveedorDetalle)
                .HasForeignKey(d => new { d.ProductoVarianteID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compras_OfertaCompraProveedorDetalle_Inventario_ProductoVariante");
        });

        modelBuilder.Entity<OfertaVenta>(entity =>
        {
            entity.HasKey(e => new { e.OfertaVentaID, e.EmpresaID }).HasName("PK_Ventas_OfertaVenta");

            entity.ToTable("OfertaVenta", "Ventas");

            entity.Property(e => e.Comentario).HasMaxLength(400);
            entity.Property(e => e.FechaEmision).HasColumnType("datetime");
            entity.Property(e => e.FechaValidez).HasColumnType("datetime");

            entity.HasOne(d => d.Cliente).WithMany(p => p.OfertaVenta)
                .HasForeignKey(d => d.ClienteID)
                .HasConstraintName("FK_Ventas_OfertaVenta_Persona_ClienteID");

            entity.HasOne(d => d.Empresa).WithMany(p => p.OfertaVenta)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_OfertaVenta_ConfiguracionEmpresa");
        });

        modelBuilder.Entity<OfertaVentaDetalle>(entity =>
        {
            entity.HasKey(e => new { e.OfertaVentaID, e.EmpresaID, e.ProductoID }).HasName("PK_Ventas_OfertaVentaDetalle");

            entity.ToTable("OfertaVentaDetalle", "Ventas");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DescuentoUnidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalPagar)
                .HasComputedColumnSql("(isnull(([Precio]*((1.0)-[DescuentoUnidad]))*[Cantidad],(0.0)))", false)
                .HasColumnType("numeric(33, 6)");

            entity.HasOne(d => d.Empresa).WithMany(p => p.OfertaVentaDetalle)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Venta_OfertaVentaDetalle_ConfiguracionEmpresa");

            entity.HasOne(d => d.OfertaVenta).WithMany(p => p.OfertaVentaDetalle)
                .HasForeignKey(d => new { d.OfertaVentaID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_OfertaVentaDetalle");
        });

        modelBuilder.Entity<Orden>(entity =>
        {
            entity.HasKey(e => new { e.nOrdenID, e.EmpresaID }).HasName("PK_Ventas_Orden");

            entity.ToTable("Orden", "Ventas");

            entity.Property(e => e.Comentario).HasMaxLength(400);

            entity.HasOne(d => d.Cliente).WithMany(p => p.OrdenCliente)
                .HasForeignKey(d => d.ClienteID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Orden_Persona_ClienteID");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Orden)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Orden_ConfiguracionEmpresa");

            entity.HasOne(d => d.TasaCambio).WithMany(p => p.Orden)
                .HasForeignKey(d => d.TasaCambioID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Orden_TasaCambio");

            entity.HasOne(d => d.Vendedor).WithMany(p => p.OrdenVendedor)
                .HasForeignKey(d => d.VendedorID)
                .HasConstraintName("FK_Ventas_Orden_Persona_VendedorID");

            entity.HasOne(d => d.CentroCosto).WithMany(p => p.Orden)
                .HasForeignKey(d => new { d.CentroCostoID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Orden_Centro_Costo");

            entity.HasOne(d => d.OfertaVenta).WithMany(p => p.Orden)
                .HasForeignKey(d => new { d.OfertaVentaID, d.EmpresaID })
                .HasConstraintName("FK_Ventas_Orden_Ventas_OfertaVenta");
        });

        modelBuilder.Entity<OrdenCatalogoPago>(entity =>
        {
            entity.HasKey(e => new { e.OrdenCatalogoPagoID, e.EmpresaID }).HasName("PK_Ventas_OrdenCatalogoPago");

            entity.ToTable("OrdenCatalogoPago", "Ventas");

            entity.Property(e => e.FechaGrabado).HasColumnType("datetime");

            entity.HasOne(d => d.Concepto).WithMany(p => p.OrdenCatalogoPago)
                .HasForeignKey(d => d.ConceptoID)
                .HasConstraintName("FK_Ventas_OrdenCatalogoPago_CatalogosConceptos");

            entity.HasOne(d => d.Empresa).WithMany(p => p.OrdenCatalogoPago)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_OrdenCatalogoPago_Configuraciones_Empresa");

            entity.HasOne(d => d.Moneda).WithMany(p => p.OrdenCatalogoPago)
                .HasForeignKey(d => d.MonedaID)
                .HasConstraintName("FK_Ventas_OrdenCatalogoPago_CatalogosMoneda");
        });

        modelBuilder.Entity<OrdenDetalle>(entity =>
        {
            entity.HasKey(e => new { e.OrdenDetalleID, e.nOrdenID }).HasName("PK_Ventas_OrdenDetalle");

            entity.ToTable("OrdenDetalle", "Ventas");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DescuentoUnidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalPagar)
                .HasComputedColumnSql("(isnull(([Precio]*((1.0)-[DescuentoUnidad]))*[Cantidad],(0.0)))", false)
                .HasColumnType("numeric(33, 6)");

            entity.HasOne(d => d.Empresa).WithMany(p => p.OrdenDetalle)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_OrdenDetalle_ConfiguracionEmpresa");

            entity.HasOne(d => d.ProductoVariante).WithMany(p => p.OrdenDetalle)
                .HasForeignKey(d => new { d.ProductoVarianteID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Inventario_ProductoVariante");

            entity.HasOne(d => d.Orden).WithMany(p => p.OrdenDetalle)
                .HasForeignKey(d => new { d.nOrdenID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_OrdenDetalle_VentasOrden");
        });

        modelBuilder.Entity<OrdenDetalleEstado>(entity =>
        {
            entity.HasKey(e => new { e.nOrdenID, e.EmpresaID, e.Fecha }).HasName("PK_Ventas_OrdenDetalleEstado");

            entity.ToTable("OrdenDetalleEstado", "Ventas");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.MacID).HasMaxLength(50);

            entity.HasOne(d => d.Empresa).WithMany(p => p.OrdenDetalleEstado)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_OrdenDetalleEstado_Configuraciones_Empresa");

            entity.HasOne(d => d.Estado).WithMany(p => p.OrdenDetalleEstado)
                .HasForeignKey(d => d.EstadoID)
                .HasConstraintName("FK_Ventas_OrdenDetalleEstado_CatalogosEstado");

            entity.HasOne(d => d.Usuario).WithMany(p => p.OrdenDetalleEstado)
                .HasForeignKey(d => d.UsuarioID)
                .HasConstraintName("FK_Ventas_OrdenDetalleEstado_Persona_UsuarioID");

            entity.HasOne(d => d.Orden).WithMany(p => p.OrdenDetalleEstado)
                .HasForeignKey(d => new { d.nOrdenID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_OrdenDetalleEstado_VentasOrden");
        });

        modelBuilder.Entity<OrdenDocumentoExoneracion>(entity =>
        {
            entity.HasKey(e => e.DocumentoExoneraID).HasName("PK_Ventas_OrdenDocumentoExoneracion");

            entity.ToTable("OrdenDocumentoExoneracion", "Ventas");

            entity.Property(e => e.DocumentoExoneraID).ValueGeneratedNever();
            entity.Property(e => e.FechaEmision).HasColumnType("datetime");
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.Observacion).HasMaxLength(100);

            entity.HasOne(d => d.Orden).WithMany(p => p.OrdenDocumentoExoneracion)
                .HasForeignKey(d => new { d.nOrdenID, d.EmpresaID })
                .HasConstraintName("FK_Ventas_OrdenDocumentoExoneracionVentas_Orden");
        });

        modelBuilder.Entity<OrdenFormaPago>(entity =>
        {
            entity.HasKey(e => new { e.FormaPagoID, e.nOrdenID, e.EmpresaID }).HasName("PK_Ventas_OrdenFormaPago");

            entity.ToTable("OrdenFormaPago", "Ventas");

            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

            entity.HasOne(d => d.OrdenCatalogoPago).WithMany(p => p.OrdenFormaPago)
                .HasForeignKey(d => new { d.OrdenCatalogoPagoID, d.EmpresaID })
                .HasConstraintName("FK_Ventas_OrdenFormaPago_VentasOrdenCatalogoPago");

            entity.HasOne(d => d.Orden).WithMany(p => p.OrdenFormaPago)
                .HasForeignKey(d => new { d.nOrdenID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_OrdenFormaPago_VentasOrden");
        });

        modelBuilder.Entity<OrdenPedido>(entity =>
        {
            entity.HasKey(e => new { e.OrdenPedidoID, e.EmpresaID }).HasName("PK_Compras_OrdenPedido");

            entity.ToTable("OrdenPedido", "Compras");

            entity.HasIndex(e => e.OfertaCompraProveedorID, "UQ__OrdenPed__74C4B24E56D05337").IsUnique();

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Observaciones).HasMaxLength(250);

            entity.HasOne(d => d.OfertaCompraProveedor).WithMany(p => p.OrdenPedido)
                .HasForeignKey(d => new { d.OfertaCompraProveedorID, d.EmpresaID })
                .HasConstraintName("FK_Compras_OrdenPedido_Compras_OfertaCompraProveedor");
        });

        modelBuilder.Entity<OrdenPedidoDetalle>(entity =>
        {
            entity.HasKey(e => new { e.OrdenPedidoDetalleID, e.EmpresaID }).HasName("PK_Compras_OrdenPedidoDetalle");

            entity.ToTable("OrdenPedidoDetalle", "Compras");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.OrdenPedido).WithMany(p => p.OrdenPedidoDetalle)
                .HasForeignKey(d => new { d.OrdenPedidoID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compras_OrdenPedidoDetalle_Compras_OrdenPedido");

            entity.HasOne(d => d.ProductoVariante).WithMany(p => p.OrdenPedidoDetalle)
                .HasForeignKey(d => new { d.ProductoVarianteID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compras_OrdenPedidoDetalle_Inventario_ProductoVariante");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.PaisID).HasName("PKc_Pais_PaisID");

            entity.ToTable("Pais", "Catalogos");

            entity.Property(e => e.PaisID).ValueGeneratedNever();
            entity.Property(e => e.Abreviatura)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CodigoTelefonico)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Flag_Url)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Region)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.nPais)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PedidoEntradaMercancia>(entity =>
        {
            entity.HasKey(e => new { e.PedidoEntradaID, e.EmpresaID }).HasName("PK_Compras_PedidoEntradaMercancia");

            entity.ToTable("PedidoEntradaMercancia", "Compras");

            entity.Property(e => e.FechaRecepcion).HasColumnType("datetime");
            entity.Property(e => e.Observaciones).HasMaxLength(200);

            entity.HasOne(d => d.OrdenPedido).WithMany(p => p.PedidoEntradaMercancia)
                .HasForeignKey(d => new { d.OrdenPedidoID, d.EmpresaID })
                .HasConstraintName("FK_Compras_PedidoEntradaMercancia_Compras_OrdenPedido");
        });

        modelBuilder.Entity<PedidoEntradaMercanciaDetalle>(entity =>
        {
            entity.HasKey(e => new { e.PedidoEntradaMercanciaDetalleID, e.EmpresaID }).HasName("PK_Compras_PedidoEntradaMercanciaDetalle");

            entity.ToTable("PedidoEntradaMercanciaDetalle", "Compras");

            entity.Property(e => e.CantidadRecibida).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.PedidoEntradaMercancia).WithMany(p => p.PedidoEntradaMercanciaDetalle)
                .HasForeignKey(d => new { d.PedidoEntradaID, d.EmpresaID })
                .HasConstraintName("FK_Compras_PedidoEntradaMercanciaDetalle_Compras_PedidoEntradaMercancia");

            entity.HasOne(d => d.ProductoVariante).WithMany(p => p.PedidoEntradaMercanciaDetalle)
                .HasForeignKey(d => new { d.ProductoVarianteID, d.EmpresaID })
                .HasConstraintName("FK_Compras_PedidoEntradaMercanciaDetalle_Inventario_ProductoVariante");
        });

        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.HasKey(e => new { e.PerfilID, e.EmpresaID }).HasName("PK_Perfil_PerfilID");

            entity.ToTable("Perfil", "Seguridad");

            entity.Property(e => e.Abreviatura).HasMaxLength(30);
            entity.Property(e => e.Codigo).HasMaxLength(25);
            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.nPerfil).HasMaxLength(100);
        });

        modelBuilder.Entity<Periodo>(entity =>
        {
            entity.HasKey(e => new { e.PeriodoID, e.EmpresaID }).HasName("PKc_Periodo_PeriodoID");

            entity.ToTable("Periodo", "Finanzas");

            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Periodo)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Periodo_EmpresaID");

            entity.HasOne(d => d.Estado).WithMany(p => p.Periodo)
                .HasForeignKey(d => d.EstadoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Periodo_EstadoID");
        });

        modelBuilder.Entity<PeriodoDetalle>(entity =>
        {
            entity.HasKey(e => e.PeriodoDetalleID).HasName("PKc_PeriodoDetalle_PeriodoDetalleID");

            entity.ToTable("PeriodoDetalle", "Finanzas");

            entity.HasIndex(e => e.CuentaID, "nIX_PeriodoDetalle_CuentaID");

            entity.HasIndex(e => new { e.PeriodoID, e.EmpresaID }, "nIX_PeriodoDetalle_PeriodoID");

            entity.Property(e => e.Debe).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Haber).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SaldoAnterior).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SaldoFinal).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cuenta).WithMany(p => p.PeriodoDetalle)
                .HasForeignKey(d => d.CuentaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PeriodoDetalle_CuentaID");

            entity.HasOne(d => d.Periodo).WithMany(p => p.PeriodoDetalle)
                .HasForeignKey(d => new { d.PeriodoID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PeriodoDetalle_PeriodoID");
        });

        modelBuilder.Entity<PeriodoFactura>(entity =>
        {
            entity.HasKey(e => new { e.PeriodoID, e.EmpresaID }).HasName("PKc_PeriodoFactura_PeriodoID");

            entity.ToTable("PeriodoFactura", "Finanzas");

            entity.Property(e => e.Devoluciones).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Ventas).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cuenta).WithMany(p => p.PeriodoFactura)
                .HasForeignKey(d => d.CuentaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PeriodoFactura_CuentaID");

            entity.HasOne(d => d.Empresa).WithMany(p => p.PeriodoFactura)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PeriodoFactura_EmpresaID");

            entity.HasOne(d => d.Estado).WithMany(p => p.PeriodoFactura)
                .HasForeignKey(d => d.EstadoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PeriodoFactura_EstadoID");
        });

        modelBuilder.Entity<PeriodoInventario>(entity =>
        {
            entity.HasKey(e => new { e.PeriodoID, e.EmpresaID }).HasName("PKc_PeriodoInventario_PeriodoID");

            entity.ToTable("PeriodoInventario", "Finanzas");

            entity.Property(e => e.EntradaValor).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SaldoValor).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SalidaValor).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cuenta).WithMany(p => p.PeriodoInventario)
                .HasForeignKey(d => d.CuentaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PeriodoInventario_CuentaID");

            entity.HasOne(d => d.Empresa).WithMany(p => p.PeriodoInventario)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PeriodoInventario_EmpresaID");

            entity.HasOne(d => d.Estado).WithMany(p => p.PeriodoInventario)
                .HasForeignKey(d => d.EstadoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PeriodoInventario_EstadoID");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => new { e.PerfilID, e.AccionesID, e.SubModuloID, e.ModuloID, e.EmpresaID }).HasName("PK_Permiso_PermisoID");

            entity.ToTable("Permiso", "Seguridad");

            entity.Property(e => e.FechaDesde).HasColumnType("datetime");
            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaHasta).HasColumnType("datetime");

            entity.HasOne(d => d.Estado).WithMany(p => p.Permiso)
                .HasForeignKey(d => d.EstadoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EstadoID_Permiso");

            entity.HasOne(d => d.Perfil).WithMany(p => p.Permiso)
                .HasForeignKey(d => new { d.PerfilID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permiso_PerfilID");

            entity.HasOne(d => d.Acciones).WithMany(p => p.PermisoNavigation)
                .HasForeignKey(d => new { d.AccionesID, d.SubModuloID, d.ModuloID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permiso_ModuloIDSubModuloIDAccionesID");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.PersonaID).HasName("PKc_Persona_PersonaID");

            entity.ToTable("Persona", "Persona");

            entity.Property(e => e.PersonaID).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FirmaUrl).HasMaxLength(500);
            entity.Property(e => e.Identificacion).HasMaxLength(100);
            entity.Property(e => e.PrimerApellido).HasMaxLength(100);
            entity.Property(e => e.PrimerNombre).HasMaxLength(100);
            entity.Property(e => e.SegundoApellido).HasMaxLength(100);
            entity.Property(e => e.SegundoNombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.nPersona)
                .HasMaxLength(403)
                .HasComputedColumnSql("(((([PrimerNombre]+case when [SegundoNombre] IS NULL OR ltrim(rtrim([SegundoNombre]))='' then '' else ' '+[segundoNombre] end)+' ')+[PrimerApellido])+case when [SegundoApellido] IS NULL OR ltrim(rtrim([SegundoApellido]))='' then '' else ' '+[SegundoApellido] end)", false);

            entity.HasOne(d => d.EntidadTipo).WithMany(p => p.PersonaEntidadTipo)
                .HasForeignKey(d => d.EntidadTipoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_EntidadTipoID");

            entity.HasOne(d => d.PersonaTipo).WithMany(p => p.PersonaPersonaTipo)
                .HasForeignKey(d => d.PersonaTipoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Concepto");
        });

        modelBuilder.Entity<PersonaEmail>(entity =>
        {
            entity.HasKey(e => e.IdHistorico).HasName("PK_PersonaCorreo_IdHistorico");

            entity.ToTable("PersonaEmail", "Persona");

            entity.HasIndex(e => e.Email, "UQ_PersonaCorreo_Correo").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Persona).WithMany(p => p.PersonaEmail)
                .HasForeignKey(d => d.PersonaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaCorreo_PersonaID");
        });

        modelBuilder.Entity<PersonaTelefono>(entity =>
        {
            entity.HasKey(e => e.IdHistorico).HasName("PK_PersonaTelefono_IdHistorico");

            entity.ToTable("PersonaTelefono", "Persona");

            entity.HasIndex(e => e.Telefono, "UQ_PersonaTelefono_Telefono").IsUnique();

            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Telefono).HasMaxLength(15);

            entity.HasOne(d => d.Persona).WithMany(p => p.PersonaTelefono)
                .HasForeignKey(d => d.PersonaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaTelefono_PersonaID");
        });

        modelBuilder.Entity<PlanCuenta>(entity =>
        {
            entity.HasKey(e => e.CuentaID).HasName("PKc_PlanCuenta_CuentaID");

            entity.ToTable("PlanCuenta", "Finanzas");

            entity.HasIndex(e => new { e.CodigoContable, e.EmpresaID }, "UQ_PlanCuenta_EmpresaID").IsUnique();

            entity.HasIndex(e => e.CodigoContable, "nIX_PlanCuenta_CodigoContable");

            entity.HasIndex(e => e.PadreID, "nIX_PlanCuenta_PadreID");

            entity.Property(e => e.CuentaID).ValueGeneratedNever();
            entity.Property(e => e.CodigoContable).HasMaxLength(15);
            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.nCuentaContable).HasMaxLength(150);

            entity.HasOne(d => d.Empresa).WithMany(p => p.PlanCuenta)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlanCuenta_EmpresaID");

            entity.HasOne(d => d.Estado).WithMany(p => p.PlanCuenta)
                .HasForeignKey(d => d.EstadoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlanCuenta_EstadoID");

            entity.HasOne(d => d.Naturaleza).WithMany(p => p.PlanCuenta)
                .HasForeignKey(d => d.NaturalezaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlanCuenta_NaturalezaID");

            entity.HasOne(d => d.Nivel).WithMany(p => p.PlanCuenta)
                .HasForeignKey(d => d.NivelID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlanCuenta_NivelID");

            entity.HasOne(d => d.Padre).WithMany(p => p.InversePadre)
                .HasForeignKey(d => d.PadreID)
                .HasConstraintName("FK_PlanCuenta_PadreID");
        });

        modelBuilder.Entity<PlanCuentaNaturaleza>(entity =>
        {
            entity.HasKey(e => e.NaturalezaID).HasName("PKc_PlanCuentaNaturaleza_NaturalezaID");

            entity.ToTable("PlanCuentaNaturaleza", "Finanzas");

            entity.Property(e => e.NaturalezaID).ValueGeneratedNever();
            entity.Property(e => e.Abreviacion).HasMaxLength(1);
            entity.Property(e => e.nNaturaleza).HasMaxLength(15);
        });

        modelBuilder.Entity<PlanCuentaNivel>(entity =>
        {
            entity.HasKey(e => e.NivelID).HasName("PKc_PlanCuentaNivel_NivelID");

            entity.ToTable("PlanCuentaNivel", "Finanzas");

            entity.Property(e => e.NivelID).ValueGeneratedNever();
            entity.Property(e => e.nNivel).HasMaxLength(15);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => new { e.ProductoID, e.EmpresaID });

            entity.ToTable("Producto", "Inventario");

            entity.Property(e => e.Descripcin).HasMaxLength(60);
            entity.Property(e => e.Nombre).HasMaxLength(30);

            entity.HasOne(d => d.Marca).WithMany(p => p.Producto)
                .HasForeignKey(d => d.MarcaID)
                .HasConstraintName("FK_Producto_Producto_Marca");

            entity.HasOne(d => d.TipoNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.Tipo)
                .HasConstraintName("FK_Producto_Producto_Tipo");

            entity.HasOne(d => d.ProductoSubCategoria).WithMany(p => p.Producto)
                .HasForeignKey(d => new { d.SubCategoriaID, d.EmpresaID })
                .HasConstraintName("FK_Producto_Producto_Categoria");
        });

        modelBuilder.Entity<ProductoCategoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaID).HasName("PK_Producto_Categoria");

            entity.ToTable("ProductoCategoria", "Inventario");

            entity.Property(e => e.CategoriaID).ValueGeneratedNever();
            entity.Property(e => e.FechaModificado).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<ProductoColor>(entity =>
        {
            entity.ToTable("ProductoColor", "Inventario");

            entity.Property(e => e.ProductoColorID).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(30);
        });

        modelBuilder.Entity<ProductoEmpaque>(entity =>
        {
            entity.ToTable("ProductoEmpaque", "Inventario");

            entity.Property(e => e.ProductoEmpaqueID).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(30);
        });

        modelBuilder.Entity<ProductoGenero>(entity =>
        {
            entity.HasKey(e => e.GeneroID);

            entity.ToTable("ProductoGenero", "Inventario");

            entity.Property(e => e.GeneroID).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(30);
        });

        modelBuilder.Entity<ProductoImagen>(entity =>
        {
            entity.HasKey(e => new { e.ProductoImagenID, e.ProductoVarianteID, e.EmpresaID });

            entity.ToTable("ProductoImagen", "Inventario");

            entity.HasOne(d => d.ProductoVariante).WithMany(p => p.ProductoImagen)
                .HasForeignKey(d => new { d.ProductoVarianteID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductoImagen_Producto_Variante");
        });

        modelBuilder.Entity<ProductoMarca>(entity =>
        {
            entity.HasKey(e => e.MarcaID).HasName("PK_Producto_Marca");

            entity.ToTable("ProductoMarca", "Inventario");

            entity.Property(e => e.MarcaID).ValueGeneratedNever();
            entity.Property(e => e.FechaModificado).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<ProductoSubCategoria>(entity =>
        {
            entity.HasKey(e => new { e.SubCategoriaID, e.EmpresaID });

            entity.ToTable("ProductoSubCategoria", "Inventario");

            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.Categoria).WithMany(p => p.ProductoSubCategoria)
                .HasForeignKey(d => d.CategoriaID)
                .HasConstraintName("FK_ProductoSubCategoria_ProductoCategoria");
        });

        modelBuilder.Entity<ProductoTamaño>(entity =>
        {
            entity.ToTable("ProductoTamaño", "Inventario");

            entity.Property(e => e.ProductoTamañoID).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(30);
        });

        modelBuilder.Entity<ProductoTipo>(entity =>
        {
            entity.ToTable("ProductoTipo", "Inventario");

            entity.Property(e => e.ProductoTipoID).ValueGeneratedNever();
            entity.Property(e => e.FechaModificado).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<ProductoUnidadMedida>(entity =>
        {
            entity.HasKey(e => e.UnidadMedidaID);

            entity.ToTable("ProductoUnidadMedida", "Inventario");

            entity.Property(e => e.UnidadMedidaID).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(30);
        });

        modelBuilder.Entity<ProductoVariante>(entity =>
        {
            entity.HasKey(e => new { e.ProductoVarianteID, e.EmpresaID });

            entity.ToTable("ProductoVariante", "Inventario");

            entity.Property(e => e.CodigoBarra1).HasMaxLength(30);
            entity.Property(e => e.CodigoBarra2).HasMaxLength(30);
            entity.Property(e => e.CodigoBarraExtra).HasMaxLength(30);
            entity.Property(e => e.CostoVenta).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DescuentoCupon).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SkuID).HasMaxLength(20);

            entity.HasOne(d => d.Color).WithMany(p => p.ProductoVariante)
                .HasForeignKey(d => d.ColorID)
                .HasConstraintName("FK_ProductoVariante_ProductoColor");

            entity.HasOne(d => d.Empaque).WithMany(p => p.ProductoVariante)
                .HasForeignKey(d => d.EmpaqueID)
                .HasConstraintName("FK_ProductoVariante_ProductoEmpaque");

            entity.HasOne(d => d.Genero).WithMany(p => p.ProductoVariante)
                .HasForeignKey(d => d.GeneroID)
                .HasConstraintName("FK_ProductoVariante_ProductoUnidadMedida");

            entity.HasOne(d => d.Tamaño).WithMany(p => p.ProductoVariante)
                .HasForeignKey(d => d.TamañoID)
                .HasConstraintName("FK_ProductoVariante_ProductoTamaño");

            entity.HasOne(d => d.UnidadMedida).WithMany(p => p.ProductoVariante)
                .HasForeignKey(d => d.UnidadMedidaID)
                .HasConstraintName("FK_ProductoVariante_ProductoGenero");

            entity.HasOne(d => d.Volumen).WithMany(p => p.ProductoVariante)
                .HasForeignKey(d => d.VolumenID)
                .HasConstraintName("FK_ProductoVariante_ProductoVolumen");

            entity.HasOne(d => d.Producto).WithMany(p => p.ProductoVariante)
                .HasForeignKey(d => new { d.ProductoID, d.EmpresaID })
                .HasConstraintName("FK_ProductoVariante_Producto");
        });

        modelBuilder.Entity<ProductoVolumen>(entity =>
        {
            entity.ToTable("ProductoVolumen", "Inventario");

            entity.Property(e => e.ProductoVolumenID).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(30);
        });

        modelBuilder.Entity<ReciboDetalle>(entity =>
        {
            entity.HasKey(e => e.ReciboDetalleID).HasName("PKc_ReciboDetalle_ReciboDetalleID");

            entity.ToTable("ReciboDetalle", "Tesoreria");

            entity.Property(e => e.DocumentoReferencia).HasMaxLength(50);
            entity.Property(e => e.MontoAplicado).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Recibo).WithMany(p => p.ReciboDetalle)
                .HasForeignKey(d => d.ReciboID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReciboDetalleID_ReciboID");
        });

        modelBuilder.Entity<ReciboEstado>(entity =>
        {
            entity.HasKey(e => new { e.ReciboID, e.EstadoID, e.Fecha }).HasName("PKc_ReciboEstado_ReciboID");

            entity.ToTable("ReciboEstado", "Tesoreria");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.MAC).HasMaxLength(50);
            entity.Property(e => e.Observaciones).HasMaxLength(150);

            entity.HasOne(d => d.Caja).WithMany(p => p.ReciboEstado)
                .HasForeignKey(d => d.CajaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReciboEstado_CajaID");

            entity.HasOne(d => d.Estado).WithMany(p => p.ReciboEstado)
                .HasForeignKey(d => d.EstadoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReciboEstado_EstadoID");

            entity.HasOne(d => d.Recibo).WithMany(p => p.ReciboEstado)
                .HasForeignKey(d => d.ReciboID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReciboEstado_ReciboID");

            entity.HasOne(d => d.UsuarioGraba).WithMany(p => p.ReciboEstado)
                .HasForeignKey(d => d.UsuarioGrabaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CReciboEstado_UsuarioGrabaID");
        });

        modelBuilder.Entity<ReciboTipo>(entity =>
        {
            entity.HasKey(e => e.ReciboTipoID).HasName("PKc_ReciboTipo_ReciboTipoID");

            entity.ToTable("ReciboTipo", "Tesoreria");

            entity.Property(e => e.ReciboTipoID).ValueGeneratedNever();
        });

        modelBuilder.Entity<Recibos>(entity =>
        {
            entity.HasKey(e => e.ReciboID).HasName("PKc_Recibos_ReciboID");

            entity.ToTable("Recibos", "Tesoreria");

            entity.HasIndex(e => e.NumeroRecibo, "UQ_Recibos_NumeroRecibo").IsUnique();

            entity.HasIndex(e => e.ClienteID, "nIX_Recibos_ClienteID");

            entity.HasIndex(e => e.CuentaBancariaID, "nIX_Recibos_CuentaBancariaID");

            entity.HasIndex(e => new { e.EmpresaID, e.CentroCostoID }, "nIX_Recibos_EmpresaIDCentroCostoID");

            entity.HasIndex(e => e.NumeroRecibo, "nIX_Recibos_NumeroRecibo");

            entity.Property(e => e.ReciboID).ValueGeneratedNever();
            entity.Property(e => e.Concepto).HasMaxLength(250);
            entity.Property(e => e.NumeroRecibo).HasMaxLength(30);
            entity.Property(e => e.PorcentajeComision).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.CuentaBancaria).WithMany(p => p.Recibos)
                .HasForeignKey(d => d.CuentaBancariaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recibos_CuentaBancariaID");

            entity.HasOne(d => d.FormaPago).WithMany(p => p.Recibos)
                .HasForeignKey(d => d.FormaPagoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recibos_FormaPagoID");

            entity.HasOne(d => d.Moneda).WithMany(p => p.Recibos)
                .HasForeignKey(d => d.MonedaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recibos_MonedaID");

            entity.HasOne(d => d.ReciboTipo).WithMany(p => p.Recibos)
                .HasForeignKey(d => d.ReciboTipoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recibos_ReciboTipoID");

            entity.HasOne(d => d.CentroCosto).WithMany(p => p.Recibos)
                .HasForeignKey(d => new { d.CentroCostoID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recibos_CentroCostoIDEmpresaID");
        });

        modelBuilder.Entity<SolicitudCompra>(entity =>
        {
            entity.HasKey(e => new { e.SolicitudCompraID, e.EmpresaID }).HasName("PK_Compras_SolicitudCompra");

            entity.ToTable("SolicitudCompra", "Compras");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Observaciones).HasMaxLength(200);
        });

        modelBuilder.Entity<SolicitudCompraDetalle>(entity =>
        {
            entity.HasKey(e => new { e.SolicitudCompraDetalleID, e.EmpresaID }).HasName("PK_Compras_SolicitudCompraDetalle");

            entity.ToTable("SolicitudCompraDetalle", "Compras");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ProductoVariante).WithMany(p => p.SolicitudCompraDetalle)
                .HasForeignKey(d => new { d.ProductoVarianteID, d.EmpresaID })
                .HasConstraintName("FK_Compras_SolicitudCompraDetalle_Inventario_ProductoVariante");

            entity.HasOne(d => d.SolicitudCompra).WithMany(p => p.SolicitudCompraDetalle)
                .HasForeignKey(d => new { d.SolicitudCompraID, d.EmpresaID })
                .HasConstraintName("FK_Compras_SolicitudCompraDetalle_Compras_SolicitudCompra");
        });

        modelBuilder.Entity<SolicitudDevolucion>(entity =>
        {
            entity.HasKey(e => new { e.SolicitudDevolucionID, e.EmpresaID }).HasName("PK_Compras_SolicitudDevolucion");

            entity.ToTable("SolicitudDevolucion", "Compras");

            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Pendiente");
            entity.Property(e => e.Motivo).HasMaxLength(500);

            entity.HasOne(d => d.OrdenPedido).WithMany(p => p.SolicitudDevolucion)
                .HasForeignKey(d => new { d.OrdenPedidoID, d.EmpresaID })
                .HasConstraintName("FK_Compras_SolicitudDevolucion_Compras_OrdenPedido");
        });

        modelBuilder.Entity<SubModulo>(entity =>
        {
            entity.HasKey(e => new { e.SubModuloID, e.ModuloID }).HasName("PK_SubModulo_SubModuloID");

            entity.ToTable("SubModulo", "Seguridad");

            entity.Property(e => e.Codigo).HasMaxLength(5);
            entity.Property(e => e.Descripcion).HasMaxLength(350);
            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Icon).HasMaxLength(150);
            entity.Property(e => e.RouterLink).HasMaxLength(150);
            entity.Property(e => e.nSubModulo).HasMaxLength(100);

            entity.HasOne(d => d.Modulo).WithMany(p => p.SubModulo)
                .HasForeignKey(d => d.ModuloID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubModulo_ModuloID");
        });

        modelBuilder.Entity<TasaCambio>(entity =>
        {
            entity.HasKey(e => e.TasaID)
                .HasName("PKc_TasaCambio_TasaID")
                .IsClustered(false);

            entity.ToTable("TasaCambio", "Catalogos");

            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TasaMonto).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.MonedaDestino).WithMany(p => p.TasaCambioMonedaDestino)
                .HasForeignKey(d => d.MonedaDestinoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TasaCambio_MonedaDestinoID");

            entity.HasOne(d => d.MonedaOrigen).WithMany(p => p.TasaCambioMonedaOrigen)
                .HasForeignKey(d => d.MonedaOrigenID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TasaCambio_MonedaOrigenID");
        });

        modelBuilder.Entity<TipoDocumentoMovimiento>(entity =>
        {
            entity.HasKey(e => new { e.TipoDocumentoMovimientoID, e.EmpresaID });

            entity.ToTable("TipoDocumentoMovimiento", "Inventario");

            entity.Property(e => e.AfectaInventario).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(20);

            entity.HasOne(d => d.TipoMovimiento).WithMany(p => p.TipoDocumentoMovimiento)
                .HasForeignKey(d => d.TipoMovimientoID)
                .HasConstraintName("FK_TipoDocumentoMovimiento_TipoMovimiento");
        });

        modelBuilder.Entity<TipoMovimiento>(entity =>
        {
            entity.HasKey(e => new { e.TipoMovimientoID, e.EmpresaID }).HasName("PK_CuentasCobrar_TipoMovimiento");

            entity.ToTable("TipoMovimiento", "CuentasCobrar");

            entity.Property(e => e.TipoMovimientoID)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Consecutivo).HasMaxLength(12);
            entity.Property(e => e.Descripcion).HasMaxLength(600);
            entity.Property(e => e.Nombre).HasMaxLength(300);
            entity.Property(e => e.Siglas).HasMaxLength(20);
        });

        modelBuilder.Entity<TipoMovimiento1>(entity =>
        {
            entity.HasKey(e => e.TipoMovimientoID).HasName("FK_TipoMovimiento");

            entity.ToTable("TipoMovimiento", "Inventario");

            entity.Property(e => e.TipoMovimientoID).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(20);
        });

        modelBuilder.Entity<TipoMovimientoConceptos>(entity =>
        {
            entity.HasKey(e => new { e.TipoMovimientoConceptosID, e.EmpresaID, e.TipoMovimientoID }).HasName("PK_CuentasCobrar_TipoMovimientoConceptos");

            entity.ToTable("TipoMovimientoConceptos", "CuentasCobrar");

            entity.Property(e => e.TipoMovimientoConceptosID)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.TipoMovimientoID)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Concepto).HasMaxLength(500);
            entity.Property(e => e.CuentaContable).HasMaxLength(30);
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.TipoMovimiento).WithMany(p => p.TipoMovimientoConceptos)
                .HasForeignKey(d => new { d.TipoMovimientoID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CuentasCobrar_TipoMovimientoConceptos_CuentasCobrar_TipoMovimiento_TipoMovimientoID");
        });

        modelBuilder.Entity<Transaccion>(entity =>
        {
            entity.HasKey(e => new { e.MovimientoID, e.EmpresaID }).HasName("PK_CuentasCobrar_Transaccion");

            entity.ToTable("Transaccion", "CuentasCobrar");

            entity.Property(e => e.MovimientoID)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Modificado).HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Referencia).HasMaxLength(40);
            entity.Property(e => e.TipoConcepto)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.TipoMovimientoID)
                .HasMaxLength(2)
                .IsFixedLength();

            entity.HasOne(d => d.TipoMovimiento).WithMany(p => p.Transaccion)
                .HasForeignKey(d => new { d.TipoMovimientoID, d.EmpresaID })
                .HasConstraintName("FK_CuentasCobrar_Transaccion_CuentasCobrar_TipoMovimiento_TipoMovimientoID");
        });

        modelBuilder.Entity<Transaccion_Auditoria>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Transaccion_Auditoria", "CuentasCobrar");

            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.DescripcionNueva).HasMaxLength(500);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaModificado).HasColumnType("datetime");
            entity.Property(e => e.FechaNueva).HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MontoNuevo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MovimientoID)
                .HasMaxLength(14)
                .IsFixedLength();
            entity.Property(e => e.TipoMovimientoID)
                .HasMaxLength(2)
                .IsFixedLength();
        });

        modelBuilder.Entity<Transferencia>(entity =>
        {
            entity.HasKey(e => e.TransferenciaID).HasName("PKc_Transferencia_ChequeID");

            entity.ToTable("Transferencia", "Tesoreria");

            entity.HasIndex(e => new { e.CuentaBancariaOrigenID, e.CuentaBancariaDestinoID }, "nIX_Transferencia_CuentaBancariaOrigenIDCuentaBancariaDestinoID");

            entity.HasIndex(e => e.EmpresaID, "nIX_Transferencia_EmpresaID");

            entity.Property(e => e.Concepto).HasMaxLength(30);
            entity.Property(e => e.DocumentoReferencia).HasMaxLength(30);
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CuentaBancariaDestino).WithMany(p => p.TransferenciaCuentaBancariaDestino)
                .HasForeignKey(d => d.CuentaBancariaDestinoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transferencia_CuentaBancariaDestinoID");

            entity.HasOne(d => d.CuentaBancariaOrigen).WithMany(p => p.TransferenciaCuentaBancariaOrigen)
                .HasForeignKey(d => d.CuentaBancariaOrigenID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transferencia_CuentaBancariaOrigenID");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Transferencia)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transferencia_EmpresaID");
        });

        modelBuilder.Entity<TransferenciaEstado>(entity =>
        {
            entity.HasKey(e => new { e.TransferenciaID, e.EstadoID, e.Fecha }).HasName("PKc_TransferenciaEstado_ChequeID");

            entity.ToTable("TransferenciaEstado", "Tesoreria");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.MAC).HasMaxLength(100);
            entity.Property(e => e.Observaciones).HasMaxLength(150);

            entity.HasOne(d => d.Caja).WithMany(p => p.TransferenciaEstado)
                .HasForeignKey(d => d.CajaID)
                .HasConstraintName("FK_TransferenciaEstado_CajaID");

            entity.HasOne(d => d.Estado).WithMany(p => p.TransferenciaEstado)
                .HasForeignKey(d => d.EstadoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransferenciaEstado_EstadoID");

            entity.HasOne(d => d.Transferencia).WithMany(p => p.TransferenciaEstado)
                .HasForeignKey(d => d.TransferenciaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransferenciaEstado_TransferenciaID");

            entity.HasOne(d => d.UsuarioGraba).WithMany(p => p.TransferenciaEstado)
                .HasForeignKey(d => d.UsuarioGrabaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransferenciaEstado_UsuarioGrabaID");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioID).HasName("PK_UsuarioUsuarioID");

            entity.ToTable("Usuario", "Seguridad");

            entity.HasIndex(e => e.Login, "UQ_Usuario_Login").IsUnique();

            entity.Property(e => e.UsuarioID).ValueGeneratedNever();
            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Login).HasMaxLength(25);

            entity.HasOne(d => d.Estado).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.EstadoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EstadoID_Persona");

            entity.HasOne(d => d.Persona).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.PersonaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_PersonaID");
        });

        modelBuilder.Entity<UsuarioEmpresa>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioID, e.EmpresaID }).HasName("PK_UsuarioEmpresa_UsuarioIDEmpresaID");

            entity.ToTable("UsuarioEmpresa", "Seguridad");

            entity.Property(e => e.FechaDesde).HasColumnType("datetime");
            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaHasta).HasColumnType("datetime");

            entity.HasOne(d => d.Empresa).WithMany(p => p.UsuarioEmpresa)
                .HasForeignKey(d => d.EmpresaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioEmpresa_EmpresaID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioEmpresa)
                .HasForeignKey(d => d.UsuarioID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioEmpresa_UsuarioID");
        });

        modelBuilder.Entity<UsuarioPerfil>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioID, e.PerfilID, e.EmpresaID }).HasName("PK_UsuarioPerfil_UsuarioIDPerfilID");

            entity.ToTable("UsuarioPerfil", "Seguridad");

            entity.Property(e => e.FechaDesde).HasColumnType("datetime");
            entity.Property(e => e.FechaGrabado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaHasta).HasColumnType("datetime");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioPerfil)
                .HasForeignKey(d => d.UsuarioID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioPerfil_UsuarioID");

            entity.HasOne(d => d.Perfil).WithMany(p => p.UsuarioPerfil)
                .HasForeignKey(d => new { d.PerfilID, d.EmpresaID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioPerfil_PerfilID");
        });

        modelBuilder.Entity<vwPlanCuentas>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwPlanCuentas", "Finanzas");

            entity.Property(e => e.Abreviacion).HasMaxLength(1);
            entity.Property(e => e.CodigoContable).HasMaxLength(15);
            entity.Property(e => e.FechaGrabado).HasColumnType("datetime");
            entity.Property(e => e.nCuentaContable).HasMaxLength(150);
            entity.Property(e => e.nNaturaleza).HasMaxLength(15);
            entity.Property(e => e.nNivel).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
