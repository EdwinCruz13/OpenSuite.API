using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Banco
{
    public int BancoID { get; set; }

    public int nBanco { get; set; }

    public string Siglas { get; set; } = null!;

    public int? CodigoBancario { get; set; }

    public virtual ICollection<CuentaBancaria> CuentaBancaria { get; set; } = new List<CuentaBancaria>();
}
