using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Transferencia
{
    public int TransferenciaID { get; set; }

    public int EmpresaID { get; set; }

    public int CuentaBancariaOrigenID { get; set; }

    public int CuentaBancariaDestinoID { get; set; }

    public decimal Monto { get; set; }

    public string Concepto { get; set; } = null!;

    public int Beneficiario { get; set; }

    public string? DocumentoReferencia { get; set; }

    public virtual CuentaBancaria CuentaBancariaDestino { get; set; } = null!;

    public virtual CuentaBancaria CuentaBancariaOrigen { get; set; } = null!;

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual ICollection<FacturaCompraPagos> FacturaCompraPagos { get; set; } = new List<FacturaCompraPagos>();

    public virtual ICollection<TransferenciaEstado> TransferenciaEstado { get; set; } = new List<TransferenciaEstado>();
}
