using Entidades.Catalogos;

namespace Entidades.Configuraciones
{
    public class EmpresaGiroEconomico
    {
        public int EmpresaID { get; set; }

        public Concepto TipoGiro { get; set; } = null!;

        public DateTime FechaGrabado { get; set; }

        
    }
}