using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Recibos
{
    public int ReciboID { get; set; }

    public int CentroCostoID { get; set; }

    public int EmpresaID { get; set; }

    public int CuentaBancariaID { get; set; }

    public int MonedaID { get; set; }

    public int FormaPagoID { get; set; }

    public int ReciboTipoID { get; set; }

    public int ClienteID { get; set; }

    public string NumeroRecibo { get; set; } = null!;

    public string? Concepto { get; set; }

    public decimal? PorcentajeComision { get; set; }

    public virtual CentroCosto CentroCosto { get; set; } = null!;

    public virtual CuentaBancaria CuentaBancaria { get; set; } = null!;

    public virtual Concepto FormaPago { get; set; } = null!;

    public virtual Moneda Moneda { get; set; } = null!;

    public virtual ICollection<ReciboDetalle> ReciboDetalle { get; set; } = new List<ReciboDetalle>();

    public virtual ICollection<ReciboEstado> ReciboEstado { get; set; } = new List<ReciboEstado>();

    public virtual ReciboTipo ReciboTipo { get; set; } = null!;
}
