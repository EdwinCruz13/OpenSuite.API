using Entidades.Catalogos;

namespace Entidades.Configuraciones
{
    public class EmpresaMoneda
    {
        public int EmpresaMonedaID { get; set; }
        public int EmpresaID { get; set; }

        public Moneda Moneda { get; set; } = null!;

        public int MonedaID { get; set; }

        public bool esRegistro { get; set; }

        
    }
}