namespace Entidades.Catalogos
{
    /// <summary>
    /// Clase que representa una ciudad en el sistema.
    /// </summary>
    public class Ciudad
    {
        public int CiudadID { get; set; }

        public int PaisID { get; set; }

        public Pais Pais { get; set; }

        public string nCiudad { get; set; } = null!;

        public string CodigoEstado { get; set; } = null!;

        public string ZonaHoraria { get; set; } = null!;
    }
}