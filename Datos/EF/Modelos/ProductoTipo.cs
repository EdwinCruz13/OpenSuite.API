using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ProductoTipo
{
    public int ProductoTipoID { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaModificado { get; set; }

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
