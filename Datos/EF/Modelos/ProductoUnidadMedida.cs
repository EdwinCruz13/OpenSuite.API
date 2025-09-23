using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ProductoUnidadMedida
{
    public int UnidadMedidaID { get; set; }

    public string? Descripcion { get; set; }

    public int? Estado { get; set; }

    public virtual ICollection<ProductoVariante> ProductoVariante { get; set; } = new List<ProductoVariante>();
}
