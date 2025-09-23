using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Amortizacion_Auditoria
{
    public long? nOrdenID { get; set; }

    public int? EmpresaID { get; set; }

    public int? Consecutivo { get; set; }

    public DateTime? Fecha { get; set; }

    public string? MovimientoID { get; set; }

    public decimal? Debito { get; set; }

    public decimal? Credito { get; set; }

    public decimal? Principal { get; set; }

    public decimal? Saldo { get; set; }

    public DateTime? FechaNueva { get; set; }

    public decimal? DebitoNuevo { get; set; }

    public decimal? CreditoNuevo { get; set; }

    public decimal? PrincipalNuevo { get; set; }

    public decimal? SaldoNUevo { get; set; }

    public int? UsuarioID { get; set; }

    public DateTime? FechaModificado { get; set; }
}
