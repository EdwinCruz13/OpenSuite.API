namespace Entidades.Configuraciones
{
    /// <summary>
    /// Relación entre una empresa y su dueño (propietario).
    /// </summary>
    public class EmpresaDueno
    {
        public Int32 EmpresaID { get; set; }

        public int DuenoID { get; set; }

        public DateTime FechaGrabado { get; set; }
        
    }
}