using Entidades.Configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas.PlanCuentas
{
    /// <summary>
    /// Clase que representa el nivel de una cuenta en el plan de cuentas.
    /// </summary>
    public class PlanCuentaNivel
    {
        public int NivelID { get; set; }

        public string nNivel { get; set; } = null!;

        public int Orden { get; set; }

        public int Longitud { get; set; }
    }
}
