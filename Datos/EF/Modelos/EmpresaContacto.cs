using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class EmpresaContacto
{
    public int ContactoID { get; set; }

    public int EmpresaID { get; set; }

    public int MedioContactoID { get; set; }

    public string Valor { get; set; } = null!;

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual Concepto MedioContacto { get; set; } = null!;
}
