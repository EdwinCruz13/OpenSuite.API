using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class KardexMovimiento
{
    public int KardeMovimientoID { get; set; }

    public int EmpresaID { get; set; }

    public int ProductoVarianteID { get; set; }

    public DateTime? Fecha { get; set; }

    public int? AlmacenOrigenID { get; set; }

    public int? AlmacenDestinoID { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? CostoUnitarioID { get; set; }

    public string? Descripcion { get; set; }

    public int? TipoMovimientoID { get; set; }

    public string? DocumentoReferencia { get; set; }

    public virtual Almacen? AlmacenOrigen { get; set; }

    public virtual ProductoVariante ProductoVariante { get; set; } = null!;

    public virtual TipoDocumentoMovimiento? TipoDocumentoMovimiento { get; set; }
}
