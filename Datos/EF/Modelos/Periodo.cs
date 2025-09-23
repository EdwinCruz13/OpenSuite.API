using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Periodo
{
    public int PeriodoID { get; set; }

    public int EmpresaID { get; set; }

    public int Año { get; set; }

    public int Mes { get; set; }

    public DateOnly FechaApertura { get; set; }

    public DateOnly FechaCierre { get; set; }

    public int EstadoID { get; set; }

    public DateTime? FechaGrabado { get; set; }

    public int? UsuarioGraba { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<PeriodoDetalle> PeriodoDetalle { get; set; } = new List<PeriodoDetalle>();
}
