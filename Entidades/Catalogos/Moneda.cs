namespace Entidades.Catalogos
{
    /// <summary>
    /// Moneda de sistema
    /// </summary>
    public class Moneda
    {
        public int MonedaID { get; set; }

        public Pais Pais { get; set; } = null!;

        public string Codigo { get; set; } = null!;

        public string nMoneda { get; set; } = null!;

        public string? Siglas { get; set; }

        public ICollection<MonedaDenominacion> MonedaDenominacion { get; set; } = new List<MonedaDenominacion>();
    }
}