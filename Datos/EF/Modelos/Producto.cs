using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class Producto
{
    public int ProductoID { get; set; }

    public int EmpresaID { get; set; }

    public int? SubCategoriaID { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcin { get; set; }

    public int? Tipo { get; set; }

    public int? MarcaID { get; set; }

    public virtual ProductoMarca? Marca { get; set; }

    public virtual ProductoSubCategoria? ProductoSubCategoria { get; set; }

    public virtual ICollection<ProductoVariante> ProductoVariante { get; set; } = new List<ProductoVariante>();

    public virtual ProductoTipo? TipoNavigation { get; set; }
}
