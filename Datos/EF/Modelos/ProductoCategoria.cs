using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ProductoCategoria
{
    public int CategoriaID { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaModificado { get; set; }

    public virtual ICollection<ProductoSubCategoria> ProductoSubCategoria { get; set; } = new List<ProductoSubCategoria>();
}
