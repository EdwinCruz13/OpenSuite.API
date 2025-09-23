using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Catalogos
{
    public class TasaCambio
    {
        public int TasaID { get; set; }

        public int MonedaOrigenID { get; set; }

        public int MonedaDestinoID { get; set; }

        public DateOnly Fecha { get; set; }

        public decimal TasaMonto { get; set; }

        public DateTime FechaRegistro { get; set; }

        public virtual Moneda MonedaDestino { get; set; } = null!;

        public virtual Moneda MonedaOrigen { get; set; } = null!;
    }
}
