using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas.PlanCuentas
{
    /// <summary>
    /// Clase que representa la naturaleza de una cuenta en el plan de cuentas.
    /// </summary>
    public class PlanCuentaNaturaleza
    {
        public int NaturalezaID { get; set; }

        public string nNaturaleza { get; set; } = null!;

        public string? Abreviacion { get; set; }
    }
}
