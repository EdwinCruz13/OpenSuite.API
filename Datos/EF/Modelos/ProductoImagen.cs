using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ProductoImagen
{
    public long ProductoImagenID { get; set; }

    public int ProductoVarianteID { get; set; }

    public int EmpresaID { get; set; }

    public byte[]? Imagen { get; set; }

    public int? Estado { get; set; }

    public virtual ProductoVariante ProductoVariante { get; set; } = null!;
}
