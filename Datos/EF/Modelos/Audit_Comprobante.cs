using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Audit_Comprobante
{
    public int ComprobanteID { get; set; }

    public int CuentaID { get; set; }

    public string ComprobanteTipoID { get; set; } = null!;

    public string EmpresaID { get; set; } = null!;

    public string CentroCostoID { get; set; } = null!;

    public string Concepto { get; set; } = null!;

    public decimal Debe { get; set; }

    public decimal Haber { get; set; }

    public int Orden { get; set; }

    public int Usuario { get; set; }

    public DateTime FechaModificacion { get; set; }
}
