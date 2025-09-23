using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class OrdenDetalleEstado
{
    public long nOrdenID { get; set; }

    public int EmpresaID { get; set; }

    public int? EstadoID { get; set; }

    public DateTime Fecha { get; set; }

    public int? UsuarioID { get; set; }

    public string? MacID { get; set; }

    public bool? Activo { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual Estado? Estado { get; set; }

    public virtual Orden Orden { get; set; } = null!;

    public virtual Persona? Usuario { get; set; }
}
