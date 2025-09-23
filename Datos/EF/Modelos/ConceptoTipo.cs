using System;
using System.Collections.Generic;

namespace Datos.EF.Modelos;

public partial class ConceptoTipo
{
    public int ConceptoTipoID { get; set; }

    public string nConceptoTipo { get; set; } = null!;

    public string Abreviatura { get; set; } = null!;

    public virtual ICollection<Concepto> Concepto { get; set; } = new List<Concepto>();
}
