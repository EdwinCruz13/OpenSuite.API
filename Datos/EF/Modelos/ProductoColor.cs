using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ProductoColor
{
    public int ProductoColorID { get; set; }

    public string? Descripcion { get; set; }

    public int? Estado { get; set; }

    public virtual ICollection<ProductoVariante> ProductoVariante { get; set; } = new List<ProductoVariante>();
}
