namespace Entidades.Catalogos
{
    /// <summary>
    /// Clase que representa un concepto dentro del sistema.
    /// </summary>
    public class Concepto
    {
        public int ConceptoID { get; set; }

        public int ConceptoTipoID { get; set; }

        public string nConcepto { get; set; } = null!;

        public string? Siglas { get; set; }

        public bool Estado { get; set; }

        public ConceptoTipo ConceptoTipo { get; set; } = null!;
    }
}