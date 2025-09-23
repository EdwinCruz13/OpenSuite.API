using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Catalogos
{
    public class DocumentoMadre
    {
        public int DocumentoID { get; set; }

        public string nDocumento { get; set; } = null!;

        public int ModuloID { get; set; }

    }
}
