namespace Entidades.Seguridad.Modulos
{
    public class SubModulo
    {
        public int SubModuloID { get; set; }
        public int ModuloID { get; set; }
        public string nSubModulo { get; set; } = null!;

        public string? Codigo { get; set; }

        public string? Descripcion { get; set; }
        public string? Icon { get; set; }

        public String Route { get; set; } = null!;

        public DateTime? FechaGrabado { get; set; }

        public List<Accion> Acciones { get; set; } = new List<Accion>();
    }
}