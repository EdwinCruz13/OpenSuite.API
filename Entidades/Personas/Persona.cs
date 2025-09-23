using Entidades.Catalogos;

namespace Entidades.Personas
{
    /// <summary>
    /// Clase que representa una persona en el sistema.
    /// </summary>
    public class Persona
    {
        public int PersonaID { get; set; }

        public Concepto PersonaTipo { get; set; } = null!;

        public Concepto EntidadTipo { get; set; } = null!;

        public string Identificacion { get; set; } = null!;

        public string PrimerNombre { get; set; } = null!;

        public string? SegundoNombre { get; set; }

        public string? PrimerApellido { get; set; }

        public string? SegundoApellido { get; set; }

        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public string? nPersona { get; set; }

        public string? FirmaUrl { get; set; }

        public DateTime? FechaGrabado { get; set; }
    }


    public class PersonaDTO
    {
        public int PersonaID { get; set; }

        public int PersonaTipoID { get; set; }

        public int EntidadTipoID { get; set; }

        public string Identificacion { get; set; } = null!;

        public string PrimerNombre { get; set; } = string.Empty;

        public string? SegundoNombre { get; set; }

        public string PrimerApellido { get; set; } = string.Empty;

        public string? SegundoApellido { get; set; }

        public string Email { get; set; } = string.Empty;

        public string? Telefono { get; set; }

        public string? nPersona { get; set; }

        public string? FirmaUrl { get; set; }

        public DateTime? FechaGrabado { get; set; }

    }
}