using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Seguridad.Modulos
{
    public class Modulo
    {
        public int ModuloID { get; set; }

        public string nModulo { get; set; } = null!;

        public string? Codigo { get; set; }

        public string? Descripcion { get; set; }
        public string? Icon { get; set; }

        public String Route { get; set; } = null!;
        public List<SubModulo> SubModulo { get; set; } = new List<SubModulo>();
    }
}
