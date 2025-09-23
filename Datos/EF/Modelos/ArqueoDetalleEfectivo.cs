using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ArqueoDetalleEfectivo
{
    public int ArqueoEfectivoID { get; set; }

    public int CajaArqueoID { get; set; }

    public int DenominacionID { get; set; }

    public int Cantidad { get; set; }

    public decimal Total { get; set; }

    public virtual CajaArqueo CajaArqueo { get; set; } = null!;

    public virtual MonedaDenominacion Denominacion { get; set; } = null!;
}
