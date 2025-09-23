namespace Entidades.Catalogos
{
    /// <summary>
    /// Clase que representa un país en el sistema.
    /// </summary>
    public class Pais
    {
        public int PaisID { get; set; }

        public string nPais { get; set; } = null!;

        public string? CodigoPostal { get; set; }

        public string CodigoTelefonico { get; set; } = null!;

        public string Abreviatura { get; set; } = null!;

        public string Flag_Url { get; set; } = null!;

        public string Region { get; set; } = null!;

        public virtual ICollection<Ciudad> Ciudad { get; set; } = new List<Ciudad>();
    }
}