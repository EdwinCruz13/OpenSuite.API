using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ComprobanteTipo
{
    public string ComprobanteTipoID { get; set; } = null!;

    public int EmpresaID { get; set; }

    public int CentroCostoID { get; set; }

    public int ComprobanteNaturalezaID { get; set; }

    public string nTipoComprobante { get; set; } = null!;

    public string CodigoTipo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual CentroCosto CentroCosto { get; set; } = null!;

    public virtual ICollection<Comprobante> Comprobante { get; set; } = new List<Comprobante>();

    public virtual ComprobanteNaturaleza ComprobanteNaturaleza { get; set; } = null!;

    public virtual ICollection<ComprobanteSecuencia> ComprobanteSecuencia { get; set; } = new List<ComprobanteSecuencia>();
}
