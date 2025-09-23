using Entidades.Catalogos;

namespace Entidades.Configuraciones
{
    public class CentroCosto
    {
        public int CentroCostoID { get; set; }

        public Int32 EmpresaID { get; set; }

        public Ciudad Ciudad { get; set; } = null!;

        public Pais Pais { get; set; } = null!;

        public string Serie { get; set; } = null!;

        public int Consecutivo { get; set; }

        public string nCentroCosto { get; set; } = null!;

        public string CodigoCentroCosto { get; set; } = null!;

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public bool esPrincipal { get; set; }

        public ICollection<Almacen> Almacen { get; set; } = new List<Almacen>();


    }
}