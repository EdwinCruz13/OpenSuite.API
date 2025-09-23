using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Catalogos
{
    public class MonedaDenominacion
    {
        public int DenominacionID { get; set; }
        public int MonedaID { get; set; }
        public string nDenominacion { get; set; } = null!;
        public decimal Valor { get; set; }

        public string TipoMoneda { get; set; } = null!;
        public virtual Moneda Moneda { get; set; } = null!;
    }
}
