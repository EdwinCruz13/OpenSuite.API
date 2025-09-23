using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Transaccion_Auditoria
{
    public string? MovimientoID { get; set; }

    public int? EmpresaID { get; set; }

    public string? TipoMovimientoID { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Monto { get; set; }

    public DateTime? FechaNueva { get; set; }

    public string? DescripcionNueva { get; set; }

    public decimal? MontoNuevo { get; set; }

    public int? UsuarioID { get; set; }

    public DateTime? FechaModificado { get; set; }
}
