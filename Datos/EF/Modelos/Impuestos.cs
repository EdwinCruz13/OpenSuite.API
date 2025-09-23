using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Impuestos
{
    public int ImpuestoID { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Siglas { get; set; } = null!;

    public decimal Valor { get; set; }

    public DateTime FechaInicia { get; set; }

    public DateTime? FechaFin { get; set; }

    public DateTime? FechaGrabado { get; set; }

    public int? UsuarioGraba { get; set; }

    public bool? Estado { get; set; }
}
