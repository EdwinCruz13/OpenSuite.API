using Entidades.Catalogos;

namespace Entidades.Configuraciones
{
    public class Almacen
    {
        public int AlmacenID { get; set; }

        public int CentroCostoID { get; set; }

        public int EmpresaID { get; set; }

        public Ciudad Ciudad { get; set; } = null!;

        public Pais Pais { get; set; }

        public int Descripcion { get; set; }

       

        
    }
}