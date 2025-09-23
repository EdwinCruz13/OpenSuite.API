using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Moneda
{
    public int MonedaID { get; set; }

    public int PaisID { get; set; }

    public string Codigo { get; set; } = null!;

    public string nMoneda { get; set; } = null!;

    public string? Siglas { get; set; }

    public virtual ICollection<CajaMovimiento> CajaMovimiento { get; set; } = new List<CajaMovimiento>();

    public virtual ICollection<Cheque> Cheque { get; set; } = new List<Cheque>();

    public virtual ICollection<CuentaBancaria> CuentaBancaria { get; set; } = new List<CuentaBancaria>();

    public virtual ICollection<EmpresaMoneda> EmpresaMoneda { get; set; } = new List<EmpresaMoneda>();

    public virtual ICollection<MonedaDenominacion> MonedaDenominacion { get; set; } = new List<MonedaDenominacion>();

    public virtual ICollection<OrdenCatalogoPago> OrdenCatalogoPago { get; set; } = new List<OrdenCatalogoPago>();

    public virtual Pais Pais { get; set; } = null!;

    public virtual ICollection<Recibos> Recibos { get; set; } = new List<Recibos>();

    public virtual ICollection<TasaCambio> TasaCambioMonedaDestino { get; set; } = new List<TasaCambio>();

    public virtual ICollection<TasaCambio> TasaCambioMonedaOrigen { get; set; } = new List<TasaCambio>();
}
