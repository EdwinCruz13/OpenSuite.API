using Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Configuraciones
{
    public partial class EmpresaContacto
    {
        public int ContactoID { get; set; }

        public int EmpresaID { get; set; }

        public int MedioContactoID { get; set; }

        public string Valor { get; set; } = null!;

        public virtual Concepto MedioContacto { get; set; } = null!;
    }

}
