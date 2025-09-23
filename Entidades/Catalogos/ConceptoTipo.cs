using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Catalogos
{
    /// <summary>
    /// Clase que representa un tipo de concepto en el sistema.
    /// </summary>
    public class ConceptoTipo
    {
        public int ConceptoTipoID { get; set; }

        public string nConceptoTipo { get; set; } = null!;

        public string Abreviatura { get; set; } = null!;

        public ICollection<Concepto> Concepto { get; set; } = new List<Concepto>();
    }
}
