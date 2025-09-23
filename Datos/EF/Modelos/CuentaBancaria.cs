using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class CuentaBancaria
{
    public int CuentaBancariaID { get; set; }

    public int CuentaID { get; set; }

    public int BancoID { get; set; }

    public int CentroCostoID { get; set; }

    public int EmpresaID { get; set; }

    public int MonedaID { get; set; }

    public string CodigoCuentaBancaria { get; set; } = null!;

    public string nCuentaBancaria { get; set; } = null!;

    public string? nPropietario { get; set; }

    public int? TipoCuentaBancariaID { get; set; }

    public virtual Banco Banco { get; set; } = null!;

    public virtual CentroCosto CentroCosto { get; set; } = null!;

    public virtual ICollection<ChequeSerie> ChequeSerie { get; set; } = new List<ChequeSerie>();

    public virtual PlanCuenta Cuenta { get; set; } = null!;

    public virtual Moneda Moneda { get; set; } = null!;

    public virtual ICollection<Recibos> Recibos { get; set; } = new List<Recibos>();

    public virtual Concepto? TipoCuentaBancaria { get; set; }

    public virtual ICollection<Transferencia> TransferenciaCuentaBancariaDestino { get; set; } = new List<Transferencia>();

    public virtual ICollection<Transferencia> TransferenciaCuentaBancariaOrigen { get; set; } = new List<Transferencia>();
}
