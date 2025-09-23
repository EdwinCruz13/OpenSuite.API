using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class MonedaDenominacion
{
    public int DenominacionID { get; set; }

    public int MonedaID { get; set; }

    public string nDenominacion { get; set; } = null!;

    public decimal Valor { get; set; }

    public string TipoMoneda { get; set; } = null!;

    public virtual ICollection<ArqueoDetalleEfectivo> ArqueoDetalleEfectivo { get; set; } = new List<ArqueoDetalleEfectivo>();

    public virtual Moneda Moneda { get; set; } = null!;
}
