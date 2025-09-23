using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ProductoSubCategoria
{
    public int SubCategoriaID { get; set; }

    public int EmpresaID { get; set; }

    public int? CategoriaID { get; set; }

    public string? Nombre { get; set; }

    public virtual ProductoCategoria? Categoria { get; set; }

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
