using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ComprobanteSecuencia
{
    public int SecuenciaID { get; set; }

    public string ComprobanteTipoID { get; set; } = null!;

    public int EmpresaID { get; set; }

    public int CentroCostoID { get; set; }

    public int AñoComprobante { get; set; }

    public int MesComprobante { get; set; }

    public int Numero { get; set; }

    public string CodigoComprobante { get; set; } = null!;

    public DateTime FechaGrabado { get; set; }

    public virtual ComprobanteTipo ComprobanteTipo { get; set; } = null!;
}
